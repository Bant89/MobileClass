﻿using Practicas.Models;
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
    class LoginPageViewModel : User, INotifyPropertyChanged
    {
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
            if (string.IsNullOrEmpty(Email))
            {
                ErrorMessage = "Campo de Email vacio";
            }else if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Campo de Password vacio";

            }else
            {
                await App.Current.MainPage.DisplayAlert("Bienvenid@", $"Hola es un placer tener devuelta", "Ok");
                
            }

             System.Diagnostics.Debug.WriteLine($"{Email} - {Password}");
        }

    }
}