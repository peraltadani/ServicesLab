CREATE TABLE [dbo].[Usuario] (
    [UsuarioId]      INT          IDENTITY (1, 1) NOT NULL,
    [FechaAlta]      DATETIME     NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [Apellido]       VARCHAR (50) NOT NULL,
    [Mail]           VARCHAR (50) NOT NULL,
    [Password]       VARCHAR (50) NOT NULL,
    [Rol]            VARCHAR (50) NOT NULL,
    [UltimaConexion] DATETIME     NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);

