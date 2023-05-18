using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.DataObjects
{
    public class ObjUserProfileIn : BaseObjIn
    {
        public ObjUserProfileIn() { }
        public ObjUserProfileIn(ObjLoginOut dtOut) : base(dtOut) { }
    }
    public class ObjUserProfileOut
    {
        public UserProfile FIO { get; set; }
    }
    public class UserProfile
    {
        public string family { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class ObjUserAccountIn : BaseObjIn
    {
        public ObjUserAccountIn(string strUserUuid, string strToken)
        {
            this.strToken = strToken;
            this.strUserUuid = strUserUuid; ;
        }

        public string strUserUuid { get; set; }
    }

    public class ObjUserAccountOut
    {
        public ObjUserAccountOut() 
        {
            objects = new List<AccountObject>();
        }

        public List<AccountObject> objects { get; set; }
    }

    public class AccountObject
    {
        public string full_address { get; set; }
        public string tabn { get; set; }
    }

    public class ObjUserHeaderOut
    {
        public string FIO { get; set; }
        public string ls_number { get; set; }
        public string balance { get; set; }
    }

}
