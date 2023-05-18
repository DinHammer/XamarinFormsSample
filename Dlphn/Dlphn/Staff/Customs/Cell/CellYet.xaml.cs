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
    public partial class CellYet : ContentView
    {
        public CellYet(mdl.MdlYetCell data)
        {
            InitializeComponent();

            img.Source = data.ImgSource;
            lbl.Text = data.StrText;
            tapGesture.Command = data.Cmd;
            tapGesture.CommandParameter = data;
        }
    }
}