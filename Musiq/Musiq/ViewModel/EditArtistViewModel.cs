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

namespace Musiq.ViewModel
{
    public class EditArtistViewModel : ViewModelBase
    {
        public MusiqEntities MusiqEntities { get; set; }
        public RelayCommand<Artist> EditArtistCommand { get; set; }
        public RelayCommand CancelArtistCommand { get; set; }
        public Artist Artist { get; set; }
        public EditArtistViewModel(MusiqEntities Db)
        {
            MusiqEntities = Db;
            EditArtistCommand = new RelayCommand<Artist>(Edit);
            CancelArtistCommand = new RelayCommand(Cancel);
            Artist = new Artist();
            Artist.DateOfBirth = DateTime.Today;
            MessengerInstance.Register<ArtistMessage>(this, message => Artist = message.Artist);
        }

        public void Edit(Artist artist)
        {
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new HistoryMessage());
            MessengerInstance.Send(new ArtistUpdateMessage());
        }

        public void Cancel()
        {
            Artist = new Artist();
            MessengerInstance.Send(new HistoryMessage());
        }
    }
}
