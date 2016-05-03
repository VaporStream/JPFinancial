CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(75) NOT NULL, 
    [Ticker] NCHAR(10) NOT NULL, 
    [SectorId] INT NOT NULL, 
    [IndustryId] INT NOT NULL
)
