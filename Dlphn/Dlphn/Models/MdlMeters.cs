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
    public class MdlMetersTitle
    { }

    public class MdlMetersItem
    {        
        public ImageSource imgMeter { get; private set; }
        public ImageSource imgVerify { get; private set; }
        public ImageSource imgArrowRight { get; private set; }

        public string StrMetersName { get; private set; }
        public string StrMetersNumber { get; private set; }
        public string StrDateTimeInstalled { get; private set; }
        public string StrDateTimeFinished { get; private set; }
        public ICommand CmdButton { get; private set; }
        
        public dtObj.MetersDetail Data { get; private set; }

        public MdlMetersItem()
        {
            this.imgMeter = srvImage.Instance.GetImage(constString.KeyImage.Meter).Data;
            this.imgVerify = srvImage.Instance.GetImage(constString.KeyImage.VerifiedYes).Data;
            this.imgArrowRight= srvImage.Instance.GetImage(constString.KeyImage.ArrowRight).Data;

            this.StrMetersName = "Холодное водоснабжение";
            this.StrMetersNumber = "№ 01-234567";
            this.StrDateTimeInstalled = DateTime.Now.ToString("dd MMMM yyyy");
            this.StrDateTimeFinished = DateTime.Now.ToString("dd MMMM yyyy");
        }
        public MdlMetersItem(dtObj.MetersDetail metersDetail, ICommand cmdButton): this()
        {
            this.CmdButton = cmdButton;
            this.Data= metersDetail;
        }



    }
}
