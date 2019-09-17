using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using Practica.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(FocusEffectiOS), "FocusEffect")]

namespace Practica.iOS.Effects
{
    public class FocusEffectiOS : PlatformEffect
    {
        UIColor backgroundColor;

        protected override void OnAttached()
        {
            Control.BackgroundColor = UIColor.FromRGB(204,152,255);
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == "IsFocused")
            {
                if(Control.BackgroundColor == backgroundColor)
                {
                    Control.BackgroundColor = UIColor.White;
                }
                else
                {
                    Control.BackgroundColor = backgroundColor;
                }
            }

        }

    }
}