CREATE TABLE [dbo].[Artist_has_song]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Artist_Id] INT NOT NULL, 
    [Song_id] INT NOT NULL, 
    CONSTRAINT [FK_Artist_has_song_Artist] FOREIGN KEY (Artist_Id) REFERENCES [Artist]([Artist_Id]), 
    CONSTRAINT [FK_Artist_has_song_Song] FOREIGN KEY (Song_Id) REFERENCES [Song]([Song_Id])
)
