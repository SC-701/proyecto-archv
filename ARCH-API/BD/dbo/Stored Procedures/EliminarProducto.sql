CREATE PROCEDURE EliminarProducto
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica si el producto está siendo usado en Apartados
    IF EXISTS (SELECT 1 FROM Apartados WHERE IdProducto = @Id)
    BEGIN
        RAISERROR ('El producto está siendo utilizado en un apartado y no se puede eliminar.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION
        DELETE FROM Productos WHERE Id = @Id;
    COMMIT TRANSACTION
END
