CREATE TABLE [dbo].[Deposito] (
    [DepositoId]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreDeposito] VARCHAR (50)  NOT NULL,
    [Descripcion]    VARCHAR (150) NOT NULL,
    [Direccion]      VARCHAR (150) NOT NULL,
    [FechaAlta]      DATETIME      NOT NULL,
    [FechaBaja]      DATETIME      NULL,
    CONSTRAINT [PK_Deposito] PRIMARY KEY CLUSTERED ([DepositoId] ASC)
);

