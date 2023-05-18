using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Delphin.Staff.Customs.Popup
{
    public class BasePopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        protected double prtcGetWidth() => DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        protected double prtcGetHeight() => DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
    }
}
