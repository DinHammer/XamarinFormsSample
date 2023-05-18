using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smpTools = Delphin.Abstraction.Staff.SimpleTools;

namespace Delphin.Abstraction.DataObjects
{

    public class ObjDateTime
    {
        private DateTime _dateTime;
        public ObjDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime DateTime => _dateTime;
    }
    
    public class ObjectCashFlowData
    {
        public ObjectCashFlowData()
        {
            CashFlow = new List<ObjectCashFlow>();
        }
        public List<ObjectCashFlow> CashFlow { get; set; }
    }
    public class ObjectCashFlow
    {
        public string type { get; set; }
        public DateTime date { get; set; }
        public float operations_sum { get; set; }
        public float operat_saldo_e { get; set; }
    }

    

    
    public class ObjectNewsData
    {
        public ObjectNewsData()
        {
            news = new List<ObjectNews>();
        }
        public List<ObjectNews> news { get; set; }
    }

    public class ObjNewsIn : BaseObjIn
    {
        //public ObjNewsIn() { }
        public ObjNewsIn(string strToken, string strAccount) : base(strToken, strAccount)
        { }
        
    }
    public class ObjNewsHotOut
    {
        public ObjNewsHotOut()
        {
            hotnews = new List<ObjectNews>();
        }
        public List<ObjectNews> hotnews { get; set; }
        //public ObjectNews hotnews { get; set; }
    }
    public class ObjNewsLatestOut
    {
        public ObjNewsLatestOut()
        {
            latestnews = new List<ObjectNews>();
        }
        public List<ObjectNews> latestnews { get; set; }
        //public ObjectNews hotnews { get; set; }

        #region Methods
        public bool IsValid()
        {
            bool output = false;

            if (latestnews?.Count > 0)
            {
                output = true;
            }

            return output;
        }
        #endregion
    }
    public class ObjNewsOut
    {
        public ObjNewsOut()
        {
            news = new List<ObjectNews>();
        }
        public List<ObjectNews> news { get; set; }
    }

    public class ObjectNews
    {
        public string title { get; set; }
        public string uk_uuid { get; set; }
        public string slug { get; set; }
        public DateTime date_pub { get; set; }
        public bool is_hot { get; set; }
        public bool is_push { get; set; }
        public string body { get; set; }
    }

    

    public abstract class BaseObjIn
    {
        public BaseObjIn() { }
        public BaseObjIn(ObjLoginOut dtOut): this(dtOut.tokens.access, dtOut.user)
        { }
        public BaseObjIn(string strToken, string strAccount)
        {
            this.strToken = strToken;
            this.strAccount = strAccount;
        }
        public string strAccount { get; set; }

        public string strToken { get; set; }
    }
}
