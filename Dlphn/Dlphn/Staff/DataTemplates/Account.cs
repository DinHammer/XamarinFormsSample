using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell.Account;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtAccountItem : DataTemplate
    {
        public DtAccountItem(mdl.MdlAccountItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlAccountItem data)
        {
            customCells.CellAccountItem cell = new customCells.CellAccountItem(data);
            return cell;
        }
    }

    public class DtAccountChangePassword : DataTemplate
    {
        public DtAccountChangePassword(mdl.MdlAccountChangePassword data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlAccountChangePassword data)
        {
            customCells.CellAccountChangePassword cell = new customCells.CellAccountChangePassword(data);
            return cell;
        }
    }
}
