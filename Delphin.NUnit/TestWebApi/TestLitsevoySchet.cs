using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Delphin.NUnit.TestWebApi
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestClient), nameof(InitTestClient.FixtureParams))]
    public class TestLitsevoySchet : BaseTest
    {
        public TestLitsevoySchet(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
        }

        dtObj.ObjLsIn objIn { get; set; }

        [OneTimeSetUp]
        public async Task Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();

            /*dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);
            SimpleAssert(vTmp.IsValid);
            objIn = new dtObj.ObjLsIn(vTmp.Data);*/

            var vUserData = await prtGetUserData();
            SimpleAssert(vUserData.IsValid);

            objIn = new dtObj.ObjLsIn(vUserData.Data.strToken, vUserData.Data.strUserIs);
        }

        [Test]
        public async Task TestLsHeader()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjLsIn objIn = new dtObj.ObjLsIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Ls.GetLsHeader(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }
    }
}
