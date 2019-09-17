using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Practica.Controls;
using Practica.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryiOS))]
namespace Practica.iOS.Renderers
{
    public class CustomEntryiOS : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && ((CustomEntry)Element).HasCustomColor)
            {
               Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
            }
        }

    }
}