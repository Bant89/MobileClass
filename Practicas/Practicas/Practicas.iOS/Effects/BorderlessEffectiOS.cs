using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using Practica.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Practica")]
[assembly: ExportEffect(typeof(BorderlessEffectiOS), "BorderLessEffect")]

namespace Practica.iOS.Effects
{
    public class BorderlessEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            var control = Control as UITextField;
            control.BorderStyle = UITextBorderStyle.None;
        }

        protected override void OnDetached()
        {
        }
    }
}