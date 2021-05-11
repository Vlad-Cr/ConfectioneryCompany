CREATE TABLE [dbo].[Outlets]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(128) NOT NULL, 
    [Region] NCHAR(128) NOT NULL, 
    [Profit] FLOAT NOT NULL
)