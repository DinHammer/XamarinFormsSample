using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell.Meters;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtMetersTitle : DataTemplate
    {
        public DtMetersTitle(mdl.MdlMetersTitle data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersTitle data)
        {
            customCells.CellMetersTitle cell = new customCells.CellMetersTitle(data);
            return cell;
        }
    }

    public class DtMetersItem : DataTemplate
    {
        public DtMetersItem(mdl.MdlMetersItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersItem data)
        {
            customCells.CellMetersItem cell = new customCells.CellMetersItem(data);
            return cell;
        }
    }
}
