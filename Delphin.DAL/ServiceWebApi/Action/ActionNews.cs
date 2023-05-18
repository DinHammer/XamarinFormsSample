using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using srvWebapi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using constText = Delphin.Abstraction.Constants.ConstantText;
using dtObj = Delphin.Abstraction.DataObjects;
using smpTools = Delphin.DAL.Staff.SimpleTools;

namespace Delphin.DAL.ServiceWebApi.Action
{
    public class ActionNews : BaseAction, IActionNews
    {
        public Task<RequestResult<dtObj.ObjNewsHotOut>> GetNewsHot(dtObj.ObjNewsIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjNewsHotOut>
                (
                strToken: dtIn.strToken,
                strApi: constText.WebApi.News.web_api_news_hot,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true
                );


            /*//HttpClient httpClient = srvWebapi.Staff.GetHttpClient(dtIn.strToken);
            HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.News.web_api_news_hot);
            str_url = $@"{str_url}{dtIn.strAccount}";
            //hui
            //olol
            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjNewsHotOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }
                else
                {
                    return new RequestResult<dtObj.ObjNewsHotOut>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjNewsHotOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjNewsHotOut>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjNewsOut>> GetNews(dtObj.ObjNewsIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjNewsOut>
                (
                strToken: dtIn.strToken,
                strApi: constText.WebApi.News.web_api_news,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true
                );



            /*//HttpClient httpClient = srvWebapi.Staff.GetHttpClient(str_token_acces);
            HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.News.web_api_news);
            str_url = $@"{str_url}{dtIn.strAccount}";

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjNewsOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }
                else
                {
                    return new RequestResult<dtObj.ObjNewsOut>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjNewsOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjNewsOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjNewsLatestOut>> GetNewsLatest(dtObj.ObjNewsIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjNewsLatestOut>
                (
                strToken: dtIn.strToken,
                strApi: constText.WebApi.News.web_api_news_latest,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true
                );



            /*//HttpClient httpClient = srvWebapi.Staff.GetHttpClient(str_token_acces);
            HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.News.web_api_news_latest);
            str_url = $@"{str_url}{dtIn.strAccount}";

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjNewsLatestOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }
                else
                {
                    return new RequestResult<dtObj.ObjNewsLatestOut>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjNewsLatestOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjNewsLatestOut>(null, statusServiceUnavailable);*/
        }
    }
}
