using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Musiq.Messenger;
using Musiq.Model;

namespace Musiq.ViewModel
{
    public class CreatePlaylistViewModel : ViewModelBase
    {
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand CreateNewPlaylistCommand { get; set; }
        public RelayCommand CancelNewPlaylistCommand { get; set; }
        public Playlist Playlist { get; set; }
        public CreatePlaylistViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            CreateNewPlaylistCommand = new RelayCommand(Create);
            CancelNewPlaylistCommand = new RelayCommand(Cancel);
            Playlist = new Playlist();
        }

        public void Create()
        {
            if (Playlist.Description == null)
            {
                Playlist.Description = "Default description.";
            }
            MusiqEntities.Playlists.Add(Playlist);
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new HistoryMessage());
        }

        public void Cancel()
        {
            Playlist = new Playlist();
            MessengerInstance.Send(new HistoryMessage());
        }
    }
}
