using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using customCells = Dlphn.Staff.Customs.Cell.PersonalAccount;
using mdl = Dlphn.Models;

namespace Dlphn.Staff.DataTemplates
{
    public class DtPersonalAccountItem : DataTemplate
    {
        public DtPersonalAccountItem(mdl.MdlPersonalAccountItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountItem data)
        {
            customCells.CellPersonalAccountItem cell = new customCells.CellPersonalAccountItem(data);
            return cell;
        }
    }

    public class DtPersonalAccountFlat : DataTemplate
    {
        public DtPersonalAccountFlat(mdl.MdlPersonalAccountFlat data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountFlat data)
        {
            customCells.CellPersonalAccountFlat cell = new customCells.CellPersonalAccountFlat(data);
            return cell;
        }
    }

    public class DtPersonalAccountRegisterResidentHeader : DataTemplate
    {
        public DtPersonalAccountRegisterResidentHeader(mdl.MdlPersonalAccountRegisterResidentHeader data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountRegisterResidentHeader data)
        {
            customCells.CellPersonalAccountRegisterResidentHeader cell = new customCells.CellPersonalAccountRegisterResidentHeader(data);
            return cell;
        }
    }

    public class DtPersonalAccountRegisterResidentItem : DataTemplate
    {
        public DtPersonalAccountRegisterResidentItem(mdl.MdlPersonalAccountRegisterResidentItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountRegisterResidentItem data)
        {
            customCells.CellPersonalAccountRegisterResidentItem cell = new customCells.CellPersonalAccountRegisterResidentItem(data);
            return cell;
        }
    }

    public class DtPersonalAccountServicesHeader : DataTemplate
    {
        public DtPersonalAccountServicesHeader(mdl.MdlPersonalAccountServicesHeader data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountServicesHeader data)
        {
            customCells.CellPersonalAccountServicesHeader cell = new customCells.CellPersonalAccountServicesHeader(data);
            return cell;
        }
    }

    public class DtPersonalAccountServicesItem : DataTemplate
    {
        public DtPersonalAccountServicesItem(mdl.MdlPersonalAccountServicesItem data)
            : base(() => CreateView(data)) { }
        static View CreateView(mdl.MdlPersonalAccountServicesItem data)
        {
            customCells.CellPersonalAccountServicesItem cell = new customCells.CellPersonalAccountServicesItem(data);
            return cell;
        }
    }
}
