using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Musiq.Messenger;
using Musiq.Model;
using Musiq.View;

namespace Musiq.ViewModel 
{
    public class CreateArtistViewModel : ViewModelBase
    {
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand CreateNewArtistCommand { get; set; }
        public RelayCommand CancelNewArtistCommand { get; set; }
        public Artist Artist { get; set; }
        public CreateArtistViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            CreateNewArtistCommand = new RelayCommand(Create);
            CancelNewArtistCommand = new RelayCommand(Cancel);
            Artist = new Artist();
            Artist.DateOfBirth = DateTime.Today;
        }

        public void Create()
        {
            try
            {
                MusiqEntities.Artists.Add(Artist);
                MusiqEntities.SaveChanges();
                MessengerInstance.Send(new HistoryMessage());
                MessengerInstance.Send(new ArtistUpdateMessage());
                Artist = new Artist();
            }
            catch
            {
                MessageBox.Show("Unable to create new Artist", "",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Cancel()
        {
            Artist = new Artist();
            MessengerInstance.Send(new HistoryMessage());
        }
    }
}
