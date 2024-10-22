<?php
require_once '../config/db.php';

class Middleware {
    

    // Método para obtener tiendas
    public function obtenerTiendas() {
        global $pdo;
        $stmt = $pdo->query("SELECT * FROM Tiendas");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    // Método para obtener productos por tienda
    public function obtenerProductosPorTienda($tienda_id) {
        global $pdo;
        $stmt = $pdo->prepare("SELECT * FROM Productos WHERE tienda_id = ?");
        $stmt->execute([$tienda_id]);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    // Método para agregar un producto
    public function agregarProducto($nombre, $descripcion, $precio, $stock, $tienda_id) {
        global $pdo;
        $sql = "INSERT INTO Productos (nombre, descripcion, precio, stock, tienda_id) VALUES (?, ?, ?, ?, ?)";
        $stmt = $pdo->prepare($sql);
        return $stmt->execute([$nombre, $descripcion, $precio, $stock, $tienda_id]);
    }
}

// Manejo de solicitudes
if (isset($_GET['action'])) {
    $middleware = new Middleware();

    if ($_GET['action'] === 'obtenerTiendas') {
        header('Content-Type: application/json');
        echo json_encode($middleware->obtenerTiendas());
        exit;
    }

    if ($_GET['action'] === 'obtenerProductosPorTienda') {
        header('Content-Type: application/json');
        echo json_encode($middleware->obtenerProductosPorTienda($_GET['tienda_id']));
        exit;
    }
    
    if ($_GET['action'] === 'agregarProducto' && $_SERVER['REQUEST_METHOD'] === 'POST') {
        $data = json_decode(file_get_contents('php://input'), true);
        $nombre = $data['nombre'];
        $descripcion = $data['descripcion'];
        $precio = $data['precio'];
        $stock = $data['stock'];
        $tienda_id = $data['tienda_id'];

        $result = $middleware->agregarProducto($nombre, $descripcion, $precio, $stock, $tienda_id);
        header('Content-Type: application/json');
        echo json_encode(['success' => $result]);
        exit;
    }
}



