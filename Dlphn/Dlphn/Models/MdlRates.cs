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
    public class MdlRatesTitle
    { }

    public class MdlRatesItem
    {
        public string StrServiceName { get; private set; }
        public string StrValue { get; private set; }
        public string StrDateTime { get; private set; }
        public string StrMeasurement { get; private set; }
        public ImageSource imgArrowUpDown { get; private set; }

        public ICommand Cmd { get; private set; }

        public MdlRatesItem()
        {
            this.StrServiceName = "Горячее водоснабжение";
            this.StrValue = "62.30 руб";
            this.StrMeasurement = "м3";
            this.StrDateTime = DateTime.Now.ToString("dd MMMM yyyy");
            this.imgArrowUpDown = srvImage.Instance.GetImage(constString.KeyImage.ArrowDown).Data;
        }

        public MdlRatesItem(ICommand cmd) : this()
        {
            this.Cmd = cmd;
        }
    }

    public class MdlRatesValue
    {
        public string StrValue { get; private set; }
        public string StrDateTime { get; private set; }

        public MdlRatesValue()
        {
            this.StrValue = "62.30 руб";
            this.StrDateTime = DateTime.Now.ToString("dd MMMM yyyy");
        }
    }
}
