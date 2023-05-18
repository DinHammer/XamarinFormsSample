using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using AstroPlaner.Services;
//using AstroPlaner.Views;
using services = Delphin.Staff.Services;
using constEnumClient = Delphin.Constants.ConstantEnum.EnumClientMobile;
using constEnum = Delphin.Constants.ConstantEnum;
using System.Collections.Generic;
//using dalSrveWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
//using dalSrvData = Delphin.DAL.ServiceData.SrvData;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using simpleTools = Delphin.Staff.SimpleTools;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;// AstroPlaner.DAL.ServiceSqlite.SrvSqlite;
using dalSrvData = Delphin.DAL.ServiceData.SrvData;

namespace Delphin
{
    public partial class App : Application
    {
        Dictionary<string, object> navParams;
        bool is_moq = true;
        public App()
        {
            navParams = new Dictionary<string, object>();
            //InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new Pages.Views.Main.DefaultPage();
            //hui
        }

        protected override void OnStart()
        {
            AppCenter.Start("beb08ea3-4ca2-4d88-a532-df338d0b42d2",
                   typeof(Analytics), 
                   typeof(Crashes));

            InitializeComponent();

            services.ServiceImage.Init();
            services.ServiceText.Init();
            services.ServiceDialog.Init(this);
            services.ServiceNavigation.Init(constEnumClient.Pages.Main, navParams);
            
            //dalSrveWebApi.Init(constEnum.TypeWebApi.typeDebug);
            //dalSrvData.Init();

            dalSrvWebApi.Init(is_mock: is_moq);
            dalSrvData.Init();
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
