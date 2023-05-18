using System;
using System.Collections.Generic;
using System.Text;
using smpTools = Dlphn.Staff.SimpleTools;
using constString = Dlphn.Constants.ConstString;
using srvImage = Dlphn.Staff.Services.SrvImage;
using Xamarin.Forms;
using System.Windows.Input;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Dlphn.Models
{    

    public class MdlMeterHistoryTitle
    {
        public ImageSource imgMeter { get; private set; }
        public string StrMeterName { get; private set; }
        public string StrMeterNumber { get; private set; }

        public MdlMeterHistoryTitle()
        {
            this.StrMeterName = "Холодное водоснабжение";
            this.StrMeterNumber = "№ 01-234567";
            this.imgMeter = srvImage.Instance.GetImage(constString.KeyImage.Meter).Data;
        }
    }

    public class MdlMeterHistoryItem
    {
        public string StrValue { get; private set;  }
        public string StrDateTime { get; private set; }

        public MdlMeterHistoryItem()
        {
            this.StrValue = "20.31 м3";
            this.StrDateTime = DateTime.Now.ToString("dd MMMM yyyy");
        }
    }
}
