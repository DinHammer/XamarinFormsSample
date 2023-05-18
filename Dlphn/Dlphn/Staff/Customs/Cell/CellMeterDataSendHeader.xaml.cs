using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMeterDataSendHeader : ContentView
    {
        public CellMeterDataSendHeader(mdl.MdlMeterDataSendHeader data)
        {
            InitializeComponent();

            lblMeterType.Text = data.StrMeterType;
            lblMeterNumber.Text = data.StrMeterName;
            lblMeterDescription.Text = data.StrMeterDescription;
        }
    }
}