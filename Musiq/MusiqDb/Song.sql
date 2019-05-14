CREATE TABLE [dbo].[Song]
(
	[Song_Id] INT NOT NULL PRIMARY KEY Identity, 
    [Artist_Id] INT NOT NULL , 
    [Title] VARCHAR(100) NOT NULL, 
    [Link] VARCHAR(50) NOT NULL, 
    [ImageLink] VARCHAR(100) NULL, 
    CONSTRAINT [FK_Song_Artist] FOREIGN KEY ([Artist_Id]) REFERENCES [Artist]([Artist_Id]) ON DELETE CASCADE
)
