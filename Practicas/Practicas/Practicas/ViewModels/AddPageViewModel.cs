using Practicas.Models;
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
       
        public Contact contact { get; set; }
        public ICommand AddCommand { get; set; }

        public AddPageViewModel()
        {
            AddCommand = new Command(AddContact);
            contact = new Contact();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async void AddContact()
        {
            MessagingCenter.Send<AddPageViewModel, Contact>(this, "AddContact", contact);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
