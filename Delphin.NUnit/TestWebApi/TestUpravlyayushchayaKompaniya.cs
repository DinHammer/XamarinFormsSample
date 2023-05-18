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
    public class TestUpravlyayushchayaKompaniya : BaseTest
    {
        public TestUpravlyayushchayaKompaniya(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
        }

        dtObj.ObjUkIn objIn { get; set; }

        [OneTimeSetUp]
        public async Task Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();


            var vUserData = await prtGetUserData();
            SimpleAssert(vUserData.IsValid);

            objIn = new dtObj.ObjUkIn(vUserData.Data.strToken, vUserData.Data.strUserIs);



            /*dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserAccountIn objAccount = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);
            var vAccount = await dalSrvWebApi.Users.GetAccounts(objAccount, cts);

            SimpleAssert(vTmp.IsValid);
            objIn = new dtObj.ObjUkIn();
            objIn.strToken = vTmp.Data.tokens.access;
            objIn.strAccount = vAccount.Data.objects.First().tabn;*/

            //objIn = new dtObj.ObjUkIn(vTmp.Data);
        }

        [Test]
        public async Task TestUkSummary()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjUkIn objIn = new dtObj.ObjUkIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Uk.GetUkSummary(objIn,cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestUkContacts()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjUkIn objIn = new dtObj.ObjUkIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Uk.GetUkContacts(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }
    }
}
