CREATE PROCEDURE [dbo].[ObtenerApartados]
AS
BEGIN
	SET NOCOUNT ON;

SELECT        Apartados.Id, Apartados.IdCliente, Apartados.IdProducto, Apartados.Abono, Apartados.Restante, Apartados.Fecha, Apartados.Estado
FROM            Apartados
END
