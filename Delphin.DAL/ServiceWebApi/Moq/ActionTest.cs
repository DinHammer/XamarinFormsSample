
using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Delphin.DAL.ServiceWebApi.Moq
{
    public class ActionTest : BaseMoqAction, IActionTest
    {
        public Task<RequestResult> GetTest(dtObj.ObjTestIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                return new RequestResult();
            });
        }

        public Task<RequestResult<dtObj.ObjTestOut>> GetTestOut1(dtObj.ObjTestIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                return new RequestResult<dtObj.ObjTestOut>(
                    new dtObj.ObjTestOut(), 
                    status: RequestStatus.Ok,
                    message:"OloloPishPish");
            });
        }

        public Task<RequestResult<dtObj.ObjTestOut>> GetTestOut2(dtObj.ObjTestIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                return new RequestResult<dtObj.ObjTestOut>();
            });
        }
    }
}
