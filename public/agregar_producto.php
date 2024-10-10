<?php
require_once '../middleware/middleware.php';

$middleware = new Middleware();

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $nombre = $_POST['nombre'];
    $descripcion = $_POST['descripcion'];
    $precio = $_POST['precio'];
    $stock = $_POST['stock'];
    $tienda_id = $_POST['tienda_id'];

    $middleware->agregarProducto($nombre, $descripcion, $precio, $stock, $tienda_id);
    header("Location: index.php");
}

$tiendas = $middleware->obtenerTiendas(); 
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Agregar Producto</title>
    <link rel="stylesheet" href="../css/styles.css">
</head>
<body>
    <header>
        <h1>Agregar Producto</h1>
        <nav>
            <a href="index.php">Ver Productos</a>
        </nav>
    </header>

    <main>
        <form action="" method="POST" class="form-agregar">
            <div class="form-group">
                <label for="nombre">Nombre:</label>
                <input type="text" name="nombre" required>
            </div>
            <div class="form-group">
                <label for="descripcion">Descripción:</label>
                <textarea name="descripcion" required></textarea>
            </div>
            <div class="form-group">
                <label for="precio">Precio:</label>
                <input type="number" name="precio" step="0.01" required>
            </div>
            <div class="form-group">
                <label for="stock">Stock:</label>
                <input type="number" name="stock" required>
            </div>
            <div class="form-group">
                <label for="tienda_id">Tienda:</label>
                <select name="tienda_id" required>
                    <option value="">Seleccione una tienda</option>
                    <?php foreach ($tiendas as $tienda): ?>
                        <option value="<?php echo $tienda['id']; ?>"><?php echo $tienda['nombre']; ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="form-group">
                <button type="submit">Agregar</button>
            </div>
        </form>
        <a href="index.php">Volver</a>
    </main>
</body>
</html>
