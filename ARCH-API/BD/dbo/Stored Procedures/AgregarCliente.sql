CREATE PROCEDURE AgregarCliente
	@Id AS UNIQUEIDENTIFIER
	,@Nombre AS VARCHAR(30)
	,@Apellidos AS VARCHAR(30)
	,@Telefono AS VARCHAR(15)
	,@Provincia AS VARCHAR(15)
	,@DireccionExacta AS VARCHAR(MAX)	
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION
		INSERT INTO [dbo].[Clientes]
				   ([Id]
				   ,[Nombre]
				   ,[Apellidos]
				   ,[Telefono]
				   ,[Provincia]
				   ,[DireccionExacta])
			 VALUES
				   (@Id
					,@Nombre
					,@Apellidos
					,@Telefono
					,@Provincia
					,@DireccionExacta)
				SELECT @Id
	COMMIT TRANSACTION
END