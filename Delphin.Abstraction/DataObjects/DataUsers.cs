using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smpTools = Delphin.Abstraction.Staff.SimpleTools;

namespace Delphin.Abstraction.DataObjects
{

    public class ObjRefreshTokenIn
    {
        public ObjRefreshTokenIn(string strToken)
        {
            this.refresh = strToken;
        }

        //[JsonProperty("refresh")]
        public string refresh { get; set; }
    }

    public class ObjRefreshTokenOut
    {
        public ObjRefreshTokenOut(string refresh, string access)
        {
            this.refresh = refresh;
            this.access = access;
        }
        public string refresh { get; set; }
        public string access { get; set; }
    }
        

    public class ObjCreateIn
    {
        public ObjCreateIn() { }
        public ObjCreateIn(string strPhone, string strPassword)
        {
            this.phone = strPhone;
            this.password = strPassword;
        }
        public string phone { get; set; }
        public string password { get; set; }
    }

    public class ObjCreateOut
    { }

    public class ObjLoginIn
    {
        public ObjLoginIn() { }
        public ObjLoginIn(string phone, string password)
        {
            this.phone = phone;
            this.password = password;
        }
        public string phone { get; set; }
        public string password { get; set; }
    }
    public class ObjLoginOut
    {


        /*public string success { get; set; }
        public string status_code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public string accounts { get; set; }
        public List<string> lstAccounts
        => smpTools.Instance.GetAccountList(accounts);
        public string accountFirst
            => lstAccounts.First();*/

        public string user { get; set; }
        public ObjTokenOut tokens {get;set;}
    }

    public class ObjTokenOut
    {
        public string refresh { get; set; }
        public string access { get; set; }
    }
}
