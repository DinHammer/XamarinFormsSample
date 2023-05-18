using System;
using System.Collections.Generic;
using Xamarin.Forms;
using viewsAuth = Dlphn.Pages.Views.Auth;
using viewHistory = Dlphn.Pages.Views.History;
using viewMain = Dlphn.Pages.Views.Main;
using viewYet = Dlphn.Pages.Views.Yet;

namespace Dlphn
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(viewsAuth.CheckCodeByPhonePage), typeof(viewsAuth.CheckCodeByPhonePage));
            Routing.RegisterRoute(nameof(viewHistory.HistoryDetailPage), typeof(viewHistory.HistoryDetailPage));
            Routing.RegisterRoute(nameof(viewMain.SendMetersPage), typeof(viewMain.SendMetersPage));

            Routing.RegisterRoute(nameof(viewYet.AccountPage), typeof(viewYet.AccountPage));
            Routing.RegisterRoute(nameof(viewYet.ContactsPage), typeof(viewYet.ContactsPage));
            Routing.RegisterRoute(nameof(viewYet.MetersPage), typeof(viewYet.MetersPage));
            Routing.RegisterRoute(nameof(viewYet.MeterHistoryPage), typeof(viewYet.MeterHistoryPage));
            Routing.RegisterRoute(nameof(viewYet.PersonalAccountPage), typeof(viewYet.PersonalAccountPage));
            Routing.RegisterRoute(nameof(viewYet.PrivilegesPage), typeof(viewYet.PrivilegesPage));
            Routing.RegisterRoute(nameof(viewYet.RatesPage), typeof(viewYet.RatesPage));
            Routing.RegisterRoute(nameof(viewYet.StatisticPage), typeof(viewYet.StatisticPage));            
        }

    }
}
