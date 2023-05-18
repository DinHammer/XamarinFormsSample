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
    public partial class CellHistoryData : ContentView
    {
        public CellHistoryData(mdl.MdlHistoryData data)
        {
            InitializeComponent();

            lblDayAndMonth.Text = data.strDayAndMonth;
            lblYear.Text= data.strYear;

            lblOperationSaldo.Text= data.strOperationSaldo;
            lblOperationSaldo.Style = data.StyleLbl;

            lblOperationSum.Text= data.strOperationSum;
            lblOperationSum.Style = data.StyleLbl;

            tapGesture.Command = data.cmdGoTo;
            tapGesture.CommandParameter = data.cashFlow;

            img.Source = data.imageSource;            
        }
    }
}