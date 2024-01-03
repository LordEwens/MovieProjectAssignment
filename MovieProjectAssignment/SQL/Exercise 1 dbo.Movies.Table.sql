CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL identity (1,1) PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Director] NVARCHAR(50) NOT NULL, 
    [ReleaseYear] INT NOT NULL, 
    [Price] MONEY NOT NULL
)
