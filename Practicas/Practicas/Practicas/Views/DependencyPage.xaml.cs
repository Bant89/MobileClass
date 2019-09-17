using Practica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DependencyPage : ContentPage
    {
        public DependencyPage()
        {
            InitializeComponent();
            BindingContext = new DependencyPageViewModel();
        }
    }
}