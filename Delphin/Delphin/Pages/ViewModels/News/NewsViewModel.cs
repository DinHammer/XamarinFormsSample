using DevDH.Magic.Abstractions.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using constEnum = Delphin.Constants.ConstantEnum;
using constText = Delphin.Constants.ConstantText;
using dalSrvData = Delphin.DAL.ServiceData.SrvData;
using dalDataObjects = Delphin.Abstraction.DataObjects;
using mdls = Delphin.Models;

namespace Delphin.Pages.ViewModels.News
{
    /// <see cref="Delphin.Pages.Views.News.NewsPage">
    public class NewsViewModel : BaseViewModel
    {
        public MgcObservableCollection<object> CollectionData { get; set; }
        public ICommand cmd_go_to_news_one => MakeCommand((item) => 
        {
            var my_item = item as mdls.MdlNewsHeader;
            if (my_item == null)
            {
                return;
            }

            //ShowPopupNewsOne(my_item);

            Dictionary<string, object> navigationParams = new Dictionary<string, object>();
            navigationParams[constText.KeyNavigation.keySelectedNews] = my_item;

            NavigateTo(
                toName: constEnum.EnumClientMobile.Pages.NewsOne,
                mode: constEnum.EnumClientMobile.NavigationMode.Modal,
                navParams: navigationParams
                //ActiveTabIndex:2
                );
            //SetNavigationParams(new Dictionary<string, object> { constText.KeyNavigation.keySelectedNews, my_item });
        });// MakeNavigateToCommand(constEnum.EnumClientMobile.Pages.NewsOne, constEnum.EnumClientMobile.NavigationMode.Modal);

        public NewsViewModel()
        {
            CollectionData = new MgcObservableCollection<object>();
        }

        public async override Task OnPageAppearing()
        {
            DataSource.Clear();
            CollectionData.Clear();
            string token = "";
            var var_web_data = await dalSrvData.PageNews.GetInitData(token, CancellationToken);
            if (!var_web_data.IsValid)
            {
                return;
            }

            var var_group = var_web_data.Data.news_data.news.GroupBy(x => x.date_pub.ToString("yyyy.MM")).ToList();

            mdls.MdlNewsTitle mdlNewsTitle = null;
            mdls.MdlNewsHeader mdlNewsBody = null;
            string str_title = string.Empty;
            int count_month = var_group.Count();
            int count_days = -1;
            for (int i = 0; i < count_month; i++)
            {
                count_days = 0;
                var var_month = var_group[i];
                count_days = var_month.Count();
                var var_days = var_month.Select(x => x).ToList();
                str_title = var_days.First().date_pub.ToString("MMMM");
                mdlNewsTitle = new mdls.MdlNewsTitle(str_title);
                DataSource.Add(mdlNewsTitle);

                for (int j = 0; j < count_days; j++)
                {
                    var var_day = var_days[j];
                    mdlNewsBody = new mdls.MdlNewsHeader(var_day, cmd_go_to_news_one);
                    DataSource.Add(mdlNewsBody);
                }                
            }

            CollectionData.MgcReplaceRange(DataSource);
        }
    }
}
