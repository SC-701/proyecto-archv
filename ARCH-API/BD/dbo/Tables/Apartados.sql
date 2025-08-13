CREATE TABLE [dbo].[Apartados]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdCliente] UNIQUEIDENTIFIER NOT NULL, 
    [IdProducto] UNIQUEIDENTIFIER NOT NULL, 
    [Abono] DECIMAL(10, 2) NOT NULL, 
    [Fecha] DATETIME NULL, 
    [Estado] VARCHAR(15) NULL,
    CONSTRAINT [FK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([Id]),
    CONSTRAINT [FK_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([Id])
)
