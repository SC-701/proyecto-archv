CREATE PROCEDURE [dbo].[ObtenerApartado]
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
	SET NOCOUNT ON;

SELECT        Apartados.Id, Apartados.IdCliente, Apartados.IdProducto, Apartados.Abono, Apartados.Restante, Apartados.Fecha, Apartados.Estado
FROM            Apartados
WHERE        (Apartados.Id = @Id)
END