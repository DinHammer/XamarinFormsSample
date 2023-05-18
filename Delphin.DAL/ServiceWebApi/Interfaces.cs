using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dalDataObjects = Delphin.Abstraction.DataObjects;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Delphin.DAL.ServiceWebApi
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionAuth">
    public interface IActionAuth
    {
        


    }

    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionUser">
    public interface IActionUsers
    {

        Task<RequestResult<dtObj.ObjUserHeaderOut>> GetHeader(dtObj.ObjUserAccountIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjRefreshTokenOut>> RefreshToken(dtObj.ObjRefreshTokenIn data, CancellationToken cts);
        Task<RequestResult<dalDataObjects.ObjLoginOut>> GetLoggIn(dalDataObjects.ObjLoginIn data, CancellationToken cts);
        Task<RequestResult<dtObj.ObjUserProfileOut>> GetUserProfile(dtObj.ObjUserProfileIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjCreateOut>> GetCreate(dtObj.ObjCreateIn data, CancellationToken cts);

        Task<RequestResult<dtObj.ObjUserAccountOut>> GetAccounts(dtObj.ObjUserAccountIn data, CancellationToken cts);
    }

    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionNews">
    public interface IActionNews
    {
        Task<RequestResult<dalDataObjects.ObjNewsHotOut>> GetNewsHot(dalDataObjects.ObjNewsIn dtIn, CancellationToken cts);
        Task<RequestResult<dalDataObjects.ObjNewsLatestOut>> GetNewsLatest(dalDataObjects.ObjNewsIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjNewsOut>> GetNews(dtObj.ObjNewsIn dtIn, CancellationToken cts);
    }

    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionPageNews">
    public interface IActionPageNews
    {
        Task<RequestResult<dalDataObjects.ObjectNewsData>> GetNews(string str_token_acces, CancellationToken cts);
    }

    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionPageOther">
    public interface IActionPageOther
    {
        Task<RequestResult<dalDataObjects.ObjUkSummaryOut>> GetUkSummary(string str_token_acces, CancellationToken cts);
        Task<RequestResult<dalDataObjects.ObjectNewsData>> GetLsHeader(string str_token_acces, CancellationToken cts);
        Task<RequestResult<dalDataObjects.ObjectCashFlowData>> GetKvFlowLatest(string str_token_acces, CancellationToken cts);
    }

    /// <see cref="Delphin.DAL.ServiceWebApi.Action.ActionStaff">
    public interface IActionStaff
    {
        HttpClient GetHttpClient();

        HttpClient GetHttpClient(bool useRootSertificate = false);

        HttpClient GetHttpClient(string token = "", bool useRootSertificate = false);

        //string BuildUri(string str_api);
        string BuildUri(string string_api, string strId = "", bool addSlashAtEnd = false);

        RequestResult<HttpContent> GetHttpContent(object obj_data);

        Task<RequestResult<T>> GetDataFromHttpContent<T>(HttpContent httpContent) where T : class;

        Task<RequestResult<string>> GetStringByHttpContent(HttpContent httpContent);

        Task<RequestResult<T>> GetDataSimple<T>(string uri, string str_token_access, CancellationToken cts) where T : class;
    }

    public interface IActionKvartplata
    {
        Task<RequestResult<dtObj.ObjKvLsShortOut>> GetKvLsShort(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvMetersLatestOut>> GetKvMetersLatest(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvFlowLatest>> GetKvFlowLatest(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvFlowDetailOut>> GetKvFlowDetails(dtObj.ObjKvFlowDetailIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvFlowOut>> GetKvFlow(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvMetersHistoryOut>> GetKvMetersHistory(dtObj.ObjKvMetersIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvMetersDataOut>> GetKvMetersData(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvLsDetail>> GetKvLsDetail(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvLsServicesOut>> GetKvLsServices(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvMetersDetailOut>> GetKvMetersDetail(dtObj.ObjKvIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjKvTarifOut>> GetKvTarif(dtObj.ObjKvIn dtIn, CancellationToken cts);
    }

    public interface IActionUpravlyayushchayaKompaniya
    {
        Task<RequestResult<dtObj.ObjUkSummaryOut>> GetUkSummary(dtObj.ObjUkIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjUkContactsOut>> GetUkContacts(dtObj.ObjUkIn dtIn, CancellationToken cts);
    }

    public interface IActionActionLitsevoySchet
    {
        Task<RequestResult<dtObj.ObjLsHeaderOut>> GetLsHeader(dtObj.ObjLsIn dtIn, CancellationToken cts);
    }

    public interface IActionFlat
    {
        Task<RequestResult<dtObj.ObjFlatShortOut>> GetFlatShort(dtObj.ObjFlatIn dtIn, CancellationToken cts);
    }

    public interface IActionTest
    {
        Task<RequestResult<dtObj.ObjTestOut>> GetTestOut1(dtObj.ObjTestIn dtIn, CancellationToken cts);
        Task<RequestResult<dtObj.ObjTestOut>> GetTestOut2(dtObj.ObjTestIn dtIn, CancellationToken cts);
        Task<RequestResult> GetTest(dtObj.ObjTestIn dtIn, CancellationToken cts);
    }

    
}
