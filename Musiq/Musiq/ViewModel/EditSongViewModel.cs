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
    public class EditSongViewModel : ViewModelBase
    {
        public ObservableCollection<Artist> Artists { get; set; }
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand EditSong { get; set; }
        public RelayCommand CancelEditSong { get; set; }
        public RelayCommand UploadFileCommand { get; set; }
        public Song Song { get; set; }
        public EditSongViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            EditSong = new RelayCommand(Edit);
            CancelEditSong = new RelayCommand(Cancel);
            UploadFileCommand = new RelayCommand(Upload);
            Song = new Song();
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
            MessengerInstance.Register<ArtistUpdateMessage>(this, Message => UpdateArtists());
            MessengerInstance.Register<SongMessage>(this, message => Song = message.Song);
        }

        private void Upload()
        {
        }

        public void Edit()
        {
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new HistoryMessage());
            MessengerInstance.Send(new SongUpdateMessage());
        }

        public void Cancel()
        {
            Song = new Song();
            MessengerInstance.Send(new HistoryMessage());
        }

        public void UpdateArtists()
        {
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
        }
    }
}