CREATE PROCEDURE EditarProducto
	@Id AS UNIQUEIDENTIFIER
	,@Nombre AS VARCHAR(30)
	,@Precio AS DECIMAL (10,2)
	,@Cantidad AS INT
	,@Talla AS VARCHAR (10)
	,@Fecha AS DATETIME 	
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION
		UPDATE [dbo].[Productos]
		   SET [Nombre] = @Nombre
			  ,[Precio] = @Precio
			  ,[Cantidad] = @Cantidad
			  ,[Talla] = @Talla
			  ,[Fecha] = @Fecha
		 WHERE Id = @Id
		 SELECT @Id
	COMMIT TRANSACTION
END