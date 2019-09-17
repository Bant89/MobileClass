using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Practica.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty HasCustomColorProperty =
           BindableProperty.Create(nameof(HasCustomColor), typeof(bool), typeof(CustomEntry), false, BindingMode.TwoWay);

        public bool HasCustomColor
        {
            get { return (bool)GetValue(HasCustomColorProperty); }
            set
            {
                SetValue(HasCustomColorProperty, value);
            }
        }


    }
}
