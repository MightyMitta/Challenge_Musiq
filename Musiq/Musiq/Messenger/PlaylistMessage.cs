using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Musiq.Model;

namespace Musiq.Messenger
{
    public class PlaylistMessage : MessageBase
    {
        public Playlist Playlist { get; set; }
        public PlaylistMessage(Playlist playlist)
        {
            Playlist = playlist;
        }
    }
}
