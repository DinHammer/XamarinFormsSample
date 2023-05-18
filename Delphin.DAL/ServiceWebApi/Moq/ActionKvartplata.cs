using Delphin.Abstraction.DataObjects;
using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delphin.DAL.ServiceWebApi.Moq
{
    public class ActionKvartplata : BaseMoqAction, IActionKvartplata
    {
        public Task<RequestResult<ObjKvFlowOut>> GetKvFlow(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvFlowDetailOut>> GetKvFlowDetails(ObjKvFlowDetailIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvFlowLatest>> GetKvFlowLatest(ObjKvIn dtIn, CancellationToken cts)
        {
            return Task.Run(() =>
            {
                ObjKvFlowLatest result = new ObjKvFlowLatest();
                result.lstCashFlow.Add(
                new CashFlow
                {
                    operation_type = "",//"\u041e\u043f\u043b\u0430\u0447\u0435\u043d\u043e",
                    date = "2020-07-13",
                    operations_sum = "1000",//(1000.0f).ToString(),
                    operat_saldo_e = "-100",//(-100.0f).ToString(),
                }) ;
                result.lstCashFlow.Add(new CashFlow
                {
                    operation_type = "",//"\u041d\u0430\u0447\u0438\u0441\u043b\u0435\u043d\u043e",
                    date = "2020-07-01",
                    operations_sum = "520",// (520.0f).ToString(),
                    operat_saldo_e = "1100",// (1100.0f).ToString(),
                });
                result.lstCashFlow.Add(new CashFlow
                {
                    operation_type = "",//"\u041d\u0430\u0447\u0438\u0441\u043b\u0435\u043d\u043e",
                    date = "2020-05-01",
                    operations_sum = "500",// (500.0f).ToString(),
                    operat_saldo_e = "-500",// (-500.0f).ToString(),
                });
                result.lstCashFlow.Add(new CashFlow
                {
                    operation_type = "",//"\u041e\u043f\u043b\u0430\u0447\u0435\u043d\u043e",
                    date = "2020-05-16",
                    operations_sum = "500",// (500.0f).ToString(),
                    operat_saldo_e = "0",// (0.0f).ToString(),
                });
                result.lstCashFlow.Add(new CashFlow
                {
                    operation_type = "",//"\u041d\u0430\u0447\u0438\u0441\u043b\u0435\u043d\u043e",
                    date = "2020-06-03",
                    operations_sum = "500",// (580.0f).ToString(),
                    operat_saldo_e = "-500",// (-580.0f).ToString(),
                });
                return new RequestResult<ObjKvFlowLatest>(result, statusOk);
            });            
        }

        public Task<RequestResult<ObjKvLsDetail>> GetKvLsDetail(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvLsServicesOut>> GetKvLsServices(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvLsShortOut>> GetKvLsShort(ObjKvIn dtIn, CancellationToken cts)
        {
            return Task.Run(() => { return new RequestResult<ObjKvLsShortOut>(); });
        }

        public Task<RequestResult<ObjKvMetersDataOut>> GetKvMetersData(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvMetersDetailOut>> GetKvMetersDetail(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvMetersHistoryOut>> GetKvMetersHistory(ObjKvMetersIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjKvMetersLatestOut>> GetKvMetersLatest(ObjKvIn dtIn, CancellationToken cts)
        {
            return Task.Run(() => { return new RequestResult<ObjKvMetersLatestOut>(); });
        }

        public Task<RequestResult<ObjKvTarifOut>> GetKvTarif(ObjKvIn dtIn, CancellationToken cts)
        {
            throw new NotImplementedException();
        }
    }
}
