CREATE TABLE [dbo].[TblInvoice] (
    [Id]         INT NOT NULL IDENTITY(1,1),
    [CustomerId] INT NOT NULL,
    [ProductId]  INT NOT NULL,
    [Status] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL DEFAULT GetDate(), 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_TblInvoice_ToTblCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [TblCustomer]([Id]), 
    CONSTRAINT [FK_TblInvoice_ToTblProduct] FOREIGN KEY ([ProductId]) REFERENCES [TblProduct]([Id])
);

