using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.Constants
{
    public class ConstantText : DevDH.Magic.Abstractions.Constants.ConstantText
    {
        public class WebApi
        {
            
            public const string web_api_url = @"https:ololoPishPish.com";
            

            public class Auth
            {
                
            }

            public class News
            {
                /// <summary>
                /// получение всех горячих актуальных новостей из блока hot news (для главной страницы)
                /// </summary>
                public const string web_api_news_hot = @"/news/hot/";

                /// <summary>
                /// получение 4 последних новостей компании для главной страницы
                /// </summary>
                public const string web_api_news_latest = @"/news/latest/";
                /// <summary>
                /// Получение всех новостей компании для странцы новостей
                /// </summary>
                public const string web_api_news = @"/news/";
            }

            public class User
            {
                public const string strUserProfile = @"/users/profile/";
                public const string strUserAccount = @"/users/accounts/";
                public const string strUserTokenRefresh = @"/token/refresh/";
                public const string strUserLoggIn = @"/users/login/";
                public const string strUserCreate = @"/users/create/";
                public const string strUserHeader = @"/users/headers/";
            }

            public class PageNews
            {
                /// <summary>
                /// получение всех новостей компании для станицы новостей
                /// </summary>
                public const string web_api_news = @"/news/";
            }

            public class Kvartplata
            {
                public const string web_api_kv_ls_short = @"/kv/ls/short/";
                public const string kv_meters_latest = @"/kv/meters/latest/";
                public const string kv_flow_latest = @"/kv/flow/latest/";
                public const string kv_flow_detail = @"/kv/flow/detail/";
                public const string kv_flow = @"/kv/flow/";
                public const string kv_meters_history = @"/kv/meters/history/";
                public const string kv_meters_data = @"/kv/meters/data/";
                public const string kv_ls_detail = @"/kv/ls/detail/";
                public const string kv_ls_services = @"/kv/ls/services/";
                public const string kv_meters_detail = @"/kv/meters/detail/";
                public const string kv_tarif = @"/kv/tarif/";
            }





            /// <summary>
            /// получение логотипа, названия и телефона УК и аварийного телефона УК (для верхней брендированной панели)
            /// </summary>
            public const string web_api_uk_summary = @"/uk/summary/";

            public const string web_api_uk_contacts = @"/uk/contacts/";

            /// <summary>
            /// последние 5 операций по движению денежных средств
            /// </summary>
            public const string web_api_kv_flow_latest = @"/kv/flow/latest/";

            /// <summary>
            /// верхний левый столбец с общей информацией о ЛС ( Имя, Отчество, номера лицевых счетов, баланс)
            /// </summary>
            public const string web_api_ls_header = @"/ls/header/";

            public const string web_api_flat_short = @"/flat/short/";
        }
        

        public class ClientMessageCenter
        {
            public const string NavigationPushMessage = nameof(NavigationPushMessage);
            public const string NavigationCoursePushMessage = nameof(NavigationCoursePushMessage);
            public const string NavigationDairyPushMessage = nameof(NavigationDairyPushMessage);

            public const string NavigationPopMessage = nameof(NavigationPopMessage);
            public const string NavigationCoursePopMessage = nameof(NavigationCoursePopMessage);
            public const string NavigationDairyPopMessage = nameof(NavigationDairyPopMessage);

            public const string DialogAlertMessage = nameof(DialogAlertMessage);
            public const string DialogSheetMessage = nameof(DialogSheetMessage);
            public const string DialogQuestionMessage = nameof(DialogQuestionMessage);
            public const string DialogEntryMessage = nameof(DialogEntryMessage);
            public const string DialogShowLoadingMessage = nameof(DialogShowLoadingMessage);
            public const string DialogHideLoadingMessage = nameof(DialogHideLoadingMessage);
            public const string DialogToastMessage = nameof(DialogToastMessage);
        }
    }
}
