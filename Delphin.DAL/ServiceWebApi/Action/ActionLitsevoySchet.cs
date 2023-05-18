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
    public class ActionLitsevoySchet : BaseAction, IActionActionLitsevoySchet
    {
        public Task<RequestResult<dtObj.ObjLsHeaderOut>> GetLsHeader(dtObj.ObjLsIn dtIn, CancellationToken cts)
        {

            return prtGetWithId<dtObj.ObjLsHeaderOut>(
                strToken: dtIn.strToken,
                strApi: constText.WebApi.web_api_ls_header,
                strId: dtIn.strAccount,
                cts,
                useRootCertificate: true
                );



            /*HttpClient httpClient = srvWebapi.Staff.GetHttpClient();
            string str_url = srvWebapi.Staff.BuildUri(constText.WebApi.web_api_ls_header, dtIn.strAccount);

            try
            {
                var var_response = await httpClient.GetAsync(str_url, cts);
                if (var_response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var var_string = await srvWebapi.Staff.GetStringByHttpContent(var_response.Content);
                    //bool bool_result = var_string.IsValid;
                    //string  var_response.Content.ReadAsStringAsync

                    var var_result = await srvWebapi.Staff.GetDataFromHttpContent<dtObj.ObjLsHeaderOut>(var_response.Content);

                    return var_result;
                    //return new RequestResult<dalDataObjects.ObjectNewsHot>(statusOk);
                }

            }
            catch (Exception ex)
            {
                return new RequestResult<dtObj.ObjLsHeaderOut>(null, statusSomethingWrong, message: ex.Message);
            }
            return new RequestResult<dtObj.ObjLsHeaderOut>(null, statusServiceUnavailable);*/
        }
    }
}
