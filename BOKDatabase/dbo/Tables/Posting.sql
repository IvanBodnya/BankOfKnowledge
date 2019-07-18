CREATE TABLE [dbo].[Posting]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME2 NOT NULL DEFAULT getdate(), 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [MinToRead] NVARCHAR(50) NOT NULL 
)
