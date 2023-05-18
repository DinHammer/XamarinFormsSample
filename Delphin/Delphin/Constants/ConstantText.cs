using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Constants
{
    public class ConstantText : Delphin.Abstraction.Constants.ConstantText
    {
        public class KeyMessageCenter
        {
            public const string str_news_one = nameof(str_news_one);
        }

        public class TabbedTitleName
        {
            public const string str_main = @"Главная";
            public const string str_history = @"Операции";
            public const string str_news = @"Новости";
            public const string str_yet = @"Ещё";
        }
        public class PageText
        {
            public const string lbl_text_downloading = @"Загрузка данных!!!";
            public class Main
            {
                public const string lbl_cell_title = @"Лицевой счёт";
                public const string lbl_cell_personal_account = @"ЛC";
                public const string lbl_cell_balabct = @"Баланс";
                public const string btn_cell_trsnsfer_evidance = @"Передать показания";
                public const string btn_cell_pay = @"Оплатить";

                public const string lbl_cell_pokazania_title = @"Последняя передача показаний";
                public const string lbl_cell_water_cold = @"Холодная вода";
                public const string lbl_cell_water_hot = @"Горячая вода";
                public const string lbl_cell_electro_t1 = @"Электроэнергия, Т1";
                public const string lbl_cell_electro_t2 = @"Электроэнергия, Т2";

                public const string lbl_cell_actual_news = @"Актуальные новости";
                public const string btn_cell_news_all = @"Все новости";
            }
            public class History
            {
                public const string btn_title_all_operation = @"Все операции";
                public const string btn_title_nachislenia = @"Начисления";
                public const string btn_title_oplati = @"Оплаты";
            }
            public class News
            {
                public const string lbl_left = @"Пред";
                public const string lbl_right = @"След";

                public const string title_news_one = @"Новости";
            }
            public class Request
            { }
            public class Yet
            {
                public const string lbl_licevoi_schet = @"Лицевой счёт";
                public const string lbl_chetchiki = @"Счётчики";
                public const string lbl_tarifi = @"Тарифы";
                public const string lbl_lgoti = @"Льготы";
                public const string lbl_statistics = @"Статистика";
                public const string lbl_account = @"Аккаунт";
                public const string lbl_contacts = @"Контанты";

                public class Account
                {
                    public const string title = @"Аккаунт";
                }
                public class Contacts
                {
                    public const string title = @"Контакты";
                }
                public class Counters
                {
                    public const string title = @"Счётчики";
                }
                public class PersonalAccount
                {
                    public const string title = @"Лицевой счёт";
                }
                public class Privileges
                {
                    public const string title = @"Льготы";
                }
                public class Rates
                {
                    public const string title = @"Тарифы";
                }
                public class Statistics
                {
                    public const string title = @"Статистика";
                }
            }

        }

        public class KeyNavigation
        {
            public const string keySelectedNews = nameof(keySelectedNews);
        }
        //public class ClientMessageCenter
        //{
        //    public const string NavigationPushMessage = nameof(NavigationPushMessage);
        //    public const string NavigationCoursePushMessage = nameof(NavigationCoursePushMessage);
        //    public const string NavigationDairyPushMessage = nameof(NavigationDairyPushMessage);

        //    public const string NavigationPopMessage = nameof(NavigationPopMessage);
        //    public const string NavigationCoursePopMessage = nameof(NavigationCoursePopMessage);
        //    public const string NavigationDairyPopMessage = nameof(NavigationDairyPopMessage);

        //    public const string DialogAlertMessage = nameof(DialogAlertMessage);
        //    public const string DialogSheetMessage = nameof(DialogSheetMessage);
        //    public const string DialogQuestionMessage = nameof(DialogQuestionMessage);
        //    public const string DialogEntryMessage = nameof(DialogEntryMessage);
        //    public const string DialogShowLoadingMessage = nameof(DialogShowLoadingMessage);
        //    public const string DialogHideLoadingMessage = nameof(DialogHideLoadingMessage);
        //    public const string DialogToastMessage = nameof(DialogToastMessage);
        //}
    }
}
