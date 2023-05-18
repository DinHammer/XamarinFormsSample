using System;
using System.Collections.Generic;
using System.Text;
using smpTools = Dlphn.Staff.SimpleTools;
using constString = Dlphn.Constants.ConstString;
using srvImage = Dlphn.Staff.Services.SrvImage;

namespace Dlphn.Models
{
    public class MdlPersonalAccountItem
    {
        public MdlPersonalAccountItem()
        {
            this.StrNameFull = "Петров Иван Сергеевич";
            this.StrPersonalAccountNumber = "№ 01234567";
            this.StrContractNumber = "№ АБ-012345";
            this.StrContractDateTime = new DateTime(year: 2020, month: 01, day: 01).ToString("dd MMMM yyyy");
        }

        public string StrNameFull { get; private set; }

        public string StrPersonalAccountNumber { get; private set; }
        public string StrContractNumber { get; private set; }
        public string StrContractDateTime { get; private set; }


    }

    public class MdlPersonalAccountFlat
    {
        public MdlPersonalAccountFlat()
        {
            this.StrFullAddress = "Московская обл., Подольский р - н., пос.Дубровцы, ул.Садово - Спасская, д. 201к2, кв. 154";
            this.StrAreaTotal = $"42 {constString.KeyUnitOfMeasurements.m2}";
            this.StrAreaLiving = $"24 {constString.KeyUnitOfMeasurements.m2}";
            this.imageSource = srvImage.Instance.GetImage(constString.KeyImage.House).Data;

        }

        public string StrFullAddress { get; private set; }
        public string StrAreaTotal { get; private set; }
        public string StrAreaLiving { get; private set; }
        public Xamarin.Forms.ImageSource imageSource { get; private set; }
    }

    public class MdlPersonalAccountRegisterResidentHeader
    { }

    public class MdlPersonalAccountRegisterResidentItem
    {
        public MdlPersonalAccountRegisterResidentItem()
        {
            this.StrNameFull = "Петров Иван Сергеевич";
            this.StrDateTime = new DateTime(year: 2018, month: 05, day: 5).ToString("dd MMMM yyyy");
        }

        public string StrNameFull { get; private set; }
        public string StrDateTime { get; private set; }
    }

    public class MdlPersonalAccountServicesHeader
    { }

    public class MdlPersonalAccountServicesItem
    {
        public MdlPersonalAccountServicesItem()
        {
            this.StrServiceName = "Холодное водоснабжение";
            this.StrDateTime = DateTime.Now.ToString("dd MMMM yyyy");
        }
        public string StrServiceName { get; private set; }
        public string StrDateTime { get; private set; }
    }

}
