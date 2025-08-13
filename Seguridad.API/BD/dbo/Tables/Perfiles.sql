CREATE TABLE [dbo].[Perfiles] (
    [Id]                INT              NOT NULL,
    [Nombre]            VARCHAR (MAX)    NOT NULL,
    [FechaCreacion]     DATETIME         NULL,
    [FechaModificacion] DATETIME         NULL,
    [UsuarioCrea]       UNIQUEIDENTIFIER NULL,
    [UsuarioModifica]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
