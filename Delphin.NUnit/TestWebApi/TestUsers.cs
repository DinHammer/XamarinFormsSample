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
    public class TestUsers : BaseTest
    {
        public TestUsers(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
        }


        [OneTimeSetUp]
        public void Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();
        }

        [Test]        
        [TestCase("+79161234567", "ololoPishPish11")]
        public async Task TestCreate(string strPhone, string strPassword)
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            dtObj.ObjCreateIn objIn = new dtObj.ObjCreateIn(strPhone, strPassword);
            var vOut = await dalSrvWebApi.Users.GetCreate(objIn, cts);

            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestLoggin()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vOut = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);

            SimpleAssert(vOut.IsValid);
        }

        /*[Test]
        public async Task TestUserProfile()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);

            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserProfileIn objIn = new dtObj.ObjUserProfileIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Users.GetUserProfile(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }*/

        [Test]
        public async Task TestUserAccount()
        {            
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);

            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserAccountIn objIn = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);

            var vOut = await dalSrvWebApi.Users.GetAccounts(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestUserRefreshToken()
        {
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);

            SimpleAssert(vTmp.IsValid);

            dtObj.ObjRefreshTokenIn objIn = new dtObj.ObjRefreshTokenIn(vTmp.Data.tokens.refresh);

            var vOut = await dalSrvWebApi.Users.RefreshToken(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        /*[Test]
        public async Task TestUserHeader()
        {
            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);

            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserAccountIn objIn = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);

            var vAccount = await dalSrvWebApi.Users.GetAccounts(objIn, cts);
            SimpleAssert(vAccount.IsValid);


            var vOut = await dalSrvWebApi.Users.GetHeader(new dtObj.ObjUserAccountIn(vAccount.Data.objects.First().tabn, vTmp.Data.tokens.access), cts);
            SimpleAssert(vOut.IsValid);
        }*/
    }
}
