CREATE TABLE [dbo].[Posting]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME2 NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [MinToRead] NVARCHAR(50) NOT NULL 
)
