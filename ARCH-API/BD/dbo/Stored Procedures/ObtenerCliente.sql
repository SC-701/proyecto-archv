CREATE PROCEDURE ObtenerCliente
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
	SET NOCOUNT ON;

SELECT        Clientes.Nombre, Clientes.Apellidos, Clientes.Telefono, Clientes.Provincia, Clientes.DireccionExacta
FROM            Clientes
WHERE        (Clientes.Id = @Id)
END