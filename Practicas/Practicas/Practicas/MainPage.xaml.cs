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

            if (UserEntry.Text.Length == 0)
            {
                await DisplayAlert("Error", "El campo de usuarios esta vacio", "Ok");
            }else if(PasswordEntry.Text.Length == 0)
            {
                await DisplayAlert("Error", "El campo de password esta vacio", "Ok");
            }
            else
            {
                await DisplayAlert("Bienvenido", "Hola " + UserEntry.Text, "Ok");
            }
        }
    }

}
