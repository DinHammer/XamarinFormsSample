using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using smpTools = Delphin.DAL.Staff.SimpleTools;

namespace Delphin.DAL.ServiceWebApi.Action
{
    public class ActionStaff : Delphin.Abstraction.Constants.BaseConstant
    {
        static readonly Lazy<ActionStaff> LazyInstanse = new Lazy<ActionStaff>(() => new ActionStaff(), true);
        public static ActionStaff Instance => LazyInstanse.Value;


        public static void Init(string base_uri)
        {
            Instance.Initialize(base_uri);
        }

        void Initialize(string base_uri)
        {
            this.base_uri = base_uri;
        }

        string base_uri;
        static HttpClient myHttpClient;

        /*public HttpClient GetHttpClient() => GetHttpClient(false);
        public HttpClient GetHttpClient(bool useRootSertificate = false)
        {
            if (useRootSertificate)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                myHttpClient = new HttpClient(httpClientHandler);
            }
            else
            {
                myHttpClient = new HttpClient();
            }
            
            return myHttpClient;
        }*/

        public HttpClient GetHttpClient(string token = "", bool useRootSertificate = false)
        {
            if (useRootSertificate)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                myHttpClient = new HttpClient(httpClientHandler);
            }
            else
            {
                myHttpClient = new HttpClient();
            }            

            myHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            if (token != "")
            {
                myHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return myHttpClient;
        }
        public string BuildUri(string string_api, string strId="", bool addSlashAtEnd = false)
        {
            string strOut = $"{base_uri}{string_api}";
            if (strId != "")
            {
                strOut = $"{strOut}{strId}";
            }

            if (addSlashAtEnd == true)
            {
                strOut = @$"{strOut}/";
            }

            return strOut;
        }

        

        /*public async Task<RequestResult> PostDataNoReturn<T>(T data, string string_url)
        {
            string url = BuildUri(string_url);
            //HttpContent httpContent = GetHttpContent<T>(data);
            HttpClient httpClient = GetHttpClient();

            try
            {
                //var response = await httpClient.PostAsync(url, httpContent);
                var response = await httpClient.PostAsync(url, null);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new RequestResult(statusOk);
                }
                else
                {
                    return new RequestResult(statusBadRequest);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult(statusSomethingWrong, ex.Message);
            }

        }*/


        public RequestResult<HttpContent> GetHttpContent(object obj_data)
        {
            var var_json = smpTools.Instance.mgcJsnGetStringByData(obj_data);
            if (var_json.IsValid)
            {
                var var_result = new StringContent(var_json.Data, Encoding.UTF8, "application/json");
                return new RequestResult<HttpContent>(var_result, statusOk);
            }
            else
            {
                return new RequestResult<HttpContent>(null, statusSerializationError, "can not get json by object");
            }
        }

        public async Task<RequestResult<string>> GetStringByHttpContent(HttpContent httpContent)
        {
            try
            {
                string str = await httpContent.ReadAsStringAsync();
                return new RequestResult<string>(str, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(null, statusSomethingWrong, message: "Can not read http request content string");
            }
        }
        public async Task<RequestResult<T>> GetDataFromHttpContent<T>(HttpContent httpContent) where T : class
        {
            try
            {
                string str_response = await httpContent.ReadAsStringAsync();
                var var_result = smpTools.Instance.mgcJsnGetDataByString<T>(str_response);
                if (var_result.IsValid)
                {
                    return new RequestResult<T>(var_result.Data, statusOk);
                }
                else
                {
                    return new RequestResult<T>(null, var_result.Status, var_result.Message);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, statusSomethingWrong, ex.Message);
            }
        }

        /*public async Task<RequestResult<T>> GetDataSimple<T>(string uri, string str_token_access, CancellationToken cts) where T : class
        {
            HttpClient httpClient = GetHttpClient(str_token_access);
            string str_url = BuildUri(uri);


            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await GetStringByHttpContent(var_response.Content);
                    bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await GetDataFromHttpContent<T>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<T>(null, statusServiceUnavailable);
        }*/
        //public async Task<RequestResult<T>> PostDataYesReturn<T>(T data, string string_url) where T : class
        //{
        //    string url = BuildUri(string_url);

        //    HttpContent httpContent = GetHttpContent<T>(data);
        //    HttpClient httpClient = GetHttpClient();

        //    try
        //    {
        //        var response = await httpClient.PostAsync(url, httpContent);

        //        var result = await GetDataFromHttpResponce<T>(response);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestResult<T>(data, statusServiceUnavailable, exceptionList: new List<Exception> { ex });
        //    }

        //}
    }
}
