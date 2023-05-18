using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtMetersDataHistoryDate : DataTemplate
    {
        public DtMetersDataHistoryDate(mdl.MdlMetersDataHistoryDate data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersDataHistoryDate data)
        {
            customCells.CellMeterDataHistoryDate cell = new customCells.CellMeterDataHistoryDate(data);
            return cell;
        }
    }

    public class DtMetersDataHistoryHeader : DataTemplate
    {
        public DtMetersDataHistoryHeader(mdl.MdlMetersDataHistoryHeader data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersDataHistoryHeader data)
        {
            customCells.CellMeterDataHistoryHeader cell = new customCells.CellMeterDataHistoryHeader(data);
            return cell;
        }
    }

    public class DtMetersDataHistoryValue : DataTemplate
    {
        public DtMetersDataHistoryValue(mdl.MdlMetersDataHistoryValue data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersDataHistoryValue data)
        {
            customCells.CellMeterDataHistoryValue cell = new customCells.CellMeterDataHistoryValue(data);
            return cell;
        }
    }

    public class DtMetersDataSendButton : DataTemplate
    {
        public DtMetersDataSendButton(mdl.MdlMeterDataSendButton data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterDataSendButton data)
        {
            customCells.CellMeterDataSendButton cell = new customCells.CellMeterDataSendButton(data);
            return cell;
        }
    }

    public class DtMetersDataSendHeader : DataTemplate
    {
        public DtMetersDataSendHeader(mdl.MdlMeterDataSendHeader data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterDataSendHeader data)
        {
            customCells.CellMeterDataSendHeader cell = new customCells.CellMeterDataSendHeader(data);
            return cell;
        }
    }

    public class DtMetersDataSendNo : DataTemplate
    {
        public DtMetersDataSendNo(mdl.MdlMeterDataSendNo data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterDataSendNo data)
        {
            customCells.CellMeterDataSendNo cell = new customCells.CellMeterDataSendNo(data);
            return cell;
        }
    }

    public class DtMetersDataSendYes : DataTemplate
    {
        public DtMetersDataSendYes(mdl.MdlMeterDataSendYes data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterDataSendYes data)
        {
            customCells.CellMeterDataSendYes cell = new customCells.CellMeterDataSendYes(data);
            return cell;
        }
    }




    public class DtMeterSendData : DataTemplate
    {
        public DtMeterSendData(mdl.MdlMeterSendData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterSendData data)
        {
            customCells.CellMeterSendData cell = new customCells.CellMeterSendData(data);
            return cell;
        }
    }

    public class DtMeterWaterData : DataTemplate
    {
        public DtMeterWaterData(mdl.MdlMeterWaterData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterWaterData data)
        {
            customCells.CellMeterWaterData cell = new customCells.CellMeterWaterData(data);
            return cell;
        }
    }

    public class DtMeterEnergyData : DataTemplate
    {
        public DtMeterEnergyData(mdl.MdlMeterEnergyData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMeterEnergyData data)
        {
            customCells.CellMeterEnergyData cell = new customCells.CellMeterEnergyData(data);
            return cell;
        }
    }

    public class DtYetCell : DataTemplate
    {
        public DtYetCell(mdl.MdlYetCell data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlYetCell data)
        {
            customCells.CellYet cell = new customCells.CellYet(data);
            return cell;
        }
    }

    public class DtNewsTitle : DataTemplate
    {
        public DtNewsTitle(mdl.MdlNewsTitle data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlNewsTitle data)
        {
            customCells.CellNewsTitle cell = new customCells.CellNewsTitle(data);
            return cell;
        }
    }


    public class DtNewsDataShort : DataTemplate
    {
        public DtNewsDataShort(mdl.MdlNewsDataShort data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlNewsDataShort data)
        {
            customCells.CellNewsDataShort cell = new customCells.CellNewsDataShort(data);
            return cell;
        }
    }

    public class DtError : DataTemplate
    {
        public DtError(mdl.MdlError data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlError data)
        {
            customCells.CellError cell = new customCells.CellError(data);
            return cell;
        }
    }

    public class DtHistoryData : DataTemplate
    {
        public DtHistoryData(mdl.MdlHistoryData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlHistoryData data)
        {
            customCells.CellHistoryData cell = new customCells.CellHistoryData(data);
            return cell;
        }
    }

    public class DtHistoryHeader : DataTemplate
    {
        public DtHistoryHeader(mdl.MdlHistoryHeader data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlHistoryHeader data)
        {
            customCells.CellHistoryHeader cell = new customCells.CellHistoryHeader(data);
            return cell;
        }
    }

    public class DtNewsOneData : DataTemplate
    {
        public DtNewsOneData(mdl.MdlNewsOneData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlNewsOneData data)
        {
            customCells.CellNewsOneData cell = new customCells.CellNewsOneData(data);
            return cell;
        }
    }


    public class DtNewsGoTo : DataTemplate
    {
        public DtNewsGoTo(mdl.MdlNewsGoTo data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlNewsGoTo data)
        {
            customCells.CellNewsGoTo cell = new customCells.CellNewsGoTo(data);
            return cell;
        }
    }

    public class DtMettersLatestShortHeader : DataTemplate
    {
        public DtMettersLatestShortHeader()
            : base(() => CreateView()) { }
        static View CreateView()
        {
            customCells.CellMeterLastShortHeader cell = new customCells.CellMeterLastShortHeader();
            return cell;
        }
    }

    public class DtMettersLatestShortDate : DataTemplate
    {
        public DtMettersLatestShortDate(mdl.MdlMetersLatestShortDate data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersLatestShortDate data)
        {
            customCells.CellMeterLastShortDate cell = new customCells.CellMeterLastShortDate(data);
            return cell;
        }
    }

    public class DtMettersLatestShortData : DataTemplate
    {
        public DtMettersLatestShortData(mdl.MdlMetersLatestShortData data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersLatestShortData data)
        {
            customCells.CellMeterLastShortData cell = new customCells.CellMeterLastShortData(data);
            return cell;
        }
    }

    public class DtMettersLatestShortMeterNumber : DataTemplate
    {
        public DtMettersLatestShortMeterNumber(mdl.MdlMetersLatestShortMetersNumber data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlMetersLatestShortMetersNumber data)
        {
            customCells.CellMeterLastShortMeterNumber cell = new customCells.CellMeterLastShortMeterNumber(data);
            return cell;
        }
    }


    public class DtPersonalAccountShort : DataTemplate
    {
        public DtPersonalAccountShort(mdl.MdlPersonalAccountShort data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountShort data)
        {
            customCells.CellPersonalAccountShort cell = new customCells.CellPersonalAccountShort(data);
            return cell;
        }
    }

    public class DtNewHot : DataTemplate
    {
        public DtNewHot(mdl.MdlNewHot data) 
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlNewHot data)
        {
            customCells.CellNewHot cell = new customCells.CellNewHot(data);
            return cell;
        }
    }

    public class DtEmpty : DataTemplate
    {
        public DtEmpty(): base(() => CreateView()){}
        static View CreateView()
        { 
            customCells.CellEmpty cell= new customCells.CellEmpty();
            return cell;
        }
    }

    public class DtSpace : DataTemplate
    {
        public DtSpace() : base(() => CreateView()) { }
        static View CreateView()
        {
            customCells.CellSpace cell = new customCells.CellSpace();
            return cell;
        }
    }
}
