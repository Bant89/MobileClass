using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Practica.iOS.Services;
using Practica.Services;
using UIKit;
using Xamarin.Forms.Internals;


[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationServiceiOS))]
namespace Practica.iOS.Services
{
    public class DeviceOrientationServiceiOS : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            bool isPortrait = orientation == UIInterfaceOrientation.Portrait ||
                orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}