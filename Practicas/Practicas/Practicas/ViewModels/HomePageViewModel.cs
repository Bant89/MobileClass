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

        async void OnSelectItem(Contact contact)
        {
            // System.Diagnostics.Debug.WriteLine(contact.FirstName);
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage());
            MessagingCenter.Send<HomePageViewModel, Contact>(this, "DetailContact", contact);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; set; }

        public ICommand OnMoreCommand { get; set; }

        public ICommand OnDeleteCommand { get; set; }

        public HomePageViewModel()
        {
           
            MessagingCenter.Subscribe<AddPageViewModel, Contact>(this, "AddContact", (sender, param) =>
            {
                param.ID = Contacts.Count;
                Contacts.Add(param);
              //  MessagingCenter.Unsubscribe<AddPageViewModel, Contact>(this, "AddContact");

            });


            MessagingCenter.Subscribe<EditPageViewModel, Contact>(this, "EditedContact", ((sender, param) =>
            {
                for(int i = 0; i < Contacts.Count; i++)
                {
                    if(Contacts[i].ID == param.ID)
                    {
                        Contacts[i] = param;
                    }
                }
               
               // MessagingCenter.Unsubscribe<EditPageViewModel, Contact>(this, "EditedContact");
            }));

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
                    await App.Current.MainPage.Navigation.PushAsync(new EditPage());
                    MessagingCenter.Send<HomePageViewModel, Contact>(this, "EditContact", value);
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
