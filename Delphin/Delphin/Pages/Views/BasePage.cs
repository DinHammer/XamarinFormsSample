using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Delphin.Pages.Views
{
    public class BasePage : CorePage
    {
        protected double prtcGetWidth() => DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        protected double prtcGetHeight() => DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

    }
}
