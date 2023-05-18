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
    public partial class CellPersonalAccountRegisterResidentItem : ContentView
    {
        public CellPersonalAccountRegisterResidentItem(mdl.MdlPersonalAccountRegisterResidentItem data)
        {
            InitializeComponent();

            lblFullName.Text = data.StrNameFull;
            lblDateTime.Text = $"от {data.StrDateTime}";
        }
    }
}