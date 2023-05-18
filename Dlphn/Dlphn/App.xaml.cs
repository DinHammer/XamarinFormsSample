using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using constEnums = Dlphn.Constants.ConstEnums;
using constAppCenter = Dlphn.Constants.ConstAppCenter;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using srvAuth = Dlphn.Staff.Services.SrvAuth;
using srvImage = Dlphn.Staff.Services.SrvImage;
using srvDialog = Dlphn.Staff.Services.SrvDialog;
using srvAppCenter = Dlphn.Staff.Services.SrvAppCenter;
using DevDH.Magic.Abstractions;
using System.Threading.Tasks;

using dtObj = Delphin.Abstraction.DataObjects;
using System.Linq;
using Delphin.Abstraction.Constants;
using Dlphn.Constants;

namespace Dlphn
{
    public partial class App : Application
    {
        

        public enum TypeAppStart
        {
            tpRelize,
            tpDebug,
            tpDebugLogin,
            tpDebugMain,
            tpDebugHistory,
            tpDebugHistoryDetail,
            tpDebugNews,
            tpDebugYet,
            tpDebugSendMeters,
            tpTmp,
            tpDebugYetPersonalAccount,
            tpDebugYetMeters,
            tpDebugYetMeterHistory,
            tpDebugYetRates,
            tpDebugYetAccount
        }

        //bool useMock = false;
        bool useMock = true;

        public static TypeAppStart typeAppStart=TypeAppStart.tpRelize;

