CREATE PROCEDURE [dbo].[EliminarApartado]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    DECLARE @IdProducto UNIQUEIDENTIFIER;

    SELECT @IdProducto = IdProducto FROM Apartados WHERE Id = @Id;

    UPDATE Productos
    SET Cantidad = Cantidad + 1
    WHERE Id = @IdProducto;

    DELETE FROM Apartados
    WHERE Id = @Id;

    COMMIT TRANSACTION;
END
