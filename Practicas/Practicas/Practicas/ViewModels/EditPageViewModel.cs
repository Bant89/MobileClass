using Practicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class EditPageViewModel : INotifyPropertyChanged
    {
        public Contact Contact { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand EditCommand { get; set; }


        public EditPageViewModel()
        {
            MessagingCenter.Subscribe<HomePageViewModel, Contact>(this, "EditContact", ((sender, param) =>
            {
                System.Diagnostics.Debug.WriteLine(param.FirstName);
                Contact = param;
                MessagingCenter.Unsubscribe<HomePageViewModel, Contact>(this, "EditContact");
            }));

            EditCommand = new Command(EditContact);
        }


        async public void EditContact()
        {
            MessagingCenter.Send<EditPageViewModel, Contact>(this, "EditedContact", Contact);
            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}
