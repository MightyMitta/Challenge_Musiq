using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Musiq.Model;

namespace Musiq.Messenger
{
    public class ArtistMessage : MessageBase
    {
        public Artist Artist { get; set; }
        public ArtistMessage(Artist artist)
        {
            Artist = artist;
        }
    }
}
