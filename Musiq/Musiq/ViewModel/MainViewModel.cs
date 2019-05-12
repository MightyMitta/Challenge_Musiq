using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Musiq.Messenger;
using Musiq.View;

namespace Musiq.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Page _currentPage;

        #region Song RelayCommands
        public RelayCommand CreateSongCommand { get; set; }
        public RelayCommand EditSongCommand { get; set; }
        public RelayCommand RemoveSongCommand { get; set; }
        #endregion

        #region Artist RelayCommands
        public RelayCommand CreateArtistCommand { get; set; }
        public RelayCommand EditArtistCommand { get; set; }
        public RelayCommand RemoveArtistCommand { get; set; }
        #endregion

        #region Playlist RelayCommands
        public RelayCommand CreatePlaylistCommand { get; set; }
        public RelayCommand EditPlaylistCommand { get; set; }
        public RelayCommand RemovePlaylistCommand { get; set; }
        #endregion
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        public RelayCommand HomeCommand { get; set; }
        public Stack<Page> History { get; set; }
        public Page CurrentPage { get { return _currentPage; } set { _currentPage = value; } }

        public MainViewModel()
        {
            History = new Stack<Page>();
            CurrentPage = new View.Menu();
            MessengerInstance.Register<PageMessage>(this, Message => SwitchPage(Message));
            MessengerInstance.Register<HistoryMessage>(this, Message => PageBack());
            #region RelayCommands
            CreateSongCommand = new RelayCommand(CreateSong);
            EditSongCommand = new RelayCommand(RemoveSong);
            RemoveSongCommand = new RelayCommand(RemoveSong);
            CreateArtistCommand = new RelayCommand(CreateArtist);
            EditArtistCommand = new RelayCommand(EditArtist);
            RemoveArtistCommand = new RelayCommand(RemoveArtist);
            CreatePlaylistCommand = new RelayCommand(CreatePlaylist);
            EditPlaylistCommand = new RelayCommand(EditPlaylist);
            RemovePlaylistCommand = new RelayCommand(RemovePlaylist);
            HomeCommand = new RelayCommand(Home);
            #endregion
        }

        // This method will change the CurrentPage to the page it which is given via PageMessage.
        // It will also put the CurrentPage into the History stack.
        // If the page which is given is the same as CurrentPage it will not change.
        public void SwitchPage(PageMessage pageMessage)
        {
            if(CurrentPage.GetType() == pageMessage.Page.GetType())
            {
                return;
            }
            History.Push(CurrentPage);
            CurrentPage = pageMessage.Page;
            RaisePropertyChanged("CurrentPage");
        }

        // This method will Pop 1 Page out of the History Stack and update the CurrentPage to the next Page from the Stack.
        public void PageBack()
        {
            CurrentPage = History.Pop();
            RaisePropertyChanged("CurrentPage");
        }

        // This method will change the Current Page to the Home page.
        public void Home()
        {
            MessengerInstance.Send(new PageMessage(new View.Menu()));
        }

        #region Music Methods

        // This method will open a new Window where the user can add a new song.
        public void CreateSong ()
        {
            MessengerInstance.Send(new PageMessage(new CreateSong()));
        }
        public void EditSong()
        {

        }
        public void RemoveSong()
        {

        }
        #endregion

        #region Artist Methods
        public void CreateArtist()
        {
            MessengerInstance.Send(new PageMessage(new CreateArtist()));
        }
        public void EditArtist()
        {

        }
        public void RemoveArtist()
        {

        }
        #endregion

        #region Playlist Methods
        public void CreatePlaylist()
        {
            MessengerInstance.Send(new PageMessage(new CreatePlaylist()));
        }
        public void EditPlaylist()
        {

        }
        public void RemovePlaylist()
        {

        }

        #endregion
    }
}