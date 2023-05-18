using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.MeterHistory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMeterHistoryTitle : ContentView
    {
        public CellMeterHistoryTitle(mdl.MdlMeterHistoryTitle data)
        {
            InitializeComponent();
            imgMeter.Source = data.imgMeter;
            lblMeterName.Text = data.StrMeterName;
            lblMeterNumber.Text = data.StrMeterNumber;
        }
    }
}