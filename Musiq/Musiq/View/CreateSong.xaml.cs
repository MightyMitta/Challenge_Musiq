using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Musiq.View
{
    /// <summary>
    /// Interaction logic for CreateMusic.xaml
    /// </summary>
    public partial class CreateSong : Page
    {
        public CreateSong()
        {
            InitializeComponent();
        }

        private void OpenFileDialog_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
