CREATE PROCEDURE [dbo].[EditarApartado]
	@Id UNIQUEIDENTIFIER, 
    @IdCliente UNIQUEIDENTIFIER, 
    @IdProducto UNIQUEIDENTIFIER, 
    @Abono DECIMAL(10, 2), 
    @Restante DECIMAL(10, 2), 
    @Fecha DATETIME, 
    @Estado VARCHAR(15)		
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION
		UPDATE [dbo].[Apartados]
		   SET [IdCliente] = @IdCliente
			  ,[IdProducto] = @IdProducto
			  ,[Abono] = @Abono
			  ,[Restante] = @Restante
			  ,[Fecha] = @Fecha
			  ,[Estado] = @Estado
		 WHERE Id = @Id
		 SELECT @Id
	COMMIT TRANSACTION
END
