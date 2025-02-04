CREATE TABLE [dbo].[UnidadMedida] (
    [UnidadMedidaId] INT          NOT NULL,
    [Abreviatura]    VARCHAR (5)  NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED ([UnidadMedidaId] ASC)
);

