using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Musiq.Messenger;
using Musiq.Model;

namespace Musiq.ViewModel
{
    public class CreatePlaylistViewModel : ViewModelBase
    {
        private ObservableCollection<Song> _unaddedSongs;
        private ObservableCollection<Song> _addedSongs;
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand CreateNewPlaylistCommand { get; set; }
        public RelayCommand CancelNewPlaylistCommand { get; set; }
        public Playlist Playlist { get; set; }
        public ObservableCollection<Song> UnaddedSongs { get { return _unaddedSongs; } set { _unaddedSongs = value; } }
        public ObservableCollection<Song> AddedSongs { get { return _addedSongs; } set { _addedSongs = value; } }
        public RelayCommand<Song> AddSongCommand { get; }
        public RelayCommand<Song> RemoveSongCommand { get; }
        public CreatePlaylistViewModel(MusiqEntities Db)
        {
            Playlist = new Playlist();
            AddSongCommand = new RelayCommand<Song>(AddSong);
            RemoveSongCommand = new RelayCommand<Song>(RemoveSong);

            MessengerInstance.Register<SongUpdateMessage>(this, message => ResetLists());
            MusiqEntities = Db;
            CreateNewPlaylistCommand = new RelayCommand(Create);
            CancelNewPlaylistCommand = new RelayCommand(Cancel);
            ResetLists();
        }

        public void Create()
        {
            try
            {
                if(Playlist.Description == null)
                {
                    Playlist.Description = "Default description.";
                }
                MusiqEntities.Playlists.Add(Playlist);
                foreach (Song song in _addedSongs)
                {
                    Playlist_has_song playlist_Has_Song = new Playlist_has_song();
                    playlist_Has_Song.Song = song;
                    playlist_Has_Song.Playlist = Playlist;
                    MusiqEntities.Playlist_has_song.Add(playlist_Has_Song);
                }
                MusiqEntities.SaveChanges();
                MessengerInstance.Send(new HistoryMessage());
                MessengerInstance.Send(new PlaylistUpdateMessage());
                Playlist = new Playlist();
                ResetLists();
            }
            catch
            {
                MessageBox.Show("Unable to create new Playlist", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void Cancel()
        {
            Playlist = new Playlist();
            ResetLists();
            MessengerInstance.Send(new HistoryMessage());
        }
        public void ResetLists()
        {
            _unaddedSongs = new ObservableCollection<Song>(MusiqEntities.Songs);
            _addedSongs = new ObservableCollection<Song>();
        }

        public void AddSong(Song song)
        {
            _addedSongs.Add(song);
            _unaddedSongs.Remove(song);
        }

        public void RemoveSong(Song song)
        {
            _addedSongs.Remove(song);
            _unaddedSongs.Add(song);
        }
    }
}
