CREATE TABLE [dbo].[DetalleVenta] (
    [DetalleVentaId] INT            IDENTITY (1, 1) NOT NULL,
    [VentaId]        INT            NOT NULL,
    [InsumoId]       INT            NOT NULL,
    [Cantidad]       DECIMAL (7, 2) NOT NULL,
    CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED ([DetalleVentaId] ASC),
    CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY ([VentaId]) REFERENCES [dbo].[Venta] ([VentaId])
);

