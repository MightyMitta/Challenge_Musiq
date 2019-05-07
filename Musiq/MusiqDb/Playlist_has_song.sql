CREATE TABLE [dbo].[Playlist_has_song]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Playlist_Id] INT NOT NULL, 
    [Song_Id] INT NOT NULL, 
    CONSTRAINT [FK_Playlist_has_song_Playlist] FOREIGN KEY ([Playlist_Id]) REFERENCES [Playlist]([Playlist_Id]), 
    CONSTRAINT [FK_Playlist_has_song_Song] FOREIGN KEY ([Song_Id]) REFERENCES [Song]([Song_Id])
)
