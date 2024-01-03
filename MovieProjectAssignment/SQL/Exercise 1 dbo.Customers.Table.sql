CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL identity (1,1) PRIMARY KEY, 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [Lastname] NVARCHAR(50) NOT NULL, 
    [BillingAddress] NVARCHAR(50) NOT NULL, 
    [BillingZip] NVARCHAR(50) NOT NULL, 
    [BillingCity] NVARCHAR(50) NOT NULL, 
    [DeliveryAddress] NVARCHAR(50) NOT NULL, 
    [DeliveryZip] NVARCHAR(50) NOT NULL, 
    [DeliveryCity] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [PhoneNo] NCHAR(10) NOT NULL, 
)
