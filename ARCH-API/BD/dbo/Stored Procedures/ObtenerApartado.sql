CREATE PROCEDURE [dbo].[ObtenerApartado]
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.Id,
        a.IdCliente,
        c.Nombre AS Cliente,
        a.IdProducto,
        p.Nombre AS Producto,
        p.Precio AS PrecioProducto,
        a.Abono,
        a.Fecha,
        a.Estado
    FROM Apartados a
    INNER JOIN Clientes c ON a.IdCliente = c.Id
    INNER JOIN Productos p ON a.IdProducto = p.Id
    WHERE a.Id = @Id
END