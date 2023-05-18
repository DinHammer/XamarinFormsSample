using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.PersonalAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellPersonalAccountItem : ContentView
    {
        public CellPersonalAccountItem(mdl.MdlPersonalAccountItem data)
        {
            InitializeComponent();

            lblNameFull.Text = data.StrNameFull;
            lblPersonalAccount.Text = data.StrPersonalAccountNumber;
            lblContractValue.Text = data.StrContractNumber;
            lblContractDateTime.Text = $" от {data.StrContractDateTime}";
        }
    }
}