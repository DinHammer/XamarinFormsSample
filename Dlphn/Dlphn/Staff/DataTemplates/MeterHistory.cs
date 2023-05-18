using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell.MeterHistory;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtMeterHistoryTitle : DataTemplate
    {
        public DtMeterHistoryTitle(mdl.MdlMeterHistoryTitle data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterHistoryTitle data)
        {
            customCells.CellMeterHistoryTitle cell = new customCells.CellMeterHistoryTitle(data);
            return cell;
        }
    }

    public class DtMeterHistoryItem : DataTemplate
    {
        public DtMeterHistoryItem(mdl.MdlMeterHistoryItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterHistoryItem data)
        {
            customCells.CellMeterHistoryItem cell = new customCells.CellMeterHistoryItem(data);
            return cell;
        }
    }
}
