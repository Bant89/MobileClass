using Practicas.Models;
using Practicas.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class RegistryPageViewModel : INotifyPropertyChanged
    {

        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand { get; set; }

        public User User { get; set; } = new User();

        public RegistryPageViewModel() {

            RegisterCommand = new Command(ConfirmRegistration);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async void ConfirmRegistration() {

            if (string.IsNullOrEmpty(User.Password) || string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Name) || string.IsNullOrEmpty(User.Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos.", "Ok");
            }
            else
            {

                if (ConfirmPassword != User.Password)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "La contraseña  y la contraseña  de confirmacion no son las mismas, porfavor chequear denuevo.", "Ok");
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
            }
        }

    }
}
