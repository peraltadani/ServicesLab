CREATE TABLE [dbo].[Insumo] (
    [InsumoId]     INT            IDENTITY (1, 1) NOT NULL,
    [SubConceptoId]  INT            NULL,
    [Descripcion]    VARCHAR (100)  NOT NULL,
    [UnidadMedidaId] INT            NOT NULL,
    [FechaAlta]      DATETIME       NOT NULL,
    [FechaBaja]      DATETIME       NULL,
    [Valuacion]      DECIMAL (8, 2) NULL,
    CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED ([InsumoId] ASC),
    CONSTRAINT [FK_Insumo_SubConcepto] FOREIGN KEY ([SubConceptoId]) REFERENCES [dbo].[SubConcepto] ([SubConceptoId]),
    CONSTRAINT [FK_Insumo_UnidadMedida] FOREIGN KEY ([UnidadMedidaId]) REFERENCES [dbo].[UnidadMedida] ([UnidadMedidaId])
);

