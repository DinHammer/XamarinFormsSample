using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.DataObjects
{

    public class ObjUkContactsOut
    {
        public ObjUkContactsOut()
        {
            //UK_Summary = new List<ObjectUkSummary>();
        }
        [JsonProperty("UK Contacts")]
        public ObjUkContacts UK_Contacts { get; set; }
    }
    public class ObjUkContacts : ObjectUkSummary
    {
        public ObjUkContacts()
        {
            uk_office = new List<ObjUkOffice>();
        }
        public string uk_legal_address { get; set; }
        public string uk_legal_name { get; set; }
        public List<ObjUkOffice> uk_office { get; set; }
    }

    public class ObjUkOffice
    {
        public string uk_office_name { get; set; }
        public string uk_office_address { get; set; }
        public string uk_office_phone { get; set; }
        public string uk_office_worked_hour { get; set; }
    }

    public class ObjUkSummaryOut
    {
        public ObjUkSummaryOut()
        {
            //UK_Summary = new List<ObjectUkSummary>();
        }
        [JsonProperty("UK Summary")]
        //public List<ObjectUkSummary> UK_Summary { get; set; }
        public ObjectUkSummary UK_Summary { get; set; }
    }
    public class ObjUkIn : BaseObjIn
    {
        public ObjUkIn(string strToken, string strAccount) : base(strToken, strAccount)
        { }
        public ObjUkIn(ObjLoginOut dtOut) : base(dtOut)
        { }
    }
    public class ObjectUkSummary
    {
        public string uk_display_name { get; set; }
        public string uk_phone { get; set; }
        public string uk_emergency_phone { get; set; }
    }

}
