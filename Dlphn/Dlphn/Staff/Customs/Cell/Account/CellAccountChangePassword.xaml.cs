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
    public partial class CellAccountChangePassword : ContentView
    {
        public CellAccountChangePassword(mdl.MdlAccountChangePassword data)
        {
            InitializeComponent();

            btnSend.Command = data.Cmd;
        }
    }
}