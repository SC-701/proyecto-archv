CREATE PROCEDURE ObtenerProductos
AS
BEGIN
	SET NOCOUNT ON;

SELECT       Productos.Nombre,Productos.Precio, Productos.Cantidad, Productos.Talla, Productos.Fecha
FROM           Productos
END
