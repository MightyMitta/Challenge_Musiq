using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    public class CreateSongViewModel : ViewModelBase
    {
        public ObservableCollection<Artist> Artists { get; set; }
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand CreateNewArtist { get; set; }
        public RelayCommand CancelNewArtist { get; set; }
        public RelayCommand UploadFileCommand { get; set; }
        public Song Song { get; set; }
        public CreateSongViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            CreateNewArtist = new RelayCommand(Create);
            CancelNewArtist = new RelayCommand(Cancel);
            UploadFileCommand = new RelayCommand(Upload);
            Song = new Song();
            Artists = new ObservableCollection<Artist>(MusiqEntities.Artists);
            MessengerInstance.Register<ArtistUpdateMessage>(this, Message => UpdateArtists());

        }

        private void Upload()
        {
        }

        public void Create()
        {
            try
            {
                Song.Link = "[TEST LINK]";
                MusiqEntities.Songs.Add(Song);
                MusiqEntities.SaveChanges();
                MessengerInstance.Send(new HistoryMessage());
                MessengerInstance.Send(new SongUpdateMessage());
                Song = new Song();
            }
            catch
            {
                MessageBox.Show("Unable to create new Song", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
