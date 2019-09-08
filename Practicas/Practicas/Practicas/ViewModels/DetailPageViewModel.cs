using Practicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class DetailPageViewModel : INotifyPropertyChanged
    {
        public Contact Contact { get; set; } = new Contact();


        public DetailPageViewModel()
        {

            MessagingCenter.Subscribe<HomePageViewModel, Contact>(this, "DetailContact", (sender, param) =>
            {
                Contact = param;
                //  MessagingCenter.Unsubscribe<AddPageViewModel, Contact>(this, "AddContact");
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
