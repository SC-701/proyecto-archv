CREATE PROCEDURE [dbo].[AgregarApartado]
	@Id UNIQUEIDENTIFIER, 
    @IdCliente UNIQUEIDENTIFIER, 
    @IdProducto UNIQUEIDENTIFIER, 
    @Abono DECIMAL(10, 2), 
    @Fecha DATETIME, 
    @Estado VARCHAR(15)	
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validar cantidad disponible
        DECLARE @CantidadDisponible INT;

        SELECT @CantidadDisponible = Cantidad
        FROM Productos
        WHERE Id = @IdProducto;

        IF @CantidadDisponible IS NULL
        BEGIN
            RAISERROR('Producto no encontrado.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @CantidadDisponible <= 0
        BEGIN
            RAISERROR('No hay productos disponibles para apartar.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar el apartado
        INSERT INTO [dbo].[Apartados]
               ([Id], [IdCliente], [IdProducto], [Abono], [Fecha], [Estado])
         VALUES
               (@Id, @IdCliente, @IdProducto, @Abono, @Fecha, @Estado);

        -- Actualizar la cantidad del producto
        UPDATE Productos
        SET Cantidad = Cantidad - 1
        WHERE Id = @IdProducto;

        SELECT @Id;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END
