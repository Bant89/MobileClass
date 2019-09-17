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
using Practica.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Practica")]
[assembly: ExportEffect(typeof(BorderlesEffectDroid), "BorderLessEffect")]

namespace Practica.Droid.Effects
{
    public class BorderlesEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.SetBackground(null);
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }



    }
}