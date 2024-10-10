<?php
require_once '../middleware/middleware.php';

$middleware = new Middleware();
$tiendas = $middleware->obtenerTiendas(); 

$productos = [];
if (isset($_POST['tienda_id'])) {
    $tienda_id = $_POST['tienda_id'];
    $productos = $middleware->obtenerProductosPorTienda($tienda_id); 
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>SD Tiendas</title>
    <link rel="stylesheet" href="../css/styles.css">
</head>
<body>
    <header>
        <h1>SD Tiendas</h1>
        <nav>
            <a href="agregar_producto.php">Agregar Producto</a>
        </nav>
    </header>

    <main>
        <h2>Productos Disponibles</h2>

        <form action="" method="POST">
            <label for="tienda_id">Seleccionar Tienda:</label>
            <select name="tienda_id" required>
                <option value="">Seleccione una tienda</option>
                <?php foreach ($tiendas as $tienda): ?>
                    <option value="<?php echo $tienda['id']; ?>"><?php echo $tienda['nombre']; ?></option>
                <?php endforeach; ?>
            </select>
            <button type="submit">Ver Productos</button>
        </form>

        <?php if (!empty($productos)): ?>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>Precio</th>
                        <th>Stock</th>
                        <th>Tienda ID</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($productos as $producto): ?>
                        <tr>
                            <td><?php echo $producto['id']; ?></td>
                            <td><?php echo $producto['nombre']; ?></td>
                            <td><?php echo $producto['descripcion']; ?></td>
                            <td><?php echo $producto['precio']; ?></td>
                            <td><?php echo $producto['stock']; ?></td>
                            <td><?php echo $producto['tienda_id']; ?></td>
                        </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        <?php endif; ?>
    </main>
</body>
</html>

