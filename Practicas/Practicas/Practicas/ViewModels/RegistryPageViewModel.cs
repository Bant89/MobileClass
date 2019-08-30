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
    class RegistryPageViewModel : User, INotifyPropertyChanged
    {

        public static MasterDetailPage MD { get; set; }

        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegistryPageViewModel() {

            RegisterCommand = new Command(ConfirmRegistration);
        }

        async void ConfirmRegistration() {

            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos.", "Ok");
            }
            else
            {

                if (ConfirmPassword != Password)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "La contraseña  y la contraseña  de confirmacion no son las mismas, porfavor chequear denuevo.", "Ok");
                }
                else
                {
                    MD = new HomePage();

                    App.Current.MainPage = MD;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
