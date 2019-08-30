﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practicas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practicas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistryPage : ContentPage
    {
        public RegistryPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistryPageViewModel();
        }
    }
}