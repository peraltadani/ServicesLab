CREATE TABLE [dbo].[Concepto] (
    [ConceptoId]  INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [FechaAlta]   DATETIME     NOT NULL,
    CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED ([ConceptoId] ASC)
);

