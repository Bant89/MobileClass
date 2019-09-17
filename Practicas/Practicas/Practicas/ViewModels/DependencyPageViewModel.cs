using Practica.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Practica.ViewModels
{
    public class DependencyPageViewModel : INotifyPropertyChanged
    {

        public string DeviceOrientation { get; set; }

        public ICommand OrientationCommand { get; set; }

        public DependencyPageViewModel()
        {
            OrientationCommand = new Command(AskOrientation);
        }

        public void AskOrientation()
        {
            DeviceOrientation orientation = DependencyService.Get<IDeviceOrientationService>().GetOrientation();
            DeviceOrientation = orientation.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
