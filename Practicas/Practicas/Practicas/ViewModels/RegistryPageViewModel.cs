using Practicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Practicas.ViewModels
{
    class RegistryPageViewModel : User, INotifyPropertyChanged
    {
        

        public RegistryPageViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
