using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Practica.Controls;
using Practica.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryDroid))]
namespace Practica.Droid.Renderers
{
    public class ExtendedEntryDroid : EntryRenderer
    {

        public ExtendedEntryDroid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null && ((ExtendedEntry)Element).HasBorder)
            {
                Control.SetBackground(null);
            }
        }

    }
}