using DevDH.Magic.Abstractions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Delphin.NUnit.Models;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using System.Threading.Tasks;
using System.Linq;

namespace Delphin.NUnit
{
    public class BaseTest : Delphin.Abstraction.Constants.BaseConstant
    {
        protected string strPhone { get; set; }
        protected string strPsw { get; set; }

        
        protected dtObj.ObjLoginOut objLoginOut { get; set; }

        protected void SimpleRequestResult(RequestResult requestResult)
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }

        protected void SimpleRequestResult<T>(RequestResult<T> requestResult) where T: class
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }

        protected void SimpleAssert(bool is_valid, string message = "")
        {            
            Assert.True(is_valid, message);            
        }

        protected CancellationToken cts;


        protected async Task<RequestResult<mdl.MdlUserData>> prtGetUserData()
        {
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vLoginOut = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);
            if (!vLoginOut.IsValid)
            {
                return new RequestResult<mdl.MdlUserData>(null, vLoginOut.Status, vLoginOut.Message);
            }

            dtObj.ObjUserAccountIn objIn = new dtObj.ObjUserAccountIn(vLoginOut.Data.user, vLoginOut.Data.tokens.access);
            var vAccountOut = await dalSrvWebApi.Users.GetAccounts(objIn, cts);

            if (!vAccountOut.IsValid)
            {
                return new RequestResult<mdl.MdlUserData>(null, vAccountOut.Status, vAccountOut.Message);
            }

            string strToken = vLoginOut.Data.tokens.access;
            string strUserId = vAccountOut.Data.objects.First().tabn;

            return new RequestResult<mdl.MdlUserData>(new mdl.MdlUserData(strToken, strUserId), statusOk);
        }

    }
}
