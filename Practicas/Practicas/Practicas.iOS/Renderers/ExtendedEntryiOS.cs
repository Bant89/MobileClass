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

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryiOS))]
namespace Practica.iOS.Renderers
{
    public class ExtendedEntryiOS : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null && ((ExtendedEntry)Element).HasBorder)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }

    }
}