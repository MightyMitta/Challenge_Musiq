using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Musiq.Model;

namespace Musiq.Messenger
{
    public class SongMessage : MessageBase
    {
        public Song Song { get; set; }
        public SongMessage(Song song)
        {
            Song = song;
        }
    }
}
