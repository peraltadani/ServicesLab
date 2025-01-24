CREATE TABLE [dbo].[Producto] (
    [ProductoId]     INT            IDENTITY (1, 1) NOT NULL,
    [SubConceptoId]  INT            NULL,
    [Descripcion]    VARCHAR (100)  NOT NULL,
    [UnidadMedidaId] INT            NOT NULL,
    [FechaAlta]      DATETIME       NOT NULL,
    [UsuarioId]      INT            NOT NULL,
    [FechaBaja]      DATETIME       NULL,
    [Valuacion]      DECIMAL (8, 2) NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([ProductoId] ASC),
    CONSTRAINT [FK_Producto_SubConcepto] FOREIGN KEY ([SubConceptoId]) REFERENCES [dbo].[SubConcepto] ([SubConceptoId]),
    CONSTRAINT [FK_Producto_UnidadMedida] FOREIGN KEY ([UnidadMedidaId]) REFERENCES [dbo].[UnidadMedida] ([UnidadMedidaId])
);

