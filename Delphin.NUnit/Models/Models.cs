using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.NUnit.Models
{
    public class MdlUserData
    {
        public MdlUserData(string strToken, string strUserId)
        {
            this.strToken = strToken;
            this.strUserIs = strUserId;
        }

        public string strToken { get; set; }
        public string strUserIs { get; set; }

    }
}
