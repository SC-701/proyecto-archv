CREATE PROCEDURE ObtenerClientes
AS
BEGIN
	SET NOCOUNT ON;

SELECT        Clientes.Nombre, Clientes.Apellidos, Clientes.Telefono, Clientes.Provincia, Clientes.DireccionExacta
FROM            Clientes
END