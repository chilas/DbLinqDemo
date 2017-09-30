CREATE TABLE [dbo].[TblProduct] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (255)  NOT NULL,
    [Price]        DECIMAL (5, 2) NOT NULL,
    [Currency]     VARCHAR (3)    NOT NULL,
    [CreationDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

