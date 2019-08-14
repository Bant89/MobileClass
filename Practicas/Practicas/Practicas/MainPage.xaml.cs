using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Practicas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnClicked(object ob, EventArgs ar)
        {

            if (string.IsNullOrEmpty(UserEntry.Text))
            {
                await DisplayAlert("Error", "El campo de usuari@ esta vacio.", "Ok");
            }else if(string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "El campo de clave esta vacio.", "Ok");
            }
            else
            {
                await DisplayAlert("Bienvenid@", $"Hola {UserEntry.Text}! ", "Ok");
            }
        }
    }

}
