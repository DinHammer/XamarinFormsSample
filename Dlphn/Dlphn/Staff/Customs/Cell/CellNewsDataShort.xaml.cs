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
	public partial class CellNewsDataShort : ContentView
	{
		public CellNewsDataShort (mdl.MdlNewsDataShort data)
		{
			InitializeComponent ();

			lblDate.Text = data.strDate;
			lblText.Text = data.strText;

			tap.Command = data.CmdTap;
			tap.CommandParameter = data.context;
		}
	}
}