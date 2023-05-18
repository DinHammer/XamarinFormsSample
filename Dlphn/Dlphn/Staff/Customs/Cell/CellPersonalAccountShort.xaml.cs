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
    public partial class CellPersonalAccountShort : ContentView
    {
        public CellPersonalAccountShort(mdl.MdlPersonalAccountShort data)
        {
            InitializeComponent();

            lblName.Text = data.strFIO;
            lblPersonalAccount.Text = $"№ {data.strAccount}";

            btnSendData.Command = data.cmdlSendData;
            btnPay.Command = data.cmdlPay;
            
        }
    }
}