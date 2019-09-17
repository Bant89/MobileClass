using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Practica.Controls
{
    public class ExtendedEntry : Entry
    {
        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(ExtendedEntry), false, BindingMode.TwoWay);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set
            {
                SetValue(HasBorderProperty, value);
            }
        }


    }
}
