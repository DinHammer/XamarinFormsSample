using System;
using System.Collections.Generic;
using System.Text;

namespace Dlphn.Constants
{
    public class ConstAppCenter
    {
        public static string Key => GetKey();

        private static string GetKey() => Xamarin.Forms.Device.RuntimePlatform switch
        {
            Xamarin.Forms.Device.Android => "OloloAndroid",
            //Xamarin.Forms.Device.iOS => "OloloIos",
            _ => throw new NotSupportedException()
        };
    }
}
