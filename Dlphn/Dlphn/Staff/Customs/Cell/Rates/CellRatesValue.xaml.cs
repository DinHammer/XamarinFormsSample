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
    public partial class CellRatesValue : ContentView
    {
        public CellRatesValue(mdl.MdlRatesValue data)
        {
            InitializeComponent();

            lblValue.Text = data.StrValue;
            lblDateTime.Text = $"от {data.StrDateTime}";
        }
    }
}