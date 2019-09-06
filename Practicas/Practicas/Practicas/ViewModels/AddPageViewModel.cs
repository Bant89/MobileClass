using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class AddPageViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; set; }

        public AddPageViewModel()
        {
            AddCommand = new Command(AddContact);
        }

        async void AddContact()
        {
            System.Diagnostics.Debug.WriteLine("Clicked add command");
        }


    }
}
