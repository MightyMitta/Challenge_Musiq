﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Musiq.ViewModel
{
    public class NewMusicViewModel : ViewModelBase
    {
        public RelayCommand CloseNewMusic { get; set; }
        public NewMusicViewModel()
        {
        }

        
    }
}
