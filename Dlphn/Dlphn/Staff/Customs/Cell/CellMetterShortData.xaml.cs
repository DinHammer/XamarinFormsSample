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
    public partial class CellMetterShortData : ContentView
    {
        public CellMetterShortData( mdl.MdlMettersShortData data)
        {
            InitializeComponent();

            lblDateTime.Text = data.strDateTime;

            lblWaterColdName.Text = data.strWaterColdName;
            lblWaterColdValue.Text = data.strWaterColdValue;
            lblWaterHotName.Text = data.strWaterHotName;
            lblWaterHotValue.Text = data.strWaterHotValue;
            lblElectroT1Name.Text = data.strEnergyT1Name;
            lblElectroT1Value.Text = data.strEnergyT1Value;
            lblElectroT2Name.Text = data.strEnergyT2Name;
            lblElectroT2Value.Text=data.strEnergyT2Value;
            //lblPokazanieName.Text = data.strPokazanieName;
            //lblPokazanieValue.Text = data.strPokazanieValue;
        }
    }
}