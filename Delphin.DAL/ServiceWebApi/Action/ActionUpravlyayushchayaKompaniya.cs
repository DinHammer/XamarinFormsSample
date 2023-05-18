using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using srvWebapi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using constText = Delphin.Abstraction.Constants.ConstantText;
using dtObj = Delphin.Abstraction.DataObjects;
using smpTools = Delphin.DAL.Staff.SimpleTools;

namespace Delphin.DAL.ServiceWebApi.Action
{
    public class ActionUpravlyayushchayaKompaniya : BaseAction, IActionUpravlyayushchayaKompaniya
    {
        public Task<RequestResult<dtObj.ObjUkSummaryOut>> GetUkSummary(dtObj.ObjUkIn dtIn, CancellationToken cts)
        {
            return prtGetWithId<dtObj.ObjUkSummaryOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.web_api_uk_summary,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true);



            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.web_api_uk_summary, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);                    
                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjUkSummaryOut>(var_response.Content);
                    return var_result;                 
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjUkSummaryOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjUkSummaryOut>(null, statusServiceUnavailable);*/
        }

        public Task<RequestResult<dtObj.ObjUkContactsOut>> GetUkContacts(dtObj.ObjUkIn dtIn, CancellationToken cts)
        {

            return prtGetWithId<dtObj.ObjUkContactsOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.web_api_uk_contacts,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true);

            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.web_api_uk_contacts, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjUkContactsOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjUkContactsOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjUkContactsOut>(null, statusServiceUnavailable);*/
        }
    }
}
