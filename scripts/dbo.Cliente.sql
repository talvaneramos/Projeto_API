CREATE TABLE [dbo].[Cliente] (
    [IdCliente]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (150) NOT NULL,
    [Cpf]         VARCHAR (11)  NOT NULL,
    [Email]       VARCHAR (100) NOT NULL,
    [DataCriacao] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Cpf] ASC)
);