        private System.Threading.CancellationToken cts = new System.Threading.CancellationToken();
        public App()
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();

#if DEBUG
            //typeAppStart=TypeAppStart.tpRelize;
            //typeAppStart = TypeAppStart.tpDebugLogin;
            typeAppStart = TypeAppStart.tpDebugMain;
            //typeAppStart = TypeAppStart.tpDebugHistory;
            //typeAppStart = TypeAppStart.tpDebugHistoryDetail;
            //typeAppStart = TypeAppStart.tpDebugNews;
            //typeAppStart = TypeAppStart.tpDebugYet;
            //typeAppStart = TypeAppStart.tpTmp;
            //typeAppStart = TypeAppStart.tpDebugSendMeters;
            //typeAppStart = TypeAppStart.tpDebugYetPersonalAccount;
            //typeAppStart = TypeAppStart.tpDebugYetMeters;
            //typeAppStart = TypeAppStart.tpDebugYetMeterHistory;
            //typeAppStart = TypeAppStart.tpDebugYetRates;
            //typeAppStart = TypeAppStart.tpDebugYetAccount;
            //useMock = true;

#endif

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {

            string str_app_center_key = constAppCenter.Key;
            srvAppCenter.Init(str_app_center_key);

            srvDialog.Init(this);
            dalSrvWebApi.Init(is_mock: useMock);
            srvImage.Init();

            bool IsFirstLaunchForCurrentBuild = Xamarin.Essentials.VersionTracking.IsFirstLaunchForCurrentBuild;
            bool IsFirstLaunchForCurrentVersion = Xamarin.Essentials.VersionTracking.IsFirstLaunchForCurrentVersion;

            
            if (IsFirstLaunchForCurrentBuild || IsFirstLaunchForCurrentVersion)
            {
                srvAuth.Instance.ClearAll();
            }

            //srvAuth.Instance.ClearAll();

            switch (typeAppStart)
            {
                case TypeAppStart.tpRelize:

                    var vTRefresh = await srvAuth.Instance.GetTokenRefresh();
                    if (!vTRefresh.IsValid)
                    {
                        await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                        return;
                    }

                    var vRefresh = await dalSrvWebApi.Users.RefreshToken(new dtObj.ObjRefreshTokenIn(vTRefresh.Data), cts);
                    if (!vRefresh.IsValid)
                    {
                        await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                        return;
                    }
                    else
                    {
                        await srvAuth.Instance.SetTokens(vRefresh.Data);                        
                        //await srvAuth.Instance.SetTokenRefresh(vRefresh.Data.refresh);
                    }

                    await srvNavigation.Instance.NavigateTwo(constEnums.Pages.MainPage, true);

                    break;
                case TypeAppStart.tpDebugLogin:
                    await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                    break;
                case TypeAppStart.tpDebugMain:

                    await NavigateToWithAuth(constEnums.Pages.MainPage);                    
                    break;                
                case TypeAppStart.tpDebugHistory:
                    await NavigateToWithAuth(constEnums.Pages.HistoryPage);
                    break;
                case TypeAppStart.tpDebugHistoryDetail:
                    await NavigateToWithAuth(constEnums.Pages.HistoryDetailPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugNews:
                    await NavigateToWithAuth(constEnums.Pages.NewsPage);
                    break;
                case TypeAppStart.tpDebugYet:
                    await NavigateToWithAuth(constEnums.Pages.YetPage);
                    break;
                case TypeAppStart.tpTmp:
                    await NavigateToWithoutAuth(constEnums.Pages.TmpPage);
                    break;
                case TypeAppStart.tpDebugSendMeters:
                    await NavigateToWithAuth(constEnums.Pages.SendMetersPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugYetPersonalAccount:
                    await NavigateToWithAuth(constEnums.Pages.PersonalAccountPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugYetMeters:
                    await NavigateToWithAuth(constEnums.Pages.MetersPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugYetMeterHistory:
                    await NavigateToWithAuth(constEnums.Pages.MeterHistoryPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugYetRates:
                    await NavigateToWithAuth(constEnums.Pages.RatesPage, isNewNavigationStack: false);
                    break;
                case TypeAppStart.tpDebugYetAccount:
                    await NavigateToWithAuth(constEnums.Pages.AccountPage, isNewNavigationStack: false);
                    break;
            }

            
        }

        async Task<RequestResult> NavigateToWithoutAuth(
            constEnums.Pages page)
        {
            await srvNavigation.Instance.NavigateTwo(page, true);
            return new RequestResult();
        }


        async Task<RequestResult> NavigateToWithAuth(
            constEnums.Pages page,
            string strPhone = ConstString.KeyMoq.strPhone,
            string strPassword = ConstString.KeyMoq.strPassoword,
            bool isNewNavigationStack = true)
        {
            var vToken = await srvAuth.Instance.GetTokenRefresh();
            var vAccountId = await srvAuth.Instance.GetAccountId();

            bool isOk = vToken.IsValid && vAccountId.IsValid;


            if (!isOk)
            {
                var vLogIn = await dalSrvWebApi.Users.GetLoggIn(new dtObj.ObjLoginIn(strPhone, strPassword), cts);
                if (!vLogIn.IsValid)
                {                    
                    await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                    return new RequestResult();
                }
                else
                {
                    var vUserId = await srvAuth.Instance.SetUserId(vLogIn.Data.user);
                    var vSetToken = await srvAuth.Instance.SetTokens(vLogIn.Data.tokens);


                    var vAccId = await dalSrvWebApi.Users.GetAccounts(new dtObj.ObjUserAccountIn(vLogIn.Data.user, vLogIn.Data.tokens.access), cts);
                    if (!vAccId.IsValid)
                    {
                        await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                        return new RequestResult();
                    }

                    var vSaveAccountId = await srvAuth.Instance.SetAccountId(vAccId.Data.objects.First().tabn);

                    await srvNavigation.Instance.NavigateTwo(page, isNewNavigationStack);
                }
            }
            else
            {

                var vRefresh = await dalSrvWebApi.Users.RefreshToken(new dtObj.ObjRefreshTokenIn(vToken.Data), cts);
                if (vRefresh.IsValid)
                {
                    var vLocalRefresh = await srvAuth.Instance.SetTokens(vRefresh.Data);
                    await srvNavigation.Instance.NavigateTwo(page, isNewNavigationStack);
                    return new RequestResult();
                }
                else
                {
                    await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, true);
                    return new RequestResult();
                }
                
            }

            return new RequestResult(RequestStatus.Ok);
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
