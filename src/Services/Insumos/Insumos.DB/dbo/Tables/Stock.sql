CREATE TABLE [dbo].[Stock] (
    [StockId]                  INT             IDENTITY (1, 1) NOT NULL,
    [InsumoId]                 INT             NOT NULL,
    [Fecha]                    DATETIME        NOT NULL,
    [Cantidad]                 DECIMAL (10, 2) NOT NULL,
    [StockActual]              DECIMAL (10, 2) NOT NULL,
    [DetalleRemitoProveedorId] INT             NULL,
    [DepositoId]               INT             NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED ([StockId] ASC),
    CONSTRAINT [FK_Stock_Deposito] FOREIGN KEY ([DepositoId]) REFERENCES [dbo].[Deposito] ([DepositoId]),
    CONSTRAINT [FK_Stock_Insumo] FOREIGN KEY ([InsumoId]) REFERENCES [dbo].[Insumo] ([InsumoId])
);

