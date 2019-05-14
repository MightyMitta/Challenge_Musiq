using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Musiq.Messenger;
using Musiq.Model;
using Musiq.View;

namespace Musiq.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public RelayCommand<Artist> EditArtistCommand { get; set; }
        public RelayCommand<Artist> RemoveArtistCommand { get; set; }
        public RelayCommand<Song> EditSongCommand { get; set; }
        public RelayCommand<Song> RemoveSongCommand { get; set; }
        public RelayCommand<Playlist> EditPlaylistCommand { get; set; }
        public RelayCommand<Playlist> RemovePlaylistCommand { get; set; }
        public MusiqEntities MusiqEntities { get; set; }
        public ObservableCollection<Artist> Artists { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<Playlist> Playlists { get; set; }
        public MenuViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
            Songs = new ObservableCollection<Song>(MusiqEntities.Songs);
            Playlists = new ObservableCollection<Playlist>(MusiqEntities.Playlists);

            EditArtistCommand = new RelayCommand<Artist>(EditArtist);
            RemoveArtistCommand = new RelayCommand<Artist>(RemoveArtist);
            MessengerInstance.Register<ArtistUpdateMessage>(this, message => UpdateArtists());

            EditSongCommand = new RelayCommand<Song>(EditSong);
            RemoveSongCommand = new RelayCommand<Song>(RemoveSong);
            MessengerInstance.Register<SongUpdateMessage>(this, message => UpdateSong());

            EditPlaylistCommand = new RelayCommand<Playlist>(EditPlaylist);
            RemovePlaylistCommand = new RelayCommand<Playlist>(RemovePlaylist);
            MessengerInstance.Register<PlaylistUpdateMessage>(this, message => UpdatePlaylist());
        }

        private void RemovePlaylist(Playlist playlist)
        {
            MusiqEntities.Playlists.Remove(playlist);
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new PlaylistUpdateMessage());
        }

        private void UpdatePlaylist()
        {
        }

        private void EditPlaylist(Playlist playlist)
        {
            MessengerInstance.Send(new PlaylistMessage(playlist));
            MessengerInstance.Send(new PageMessage(new EditPlaylist()));
        }

        public void EditArtist(Artist artist)
        {
            MessengerInstance.Send(new ArtistMessage(artist));
            MessengerInstance.Send(new PageMessage(new EditArtist()));
        }
        public void RemoveArtist(Artist artist)
        {
            MusiqEntities.Artists.Remove(artist);
            artist.Songs.Clear();
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new ArtistUpdateMessage());
        }

        public void UpdateArtists()
        {
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
            RaisePropertyChanged("Artists");
        }

        public void EditSong(Song song)
        {
            MessengerInstance.Send(new SongMessage(song));
            MessengerInstance.Send(new PageMessage(new EditSong()));
        }
        public void RemoveSong(Song song)
        {
            MusiqEntities.Songs.Remove(song);
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new SongUpdateMessage());
        }

        public void UpdateSong()
        {
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
            RaisePropertyChanged("Songs");
        }
    }
}
