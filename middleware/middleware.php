<?php
require_once '../config/db.php';

class Middleware {
   

    public function obtenerTiendas() {
        global $pdo;
        $stmt = $pdo->query("SELECT * FROM Tiendas");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function obtenerProductosPorTienda($tienda_id) {
        global $pdo;
        $stmt = $pdo->prepare("SELECT * FROM Productos WHERE tienda_id = ?");
        $stmt->execute([$tienda_id]);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }
}


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
}
?>

