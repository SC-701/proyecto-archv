CREATE TABLE [dbo].[PerfilesxUsuario] (
    [IdUsuario] UNIQUEIDENTIFIER NOT NULL,
    [IdPerfil]  INT              NOT NULL,
    CONSTRAINT [PK_PerfilesxUsuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdPerfil] ASC),
    CONSTRAINT [FK_PerfilesxUsuario_Perfiles] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfiles] ([Id]),
    CONSTRAINT [FK_PerfilesxUsuario_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

