CREATE TABLE [dbo].[TblCustomer] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Firstname] VARCHAR (255) NOT NULL,
    [Lastname]  VARCHAR (255) NOT NULL,
    [Email]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

