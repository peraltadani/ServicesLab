CREATE TABLE [dbo].[Venta] (
    [VentaId]       INT      IDENTITY (1, 1) NOT NULL,
    [FechaVenta]    DATETIME NOT NULL,
    [EstadoVentaId] INT      NOT NULL,
    [ClienteId]     INT      NOT NULL,
    CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED ([VentaId] ASC)
);

