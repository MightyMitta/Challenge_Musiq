using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Musiq.View;

namespace Musiq.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public Page CurrentPage { get; set; }

        public MainViewModel()
        {
            CurrentPage = new View.Menu();
        }
    }
}