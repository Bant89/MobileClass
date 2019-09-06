using Practicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Practicas.View;


namespace Practicas.ViewModels
{
     class HomePageViewModel : INotifyPropertyChanged
    {
        public ContactList ContactList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; set; }

        public HomePageViewModel()
        {
            ContactList = new ContactList();
            AddCommand = new Command(AddNavigation);
            System.Diagnostics.Debug.WriteLine(ContactList);
        }

        async void AddNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddPage());
        }

       
    }
}
