using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Musiq.Model;

namespace Musiq.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MusiqEntities>(true);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<CreateArtistViewModel>(true);
            SimpleIoc.Default.Register<CreateSongViewModel>(true);
            SimpleIoc.Default.Register<CreatePlaylistViewModel>(true);
            SimpleIoc.Default.Register<EditArtistViewModel>(true);
            SimpleIoc.Default.Register<EditSongViewModel>(true);
            SimpleIoc.Default.Register<EditPlaylistViewModel>(true);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public MenuViewModel Menu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public CreateArtistViewModel CreateArtist
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateArtistViewModel>();
            }
        }
        public CreateSongViewModel CreateMusic
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateSongViewModel>();
            }
        }
        public CreatePlaylistViewModel CreatePlaylist
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreatePlaylistViewModel>();
            }
        }
        public EditArtistViewModel EditArtist
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditArtistViewModel>();
            }
        }
        public EditSongViewModel EditSong
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditSongViewModel>();
            }
        }
        public EditPlaylistViewModel EditPlaylist
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditPlaylistViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}