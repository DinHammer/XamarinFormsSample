using System;
using System.Collections.Generic;
using System.Text;
using constEnum = Delphin.Constants.ConstantEnum;
using constText = Delphin.Constants.ConstantText;

namespace Delphin.Staff.Services
{
    public class ServiceText
    {
        static readonly Lazy<ServiceText> LazyInstance = new Lazy<ServiceText>(() => new ServiceText(), true);
        public static ServiceText Instance => LazyInstance.Value;
        

        public static void Init()
        {
            Instance.Initialize();
        }
        void Initialize()
        {            
        }

        public string GetTabbedPageTitle(string str_key)
        {
            if (str_key == constEnum.EnumClientMobile.Pages.Main.ToString())
            {
                return constText.TabbedTitleName.str_main;// "Главная";
            }
            else if (str_key == constEnum.EnumClientMobile.Pages.History.ToString())
            {
                return constText.TabbedTitleName.str_history;// "Операции";
            }
            else if (str_key == constEnum.EnumClientMobile.Pages.News.ToString())
            {
                return constText.TabbedTitleName.str_news;// "Новости";
            }
            else if (str_key == constEnum.EnumClientMobile.Pages.Yet.ToString())
            {
                return constText.TabbedTitleName.str_yet;// "Ещё";
            }
            else
            {
                throw new ArgumentNullException($"No tabbed title for: {str_key}");
            }
        }
    }
}
