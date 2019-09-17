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

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryDroid))]
namespace Practica.Droid.Renderers
{
    public class CustomEntryDroid : EntryRenderer
    {

        public CustomEntryDroid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && ((CustomEntry)Element).HasCustomColor)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Red);
            }
        }


    }
}