using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.DataObjects
{
    public class ObjLsIn : BaseObjIn
    {
        public ObjLsIn(string token, string account) : base(token, account)
        { }
        public ObjLsIn(ObjLoginOut dtOut) : base(dtOut)
        { }
    }

    public class ObjLsHeaderOut
    {
        [JsonProperty("FIO")]
        public ObjLsHeaderFio fio { get; set; }

        [JsonProperty("ls_number")]
        public ObjLsHeaderIsNumner isNumber { get; set; }
        [JsonProperty("balance")]
        public ObjLsHeaderBalance balabce { get; set; }
    }

    public class ObjLsHeaderFio
    {
        public string first_name { get; set; }
        public string middle_name { get; set; }
    }
    public class ObjLsHeaderIsNumner
    {
        public string uk_isnumber { get; set; }
    }
    public class ObjLsHeaderBalance
    {
        public string operat_saldo_e { get; set; }
    }
}
