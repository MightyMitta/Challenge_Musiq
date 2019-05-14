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
    public class EditPlaylistViewModel : ViewModelBase
    {
        private ObservableCollection<Song> _unaddedSongs;
        private ObservableCollection<Song> _addedSongs;
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand EditPlaylistCommand { get; set; }
        public RelayCommand CancelEditPlaylistCommand { get; set; }
        public Playlist Playlist { get; set; }
        public ObservableCollection<Song> UnaddedSongs { get { return _unaddedSongs; } set { _unaddedSongs = value; } }
        public ObservableCollection<Song> AddedSongs { get { return _addedSongs; } set { _addedSongs = value; } }
        public RelayCommand<Song> AddSongCommand { get; }
        public RelayCommand<Song> RemoveSongCommand { get; }
        public EditPlaylistViewModel(MusiqEntities Db)
        {
            AddSongCommand = new RelayCommand<Song>(AddSong);
            RemoveSongCommand = new RelayCommand<Song>(RemoveSong);
            MessengerInstance.Register<PlaylistMessage>(this, message => Fill(message.Playlist));
            MusiqEntities = Db;
            EditPlaylistCommand = new RelayCommand(Edit);
            CancelEditPlaylistCommand = new RelayCommand(Cancel);
            Playlist = new Playlist();
            ResetLists();
        }

        public void Edit()
        {
            if(string.IsNullOrWhiteSpace(Playlist.Description))
            {
                Playlist.Description = "Default description.";
            }
            foreach (Playlist_has_song playlist_Has_Song in Playlist.Playlist_has_song.ToList())
            {
                MusiqEntities.Playlist_has_song.Remove(playlist_Has_Song);
            }
            foreach(Song song in _addedSongs)
            {
                Playlist_has_song playlist_Has_Song = new Playlist_has_song();
                playlist_Has_Song.Playlist = Playlist;
                playlist_Has_Song.Song = song;
                Playlist.Playlist_has_song.Add(playlist_Has_Song);
            }
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new PlaylistUpdateMessage());
            MessengerInstance.Send(new HistoryMessage());
        }

        public void Cancel()
        {
            Playlist = new Playlist();
            MessengerInstance.Send(new HistoryMessage());
        }
        public void ResetLists()
        {
            _addedSongs = new ObservableCollection<Song>();
            foreach(Playlist_has_song playlist_Has_Song in Playlist.Playlist_has_song)
            {
                _addedSongs.Add(playlist_Has_Song.Song);
            }
            _unaddedSongs = new ObservableCollection<Song>(MusiqEntities.Songs.ToList().Where(Song => !_addedSongs.Contains(Song)));
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
        public void Fill(Playlist playlist)
        {
            Playlist = playlist;
            ResetLists();
        }
    }
}

