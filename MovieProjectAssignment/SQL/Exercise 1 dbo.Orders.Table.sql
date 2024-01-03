CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY, 
    [OrderDate] DATETIME NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])

)
