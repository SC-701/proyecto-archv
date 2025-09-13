CREATE PROCEDURE EditarCliente
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
		UPDATE [dbo].[Clientes]
		   SET [Nombre] = @Nombre
			  ,[Apellidos] = @Apellidos
			  ,[Telefono] = @Telefono
			  ,[Provincia] = @Provincia
			  ,[DireccionExacta] = @DireccionExacta
		 WHERE Id = @Id
		 SELECT @Id
	COMMIT TRANSACTION
END