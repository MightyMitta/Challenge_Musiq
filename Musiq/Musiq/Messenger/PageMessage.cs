using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Musiq.Messenger
{
    public class PageMessage : MessageBase
    {
        public Page Page { get; }

        public PageMessage(Page page)
        {
            Page = page;
        }
    }
}
