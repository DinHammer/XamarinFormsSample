using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.Customs.Cell.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellAccountItem : ContentView
    {
        public CellAccountItem(mdl.MdlAccountItem data)
        {
            InitializeComponent();

            lblNameFull.Text = data.StrNameFull;
            lblPhone.Text = data.StrPhone;
            lblEmail.Text = data.StrEmail;
            lblPasport.Text = data.StrPasportNumber;
            lblSnils.Text = data.StrSnils;
            tapLblExit.Command = data.Cmd;
        }
    }
}