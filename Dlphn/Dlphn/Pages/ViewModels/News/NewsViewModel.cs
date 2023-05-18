using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using srvAuth = Dlphn.Staff.Services.SrvAuth;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using System.Linq;
using System.Windows.Input;
using System.Globalization;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.News
{
    /// <see cref="Dlphn.Pages.Views.News.NewsPage.NewsPage"/>
    public class NewsViewModel: BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public NewsViewModel() : base(constEnum.Pages.NewsPage)
        {
            
        }
        #endregion

        #region Methods
        public override async Task OnPageAppearing()
        {
            dataSource.Clear();

            var vPersonalData = await prtGetPersonalData();
            if (!vPersonalData.IsValid)
            {
                prtOnPageAppearingTrackError(
                    nameof(prtGetPersonalData),
                    vPersonalData);
                return;
            }

            string strToken = vPersonalData.Data.StrToken;
            string strAccountId = vPersonalData.Data.StrAccountId;

            var vNews = await dalWebApi.News.GetNews(new dtObj.ObjNewsIn(strToken, strAccountId), cancellationToken);
            if (vNews.IsValid)
            {
                string strMonth = string.Empty;

                for (int i = 1; i <= 12; i++)
                {
                                        
                    var vMonthData = vNews.Data.news.Where(x => x.date_pub.Month == i).ToList();

                    if (vMonthData.Count == 0)
                    {
                        continue;
                    }

                    vMonthData = vMonthData.OrderBy(x => x.date_pub.Day).ToList();
                    strMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(1);
                    
                    dataSource.Add(new mdl.MdlNewsTitle(strMonth));

                    
                    foreach (var item in vMonthData)
                    {
                        dataSource.Add(new mdl.MdlNewsDataShort(item, CmdGoTo));
                    }
                }

                var vGroupByMonth = vNews.Data.news.GroupBy(x => x.date_pub.Month).ToList();
            }
            else
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.News.GetNews),
                    vNews);
                prtSetError(vNews);
                return;
            }

            dataCollection.MgcReplaceRange(dataSource);
        }

        public ICommand CmdGoTo => MakeCommand((item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            


            IsBusy = false;
        });

        #endregion
    }
}
