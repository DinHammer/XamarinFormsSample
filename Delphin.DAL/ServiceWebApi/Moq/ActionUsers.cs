
using Delphin.Abstraction.DataObjects;
using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dtObj = Delphin.Abstraction.DataObjects;
using smpTools = Delphin.DAL.Staff.SimpleTools;

namespace Delphin.DAL.ServiceWebApi.Moq
{
    public class ActionUsers : BaseMoqAction, IActionUsers
    {
        public Task<RequestResult<ObjUserAccountOut>> GetAccounts(ObjUserAccountIn data, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                ObjUserAccountOut output = new ObjUserAccountOut();
                output.objects.Add(new AccountObject { 
                    full_address = "ololo",
                    tabn = "pishPish"
                });
                return new RequestResult<ObjUserAccountOut>(output, RequestStatus.Ok);
            });
        }

        public Task<RequestResult<dtObj.ObjCreateOut>> GetCreate(dtObj.ObjCreateIn data, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjUserHeaderOut>> GetHeader(ObjUserAccountIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<dtObj.ObjLoginOut>> GetLoggIn(dtObj.ObjLoginIn data, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                dtObj.ObjLoginOut output = new dtObj.ObjLoginOut();
                output.user = "ololo";
                output.tokens = new ObjTokenOut();
                output.tokens.refresh = "pishPish";
                output.tokens.access = "ololoPishPish";
                //output.token = Guid.NewGuid().ToString();
                return new RequestResult<dtObj.ObjLoginOut>(output, statusOk);
            });
        }

        public Task<RequestResult<dtObj.ObjUserProfileOut>> GetUserProfile(dtObj.ObjUserProfileIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                dtObj.ObjUserProfileOut output = new dtObj.ObjUserProfileOut();
                
                //output.token = Guid.NewGuid().ToString();
                return new RequestResult<dtObj.ObjUserProfileOut>(output, statusOk);
            });
        }

        public Task<RequestResult<dtObj.ObjRefreshTokenOut>> RefreshToken(dtObj.ObjRefreshTokenIn data, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                string strToken = data.refresh;
                dtObj.ObjRefreshTokenOut output = new dtObj.ObjRefreshTokenOut(strToken, strToken);
                return new RequestResult<dtObj.ObjRefreshTokenOut>(output, statusOk);
            });
        }
    }
}
