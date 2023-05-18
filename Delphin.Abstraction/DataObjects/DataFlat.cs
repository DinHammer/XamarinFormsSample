using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.DataObjects
{
    public class ObjFlatIn : BaseObjIn
    {
        public ObjFlatIn(string token, string account) : base(token, account)
        { }
        public ObjFlatIn(ObjLoginOut dtOut) : base(dtOut)
        { }
    }

    public class ObjFlatShortOut
    {
        [JsonProperty("FlatShortData")]
        public ObjFlatShort objFlatShort { get; set; }
    }
    public class ObjFlatShort
    {
        public string flat_total_square { get; set; }
        public string flat_live_square { get; set; }
    }
}
