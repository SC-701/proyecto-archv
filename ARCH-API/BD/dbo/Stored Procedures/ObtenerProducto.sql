CREATE PROCEDURE ObtenerProducto
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
	SET NOCOUNT ON;

SELECT        Productos.Nombre, Productos.Precio, Productos.Cantidad,Productos.Talla, Productos.Fecha
FROM           Productos
WHERE        (Productos.Id = @Id)
END