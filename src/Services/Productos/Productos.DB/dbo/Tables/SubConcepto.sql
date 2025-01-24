CREATE TABLE [dbo].[SubConcepto] (
    [SubConceptoId] INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (50) NOT NULL,
    [ConceptoId]    INT          NOT NULL,
    [FechaAlta]     DATETIME     NOT NULL,
    CONSTRAINT [PK_SubConcepto] PRIMARY KEY CLUSTERED ([SubConceptoId] ASC),
    CONSTRAINT [FK_SubConcepto_Concepto] FOREIGN KEY ([ConceptoId]) REFERENCES [dbo].[Concepto] ([ConceptoId])
);

