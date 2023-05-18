
using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using serviceTranslateText = Delphin.Staff.Services.ServiceTextTranslate;
using constEnums = Delphin.Constants.ConstantEnum;
using constText = Delphin.Constants.ConstantText;
using keyMessageCenter = Delphin.Constants.ConstantText.KeyMessageCenter;
using services = Delphin.Staff.Services;
using DevDH.Magic.Abstractions.Magic;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using mdls = Delphin.Models;
using System.Threading.Tasks;

namespace Delphin.Pages.ViewModels
{
    public class BaseViewModel : CoreViewModel
    {
        public void Action_function(string title)
        {
            constEnums.EnumClientMobile.Pages pageTo = GetEnumPageByString(title);
            int index = GetTabSelected(pageTo);
            NavigateTo(pageTo, NavigationParams,mode: constEnums.EnumClientMobile.NavigationMode.TabbedChange,ActiveTabIndex: index);
        }

        constEnums.EnumClientMobile.Pages GetEnumPageByString(string str)// => (constEnums.EnumClientMobile.Pages)Enum.Parse(typeof(constEnums.EnumClientMobile.Pages), str);
        {
            if (str == constText.TabbedTitleName.str_history)
            {
                return constEnums.EnumClientMobile.Pages.History;
            }
            else if (str == constText.TabbedTitleName.str_news)
            {
                return constEnums.EnumClientMobile.Pages.News;
            }
            else if (str == constText.TabbedTitleName.str_yet)
            {
                return constEnums.EnumClientMobile.Pages.Yet;
            }
            else
            {
                return constEnums.EnumClientMobile.Pages.Main;
            }

        }
        protected int GetTabSelected(constEnums.EnumClientMobile.Pages pages)
        {
            switch (pages)
            {
                case constEnums.EnumClientMobile.Pages.History:
                    return 1;
                case constEnums.EnumClientMobile.Pages.News:
                    return 2;
                case constEnums.EnumClientMobile.Pages.Yet:
                    return 3;
                default:
                    return 0;
            }
        }
        
        public BaseViewModel()
        {
            DataSource = new List<object>();
            //eventhandler += BaseViewModel_eventhandler;
        }

        private void BaseViewModel_eventhandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected readonly IList<object> DataSource;

        private object pageState = constEnums.EnumClientMobile.PageState.Loading;
        public object PageState
        {
            get => Get(pageState);
            set => Set(value);
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get => Get(isBusy);
            set => Set(value);
        }

        public MgcObservableCollection<object> PageDataCollection { get; set; }

        protected RequestResult<string> TranslateThis(string text_key)
            => serviceTranslateText.Instance.GetTextByTextKey(text_key);

        public ICommand CommndChangedTab
        {
            set { }
            get
            {
                return new Command(() =>
                {
                    //NavigateTo(constEnums.EnumClientMobile.Pages.Day);
                });
            }
        }

        //public event EventHandler eventhandler;
        protected static Task ShowPopupNewsOne(mdls.MdlNewsHeader data)
        {
            var tcs = new TaskCompletionSource<bool>();
            services.MessageBus.SendMessage(keyMessageCenter.str_news_one,
                new services.DlgShowNewsOneInfo
                {
                    mdlNewsHeader=data                    
                });
            return tcs.Task;
        }

    }
}
