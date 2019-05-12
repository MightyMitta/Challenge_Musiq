using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Musiq.Messenger;
using Musiq.Model;

namespace Musiq.ViewModel
{
    public class CreateSongViewModel : ViewModelBase
    {
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
        }

        private void Upload()
        {
        }

        public void Create()
        {
            MusiqEntities.Songs.Add(Song);
            MusiqEntities.SaveChanges();
            MessengerInstance.Send(new HistoryMessage());
        }

        public void Cancel()
        {
            Song = new Song();
            MessengerInstance.Send(new HistoryMessage());
        }
    }
}
