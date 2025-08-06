CREATE PROCEDURE [dbo].[AgregarApartado]
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
		INSERT INTO [dbo].[Apartados]
				   ([Id]
				   ,[IdCliente]
				   ,[IdProducto]
				   ,[Abono]
				   ,[Restante]
				   ,[Fecha]
				   ,[Estado])
			 VALUES
				   (@Id, 
					@IdCliente, 
					@IdProducto, 
					@Abono, 
					@Restante, 
					@Fecha, 
					@Estado)
				SELECT @Id
	COMMIT TRANSACTION
END
