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
    public partial class CellPersonalAccountFlat : ContentView
    {
        public CellPersonalAccountFlat(mdl.MdlPersonalAccountFlat data)
        {
            InitializeComponent();

            imgHouse.Source = data.imageSource;
            lblAdressFull.Text = data.StrFullAddress;
            lblAreaTotal.Text = data.StrAreaTotal;
            lblAreaLiving.Text = data.StrAreaLiving;
        }
    }
}