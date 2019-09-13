using Practicas.Models;
using Practicas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Practicas.ViewModels
{
    class SearchPageViewModel : IApiService
    {

        ApiService ApiService = new ApiService();

        public Comment Resultados = new Comment();
        public ICommand GetComments { get; set; }

        public ObservableCollection<Snippet> Snippets { get; set; } = new ObservableCollection<Snippet>();

        public Task<Comment> GetGomments()
        {
            throw new NotImplementedException();
        }

        public SearchPageViewModel()
        {

            GetComments = new Command(async () => {
                try
                {
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        Resultados = await ApiService.GetGomments();
                        for (int i = 0; i < Resultados.items.Count; i++)
                        {
                            Snippets.Add(Resultados.items[i].snippet);
                        }

                        System.Diagnostics.Debug.WriteLine("Probando");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection at the moment", "Ok");
                        System.Diagnostics.Debug.WriteLine("No internet connection");
                    }


                }
                catch { }
                 
            });

        }

    }



}
