using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.Meters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMetersItem : ContentView
    {
        public CellMetersItem(mdl.MdlMetersItem data)
        {
            InitializeComponent();

            imgMeter.Source = data.imgMeter;
            imgVerify.Source = data.imgVerify;
            imgArrowRight.Source = data.imgArrowRight;

            btn.Command = data.CmdButton;
            btn.CommandParameter = data.Data;

            lblMeterName.Text = data.StrMetersName;
            lblMeterNumber.Text = data.StrMetersNumber;
            lblDateTimeInstalled.Text = data.StrDateTimeInstalled;
            lblDateTimeFinished.Text = data.StrDateTimeFinished;
        }
    }
}