using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;
using controls = Dlphn.Staff.Customs.Controls;

namespace Dlphn.Staff.Customs.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellMeterEnergyData : ContentView
    {
        public CellMeterEnergyData(mdl.MdlMeterEnergyData data)
        {
            InitializeComponent();

            this.BindingContext= data;

            meterData.SetBinding(controls.MeterDataView.TextEntryProperty, nameof(data.StrEnergeyValue));
        }
    }
}