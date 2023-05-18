using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using viewModels = Dlphn.Pages.ViewModels;

namespace Delphin.NUnit.TestWebApi
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestClient), nameof(InitTestClient.FixtureParams))]
    public class TestNews: BaseTest
    {
        public TestNews(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
        }

        dtObj.ObjNewsIn objNewsIn { get; set; }

        [OneTimeSetUp]
        public async Task Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();


            var vUserData = await prtGetUserData();
            SimpleAssert(vUserData.IsValid);

            objNewsIn = new dtObj.ObjNewsIn(vUserData.Data.strToken, vUserData.Data.strUserIs);


            /*dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            dtObj.ObjUserAccountIn objIn = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);
            var vAccount = await dalSrvWebApi.Users.GetAccounts(objIn, cts);

            SimpleAssert(vTmp.IsValid);
            objNewsIn =  new dtObj.ObjNewsIn(
                strToken: vTmp.Data.tokens.access,
                strAccount: vAccount.Data.objects.First().tabn);*/
        }

        [Test]
        public async Task TestNewsHot()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            /*dtObj.ObjNewsIn objNewsIn = new dtObj.ObjNewsIn(
                strToken: vTmp.Data.token,
                strAccount: vTmp.Data.accountFirst);*/

            var vOut = await dalSrvWebApi.News.GetNewsHot(objNewsIn, cts);
            SimpleAssert(vOut.IsValid);

            viewModels.Main.MainViewModel viewModel = new viewModels.Main.MainViewModel(true);
            var vData = viewModel.FillNewsHot(vOut.Data);
            SimpleAssert(vData.IsValid);
        }
        [Test]
        public async Task TestNewsLatest()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            /*dtObj.ObjNewsIn objNewsIn = new dtObj.ObjNewsIn(
                strToken: vTmp.Data.token,
                strAccount: vTmp.Data.accountFirst);*/

            var vOut = await dalSrvWebApi.News.GetNewsLatest(objNewsIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestNewsAll()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);

            //SimpleAssert(vTmp.IsValid);

            /*dtObj.ObjNewsIn objNewsIn = new dtObj.ObjNewsIn(
                strToken: vTmp.Data.token,
                strAccount: vTmp.Data.accountFirst);*/

            var vOut = await dalSrvWebApi.News.GetNews(objNewsIn, cts);
            SimpleAssert(vOut.IsValid);
        }
    }
}
