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
    public partial class CellRatesTitle : ContentView
    {
        public CellRatesTitle(mdl.MdlRatesTitle data)
        {
            InitializeComponent();
        }
    }
}