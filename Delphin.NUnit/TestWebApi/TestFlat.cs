using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Delphin.NUnit.TestWebApi
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestClient), nameof(InitTestClient.FixtureParams))]
    public class TestFlat: BaseTest
    {
        public TestFlat(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
        }

        dtObj.ObjFlatIn objIn { get; set; }

        [OneTimeSetUp]
        public async Task Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();


            var vUserData = await prtGetUserData();
            SimpleAssert(vUserData.IsValid);

            objIn = new dtObj.ObjFlatIn(vUserData.Data.strToken, vUserData.Data.strUserIs);

            /*dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserAccountIn objAccountIn = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);
            var vAccount = await dalSrvWebApi.Users.GetAccounts(objAccountIn, cts);*/



        }

        [Test]
        public async Task TestFlatShort()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjFlatIn objIn = new dtObj.ObjFlatIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Flat.GetFlatShort(objIn,cts);
            SimpleAssert(vOut.IsValid);
        }
    }
}
