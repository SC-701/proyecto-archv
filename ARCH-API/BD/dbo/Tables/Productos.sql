CREATE TABLE [dbo].[Productos]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Nombre] VARCHAR (30)     NOT NULL,
    [Precio] DECIMAL (10,2)     NOT NULL,
	[Cantidad] INT     NOT NULL,
	[Talla] VARCHAR (10) ,
	[Fecha] DATETIME DEFAULT GETDATE() ,
)
