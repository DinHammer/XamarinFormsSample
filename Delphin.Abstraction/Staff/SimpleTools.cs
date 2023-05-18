using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DevDH.Magic.Abstractions;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Delphin.Abstraction.Staff
{
    public class SimpleTools : DevDH.Magic.Abstractions.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public new static SimpleTools Instance => LazyInstance.Value;

        public List<string> GetAccountList(string strIn)
        {
            string strTmp1 = strIn.Remove(0, 1);
            string strTmp2 = strTmp1.Remove(strTmp1.Length - 1, 1);
            List<string> lstOut = strTmp2.Split(",").ToList();
            return lstOut;
        }

        public RequestResult<dtObj.ObjDateTime> mgcConvertString2DateTime(string str)
        {
            DateTime dateTime;
            bool isConvert = DateTime.TryParse(str, out dateTime);

            if (isConvert)
            {
                return new RequestResult<dtObj.ObjDateTime>(new dtObj.ObjDateTime(dateTime), statusOk);
            }
            else
            {
                return new RequestResult<dtObj.ObjDateTime>(null, RequestStatus.SomethingWrong,
                    message: $"Can not convert: {str} to DateTime");
            }
        }
    }
}
