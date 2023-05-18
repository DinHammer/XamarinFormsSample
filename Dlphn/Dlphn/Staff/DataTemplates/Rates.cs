using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell.Rates;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtRatesTitle : DataTemplate
    {
        public DtRatesTitle(mdl.MdlRatesTitle data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlRatesTitle data)
        {
            customCells.CellRatesTitle cell = new customCells.CellRatesTitle(data);
            return cell;
        }
    }

    public class DtRatesItem : DataTemplate
    {
        public DtRatesItem(mdl.MdlRatesItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlRatesItem data)
        {
            customCells.CellRatesItem cell = new customCells.CellRatesItem(data);
            return cell;
        }
    }

    public class DtRatesValue : DataTemplate
    {
        public DtRatesValue(mdl.MdlRatesValue data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlRatesValue data)
        {
            customCells.CellRatesValue cell = new customCells.CellRatesValue(data);
            return cell;
        }
    }
}
