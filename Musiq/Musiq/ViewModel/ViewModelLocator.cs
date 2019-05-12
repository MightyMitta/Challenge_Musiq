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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}