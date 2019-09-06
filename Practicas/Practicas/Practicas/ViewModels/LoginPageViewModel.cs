using Practicas.Models;
using Practicas.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public User CurrentUser { get; set; } = new User();
        public string ErrorMessage { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand RegistryCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegistryCommand = new Command(RegistryNavigation);
        }

        async void RegistryNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegistryPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async void Login()
        {
            if (string.IsNullOrEmpty(CurrentUser.Email))
            {
                ErrorMessage = "Campo de Email vacio";
            }else if (string.IsNullOrEmpty(CurrentUser.Password))
            {
                ErrorMessage = "Campo de Password vacio";

            }else
            {
                await App.Current.MainPage.DisplayAlert("Bienvenid@", $"Hola es un placer tener devuelta", "Ok");


                await App.Current.MainPage.Navigation.PushAsync(new HomePage());

            }

             System.Diagnostics.Debug.WriteLine($"{CurrentUser.Email} - {CurrentUser.Password}");
        }

    }
}
