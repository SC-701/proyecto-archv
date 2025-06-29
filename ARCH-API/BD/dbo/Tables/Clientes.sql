CREATE TABLE [dbo].[Clientes] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Nombre]          VARCHAR (30)     NOT NULL,
    [Apellidos]       VARCHAR (30)     NOT NULL,
    [Telefono]        VARCHAR (15)     NOT NULL,
    [Provincia]       VARCHAR (15)     NOT NULL,
    [DireccionExacta] VARCHAR (MAX)    NOT NULL
);

