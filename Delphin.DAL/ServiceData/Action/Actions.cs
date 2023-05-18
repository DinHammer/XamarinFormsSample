using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dalDataObjects = Delphin.Abstraction.DataObjects;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;

namespace Delphin.DAL.ServiceData.Action
{
    public class ActionPageMain: BaseAction, IActionPageMain
    {
        public async Task<RequestResult<dalDataObjects.ObjPageMain>> GetInitData(string token, CancellationToken cts)
        {
            dalDataObjects.ObjPageMain objPageMain = new dalDataObjects.ObjPageMain();

            var var_news_latest = await dalSrvWebApi.News.GetNewsLatest(null, cts);
            if (!var_news_latest.IsValid)
            {
                return new RequestResult<dalDataObjects.ObjPageMain>(null, var_news_latest.Status, var_news_latest.Message);
            }

            var var_news_hot = await dalSrvWebApi.News.GetNewsHot(null, cts);
            if (!var_news_hot.IsValid)
            {
                return new RequestResult<dalDataObjects.ObjPageMain>(null, var_news_hot.Status, var_news_hot.Message);
            }

            objPageMain.news_hot = var_news_hot.Data;
            objPageMain.news_latest = var_news_latest.Data;

            return new RequestResult<dalDataObjects.ObjPageMain>(objPageMain, statusOk);
        }
    }

    public class ActionPageNews : BaseAction, IActionPageNews
    {
        public async Task<RequestResult<dalDataObjects.ObjPageNews>> GetInitData(string token, CancellationToken cts)
        {
            dalDataObjects.ObjPageNews result = new dalDataObjects.ObjPageNews();

            /*var var_news = await dalSrvWebApi.PageNews.GetNews(token, cts);
            if (!var_news.IsValid)
            {
                return new RequestResult<dalDataObjects.ObjPageNews>(null, var_news.Status, var_news.Message);
            }

            result.news_data = var_news.Data;*/
            return new RequestResult<dalDataObjects.ObjPageNews>(result, statusOk);
        }
    }
}
