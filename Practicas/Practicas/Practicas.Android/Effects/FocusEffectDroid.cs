using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Practica.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportEffect(typeof(FocusEffectDroid), "FocusEffect")]

namespace Practica.Droid.Effects
{
    public class FocusEffectDroid : PlatformEffect
    {

        Android.Graphics.Color originalBackgroundColor = new Android.Graphics.Color(0, 0, 0, 0);
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            backgroundColor = Android.Graphics.Color.Aquamarine;
            Control.SetBackgroundColor(backgroundColor);
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                {
                    Control.SetBackgroundColor(originalBackgroundColor);
                }
                else
                {
                    Control.SetBackgroundColor(backgroundColor);
                }

            }

        }

    }
}