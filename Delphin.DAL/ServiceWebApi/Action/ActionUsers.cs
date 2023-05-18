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
    public class ActionUser : BaseAction, IActionUsers
    {

        public Task<RequestResult<dtObj.ObjRefreshTokenOut>> RefreshToken(dtObj.ObjRefreshTokenIn data, CancellationToken cts)
        {

            return prtPost<dtObj.ObjRefreshTokenOut>
                (
                strToken: String.Empty,
                strApi: constText.WebApi.User.strUserTokenRefresh,
                data: data,
                cts: cts,
                useRootCertificate: true);

            /*//HttpClient httpClient = srvWebapi.Staff.GetHttpClient(data.refresh, true);
            HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);

            //string str_json = smpTools.Instance.mgcJsnGetStringByData(data).Data;

            string strUrl = srvWebapi.Staff.BuildUri(constText.WebApi.User.strUserTokenRefresh);

            var vHttpContent = srvWebapi.Staff.GetHttpContent(data);
            if (!vHttpContent.IsValid)
            {
                return new RequestResult<dtObj.ObjRefreshTokenOut>(null, vHttpContent.Status, vHttpContent.Message);
            }

            try
            {
                var response = await httpClient.PostAsync(strUrl, vHttpContent.Data);
                //var response = await httpClient.GetAsync(strUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<dtObj.ObjRefreshTokenOut>(str_response);

                    if (var_response.IsValid)
                    {
                        return new RequestResult<dtObj.ObjRefreshTokenOut>(var_response.Data, statusOk);
                    }

                }
                else
                {
                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjRefreshTokenOut>(null, statusSomethingWrong, $"{nameof(ActionUser)}::{nameof(GetLoggIn)}::{ex.Message}");
            }

            return new RequestResult<dtObj.ObjRefreshTokenOut>();*/

        }

        public Task<RequestResult<dtObj.ObjCreateOut>> GetCreate(dtObj.ObjCreateIn data, CancellationToken cts)
        {
            return prtPost<dtObj.ObjCreateOut>
                (
                strToken: String.Empty,
                strApi: constText.WebApi.User.strUserCreate,
                data: data,
                cts: cts,
                useRootCertificate: true);



            /*HttpClient httpClient = new HttpClient();

            string str_json = smpTools.Instance.mgcJsnGetStringByData(data).Data;

            string strUrl = srvWebapi.Staff.BuildUri(constText.WebApi.Auth.users_create);

            var vHttpContent = srvWebapi.Staff.GetHttpContent(data);
            if (!vHttpContent.IsValid)
            {
                return new RequestResult<dtObj.ObjCreateOut>(null, vHttpContent.Status, vHttpContent.Message);
            }


            try
            {
                var response = await httpClient.PostAsync(strUrl, vHttpContent.Data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<dtObj.ObjCreateOut>(str_response);

                    if (var_response.IsValid)
                    {
                        return new RequestResult<dtObj.ObjCreateOut>(var_response.Data, statusOk);
                    }

                }
                else
                {
                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjCreateOut>(null, statusSomethingWrong, $"{nameof(ActionUser)}::{nameof(GetLoggIn)}::{ex.Message}");
            }

            return new RequestResult<dtObj.ObjCreateOut>();*/
        }

        public Task<RequestResult<dtObj.ObjLoginOut>> GetLoggIn(dtObj.ObjLoginIn data, CancellationToken cts)
        {
            return prtPost<dtObj.ObjLoginOut>
                (
                strToken: String.Empty,
                strApi: constText.WebApi.User.strUserLoggIn,
                data: data,
                cts: cts,
                useRootCertificate: true);




            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient(true);

            string str_json = smpTools.Instance.mgcJsnGetStringByData(data).Data;            

            string strUrl = srvWebapi.Staff.BuildUri(constText.WebApi.Auth.strLoggIn);

            var vHttpContent = srvWebapi.Staff.GetHttpContent(data);
            if (!vHttpContent.IsValid)
            {
                return new RequestResult<dtObj.ObjLoginOut>(null, vHttpContent.Status, vHttpContent.Message);
            }


            try
            {
                var response = await httpClient.PostAsync(strUrl, vHttpContent.Data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<dtObj.ObjLoginOut>(str_response);

                    if (var_response.IsValid)
                    {
                        return new RequestResult<dtObj.ObjLoginOut>(var_response.Data, statusOk);
                    }

                }
                else
                {
                    return new RequestResult<dtObj.ObjLoginOut>(null, 
                        statusServiceUnavailable, 
                        $"{nameof(response.StatusCode)}: {response.StatusCode.ToString()}, {nameof(response.ReasonPhrase)}:{response.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjLoginOut>(null, statusSomethingWrong, $"{nameof(ActionUser)}::{nameof(GetLoggIn)}::{ex.Message}");                
            }
                        
            return new RequestResult<dtObj.ObjLoginOut>();*/
        }

        public Task<RequestResult<dtObj.ObjUserProfileOut>> GetUserProfile(dtObj.ObjUserProfileIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjUserProfileOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.User.strUserProfile,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true);



            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.User.strUserProfile, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjUserProfileOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjUserProfileOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjUserProfileOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjUserAccountOut>> GetAccounts(dtObj.ObjUserAccountIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjUserAccountOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.User.strUserAccount,
                strId: dtIn.strUserUuid,
                cts,
                useRootCertificate: true);



            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient(data.strToken, true);            
            string strUrl = srvWebapi.Staff.BuildUri(constText.WebApi.User.strUserAccount, data.strUserUuid);            

            try
            {
                var response = await httpClient.GetAsync(strUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<dtObj.ObjUserAccountOut>(str_response);

                    if (var_response.IsValid)
                    {
                        return new RequestResult<dtObj.ObjUserAccountOut>(var_response.Data, statusOk);
                    }

                }
                else
                {
                    return new RequestResult<dtObj.ObjUserAccountOut>(null,
                        statusServiceUnavailable,
                        $"{nameof(response.StatusCode)}: {response.StatusCode.ToString()}, {nameof(response.ReasonPhrase)}:{response.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjUserAccountOut>(null, statusSomethingWrong, $"{nameof(ActionUser)}::{nameof(GetLoggIn)}::{ex.Message}");
            }

            return new RequestResult<dtObj.ObjUserAccountOut>();*/
        }

        public Task<RequestResult<dtObj.ObjUserHeaderOut>> GetHeader(dtObj.ObjUserAccountIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjUserHeaderOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.User.strUserHeader,
                strId: dtIn.strUserUuid,
                cts,
                useRootCertificate: true);
     
        }

    }
}
