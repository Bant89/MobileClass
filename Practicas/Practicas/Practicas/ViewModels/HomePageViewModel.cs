using Practicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Practicas.View;
using System.Linq;
using System.Collections.ObjectModel;

namespace Practicas.ViewModels
{
     class HomePageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        Contact contact;
        public Contact SelectedContact {
            get { return contact; }
            set
            {
                contact = value;

                if (contact != null)
                    OnSelectItem(contact);
            }
        }

        void OnSelectItem(Contact contact)
        {
            Contact contacto = new Contact(Contacts.Count, "Xavier", "Ortiz", 8293045678);
            Contacts.Add(contacto);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; set; }

        public ICommand OnMoreCommand { get; set; }

        public ICommand OnDeleteCommand { get; set; }

        public HomePageViewModel()
        {
            this.Contacts = new ObservableCollection<Contact>
            {
                new Contact(1, "Juan", "Perez", 8291340099),
                new Contact(2, "Sofia", "Perez", 8291340099)
            };

            MessagingCenter.Subscribe<AddPageViewModel, Contact>(this, "AddContact", (sender, param) =>
            {
                Contacts.Add(param);
                MessagingCenter.Unsubscribe<AddPageViewModel, Contact>(this, "AddContact");
            });


            AddCommand = new Command(AddNavigation);
            OnDeleteCommand = new Command<Contact>(DeleteContact);
            OnMoreCommand = new Command<Contact>(MoreContact);
        }

        async void AddNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddPage());
        }

        async void MoreContact(Contact value)
        {
            var actionSheet = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel", null, $"Call +{value.Phone}", "Edit");

             switch (actionSheet)
            {
                case "Edit":
                    MessagingCenter.Send<HomePageViewModel, Contact>(this, "EditContact", value);
                    await App.Current.MainPage.Navigation.PushAsync(new EditPage());
                   break;

                case "Cancel":
                    System.Diagnostics.Debug.WriteLine("Cancel clicked");
                   break;

                default:
                    Device.OpenUri(new Uri(String.Format("tel:{0}", $"+{value.Phone}")));
                   break;
            }

        }

        public void DeleteContact(Contact value)
        { 
            Contacts.Remove(value);
        }
        
       
    }
}
