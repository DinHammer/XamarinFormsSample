using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Constants
{
    public class ConstantEnum : Delphin.Abstraction.Constants.ConstantEnum
    {
        public class EnumClientMobile
        {

            public enum Pages
            {
                Main,
                History,
                HistoryPayment,
                Request,
                Yet     ,
                News,
                NewsOne,
                TransferReading,
                Account,
                Contacts,
                Counters,
                PersonalAccount,
                Privileges,
                Rates,
                Statistics
            }

            public enum NavigationInitialize
            {
                singlePage,
                tabbedPage,
                masterDetailPage,
                custom
            }

            public enum NavigationMode
            {
                Master,
                Normal,
                Modal,
                RootPage,
                Tabbed,
                TabbedChange,
                Custom
            }

            public enum PageState
            {
                Clean,
                Loading,
                Normal,
                NoData,
                Error,
                NoInternet
            }
        }
    }
}
