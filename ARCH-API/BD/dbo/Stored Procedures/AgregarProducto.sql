CREATE PROCEDURE AgregarProducto
	@Id AS UNIQUEIDENTIFIER
	,@Nombre AS VARCHAR(30)
	,@Precio AS DECIMAL (10,2) 
	,@Cantidad AS INT 
	,@Talla AS VARCHAR(10)
	,@Fecha AS DATETIME
	AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION
		INSERT INTO [dbo].[Productos]
				   ([Id]
				   ,[Nombre]
				   ,[Precio]
				   ,[Cantidad]
				   ,[Talla]
				   ,[Fecha])
			 VALUES
				   (@Id
					,@Nombre
					,@Precio
					,@Cantidad
					,@Talla
					,@Fecha)
				SELECT @Id
	COMMIT TRANSACTION
END