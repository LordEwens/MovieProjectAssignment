CREATE TABLE [dbo].[OrderRows]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY, 
    [OrderId] INT NOT NULL, 
    [MovieId] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    CONSTRAINT [FK_OrderRows_Movies] FOREIGN KEY ([MovieId]) REFERENCES [Movies]([Id]), 
    CONSTRAINT [FK_OrderRows_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
)
