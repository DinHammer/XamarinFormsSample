using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using smpTools = Dlphn.Staff.SimpleTools;
using viewModels = Dlphn.Pages.ViewModels;

namespace Delphin.NUnit.TestWebApi
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestClient), nameof(InitTestClient.FixtureParams))]
    public class TestKvartplata : BaseTest
    {
        public TestKvartplata(string key, string strPhone, string strPsw)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;            
        }

        dtObj.ObjKvIn objIn { get; set; }

        [OneTimeSetUp]
        public async Task Init()
        {
            cts = new System.Threading.CancellationToken();
            dalSrvWebApi.Init();

            var vUserData = await prtGetUserData();
            SimpleAssert(vUserData.IsValid);

            objIn = new dtObj.ObjKvIn(vUserData.Data.strToken, vUserData.Data.strUserIs);

            Dlphn.App app = new Dlphn.App();

            /*dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cts);
            SimpleAssert(vTmp.IsValid);

            dtObj.ObjUserAccountIn objAccountIn = new dtObj.ObjUserAccountIn(vTmp.Data.user, vTmp.Data.tokens.access);
            var vAccount = await dalSrvWebApi.Users.GetAccounts(objAccountIn, cts);

            objIn = new dtObj.ObjKvIn(vTmp.Data.tokens.access, vAccount.Data.objects.First().tabn);*/
        }

        [Test]
        public async Task TestKvLsShort()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn("+79261879302", "test123");
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvLsShort(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestKvMetersLatest()
        {            
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);

            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);
            var vOut = await dalSrvWebApi.Kv.GetKvMetersLatest(objIn, cts);
            SimpleAssert(vOut.IsValid);

            viewModels.Main.MainViewModel viewModel = new viewModels.Main.MainViewModel(true);
            var vData = viewModel.FillMetersLatestCells(vOut.Data.lstMetersData);
            SimpleAssert(vData.IsValid);

            
        }

        [Test]
        public async Task TestKvFlowLatest()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvFlowLatest(objIn, cts);
            SimpleAssert(vOut.IsValid);

            /*viewModels.History.HistoryViewModel viewModel = new viewModels.History.HistoryViewModel(true);
            var vData = viewModel.FillKvFlowLatest(vOut.Data);
            SimpleAssert(vData.IsValid);*/
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task TestKvFlowDetail(int id)
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            dtObj.ObjKvFlowDetailIn dataIn = new dtObj.ObjKvFlowDetailIn(id, objIn.strToken);
            var vOut = await dalSrvWebApi.Kv.GetKvFlowDetails(dataIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestKvFlow()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvFlow(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestKvMetersHistory()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vMetersData = await dalSrvWebApi.Kv.GetKvMetersDetail(objIn,cts);
            SimpleAssert(vMetersData.IsValid);

            int iMeterId = vMetersData.Data.lstMeterDetail.First().id;
            dtObj.ObjKvMetersIn objMetersIn = new dtObj.ObjKvMetersIn(objIn.strToken, iMeterId.ToString());
            var vOut = await dalSrvWebApi.Kv.GetKvMetersHistory(objMetersIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestKvMetersData()
        {
            List<object> dataSource = new List<object>();

            var vOut = await dalSrvWebApi.Kv.GetKvMetersData(objIn, cts);
            SimpleAssert(vOut.IsValid);


            viewModels.Main.SendMetersViewModel viewModel = new viewModels.Main.SendMetersViewModel();
            var vData = viewModel.FillCells(vOut.Data.lstMetersData);

            SimpleAssert(vData.IsValid);            

        }

        [Test]
        public async Task TestKvLsDetail()
        {
            

            var vOut = await dalSrvWebApi.Kv.GetKvLsDetail(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }
        [Test]
        public async Task TestKvLsServices()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvLsServices(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }
        [Test]
        public async Task TestKvMetersDetail()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvMetersDetail(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestKvTarif()
        {
            //dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(strPhone, strPsw);
            //var vTmp = await dalSrvWebApi.Users.GetLoggIn(objLoginIn);
            //SimpleAssert(vTmp.IsValid);
            //dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vTmp.Data);

            var vOut = await dalSrvWebApi.Kv.GetKvTarif(objIn, cts);
            SimpleAssert(vOut.IsValid);
        }
    }
}
