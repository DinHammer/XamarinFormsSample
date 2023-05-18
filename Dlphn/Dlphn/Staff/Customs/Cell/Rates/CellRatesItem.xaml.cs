using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.Rates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellRatesItem : ContentView
    {
        public CellRatesItem(mdl.MdlRatesItem data)
        {
            InitializeComponent();

            lblServiceName.Text = data.StrServiceName;
            lblMeasurement.Text = data.StrMeasurement;
            lblValue.Text = data.StrValue;
            lblDateTime.Text = $"от {data.StrDateTime}";
            imgArrowUpDown.Source = data.imgArrowUpDown;

            tapGesture.Command = data.Cmd;
        }
    }
}