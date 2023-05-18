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
    public class ActionKvartplata : BaseAction, IActionKvartplata
    {
        public Task<RequestResult<dtObj.ObjKvLsShortOut>> GetKvLsShort(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvLsShortOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.Kvartplata.web_api_kv_ls_short,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true);



           /* HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.web_api_kv_ls_short, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvLsShortOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }
                else
                {
                    return new RequestResult<dtObj.ObjKvLsShortOut>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvLsShortOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvLsShortOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjKvMetersLatestOut>> GetKvMetersLatest(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvMetersLatestOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.Kvartplata.kv_meters_latest,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_latest, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvMetersLatestOut>(var_response.Content);

                    return var_result;
                }
                else
                {
                    return new RequestResult<dtObj.ObjKvMetersLatestOut>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvMetersLatestOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvMetersLatestOut>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvFlowLatest>> GetKvFlowLatest(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvFlowLatest>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_flow_latest,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow_latest, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvFlowLatest>(var_response.Content);

                    return var_result;
                }
                else
                {
                    return new RequestResult<dtObj.ObjKvFlowLatest>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvFlowLatest>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvFlowLatest>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvFlowDetailOut>> GetKvFlowDetails(dtObj.ObjKvFlowDetailIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvFlowDetailOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_flow_detail,
               strId: dtIn.Id.ToString(),
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow_detail, dtIn.strAccount);
            //string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow_detail);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvFlowDetail>(var_response.Content);

                    return var_result;
                }
                else
                {
                    return new RequestResult<dtObj.ObjKvFlowDetail>(null,
                        statusServiceUnavailable,
                        message: prtGetErrorMesage(str_url, var_response));
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvFlowDetail>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvFlowDetail>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvFlowOut>> GetKvFlow(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvFlowOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_flow,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow, dtIn.strAccount);
            //string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow_detail);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvFlowOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvFlowOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvFlowOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjKvMetersHistoryOut>> GetKvMetersHistory(dtObj.ObjKvMetersIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvMetersHistoryOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_meters_history,
               strId: dtIn.strMetterId,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            //string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_history, dtIn.strAccount);
            //string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_history, "23456");
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_history, dtIn.strMetterId);

            
            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvMetersHistoryOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvMetersHistoryOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvMetersHistoryOut>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvMetersDataOut>> GetKvMetersData(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvMetersDataOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_meters_data,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_data, dtIn.strAccount);
            //string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_flow_detail);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvMetersDataOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvMetersDataOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvMetersDataOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjKvLsDetail>> GetKvLsDetail(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvLsDetail>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_ls_detail,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_ls_detail, dtIn.strAccount);            

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvLsDetail>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvLsDetail>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvLsDetail>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvLsServicesOut>> GetKvLsServices(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvLsServicesOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_ls_services,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_ls_services, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvLsServicesOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvLsServicesOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvLsServicesOut>(null, statusServiceUnavailable);*/
        }
        public Task<RequestResult<dtObj.ObjKvMetersDetailOut>> GetKvMetersDetail(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvMetersDetailOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_meters_detail,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_meters_detail, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvMetersDetailOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvMetersDetailOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvMetersDetailOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjKvTarifOut>> GetKvTarif(dtObj.ObjKvIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjKvTarifOut>(
               strToken: dtIn.strToken,
               strApi: constText.WebApi.Kvartplata.kv_tarif,
               strId: dtIn.strAccount,
               cts,
               useRootCertificate: true);


            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.Kvartplata.kv_tarif, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjKvTarifOut>(var_response.Content);

                    return var_result;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjKvTarifOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjKvTarifOut>(null, statusServiceUnavailable);*/
        }
    }
}
