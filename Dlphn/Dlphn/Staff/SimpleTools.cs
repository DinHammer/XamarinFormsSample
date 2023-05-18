using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using constString = Dlphn.Constants.ConstString;
using dtObj = Delphin.Abstraction.DataObjects;

namespace Dlphn.Staff
{
    public class SimpleTools : Delphin.DAL.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static new SimpleTools Instance => LazyInstance.Value;

        public string GetUnitOfMeasurement(string text)
        {
            switch (text)
            {
                case constString.KeyMetter.strWaterColdShort:
                case constString.KeyMetter.strWaterHotShort:
                    return constString.KeyUnitOfMeasurements.m3;
                case constString.KeyMetter.strElectricity:
                    return constString.KeyUnitOfMeasurements.kVch;
                default: return string.Empty;
            }
        }

        public RequestResult<List<DateTime>> GetListDateTimeFormLstCashFlow(List<dtObj.CashFlow> lstCashFlow)
        {
            List<DateTime> lstOut = new List<DateTime>();

            int count = lstCashFlow.Count;
            bool isOk = false;
            DateTime dateTime;
            string str = string.Empty;

            for (int i = 0; i < count; i++)
            {
                str = lstCashFlow[i].date;
                isOk = DateTime.TryParse(str, out dateTime);
                if (isOk)
                {
                    lstOut.Add(dateTime);
                }
                else
                {
                    return new RequestResult<List<DateTime>>(lstOut,
                        statusSomethingWrong,
                        $"Can not Convert {str} to DateTime");
                }
            }

            return new RequestResult<List<DateTime>>(lstOut, statusOk);
        }

        public RequestResult<string[]> GetDateSatartAndFinishFromLstCashFlow(List<dtObj.CashFlow> lstCashFlow)
        {
            string[] output = new string[2];

            var vData = GetListDateTimeFormLstCashFlow(lstCashFlow);
            if (!vData.IsValid)
            {
                return new RequestResult<string[]>(output, vData.Status, vData.Message);
            }

            DateTime dtStart = vData.Data.Min();
            DateTime dtFinish = vData.Data.Max();

            string strStart = GetStringFromDateTime(dtStart);
            string strFinish = GetStringFromDateTime(dtFinish);

            output[0] = strStart;
            output[1] = strFinish;

            return new RequestResult<string[]>(output, RequestStatus.Ok);
        }

        private string GetStringFromDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy");
        }

        public RequestResult<Xamarin.Forms.Style> GetXamarinStyleByKey(string key)
        {
            try
            {
                Xamarin.Forms.Style output = (Xamarin.Forms.Style)App.Current.Resources[key];
                return new RequestResult<Xamarin.Forms.Style>(output, statusOk);
            }
            catch
            {
                return new RequestResult<Xamarin.Forms.Style>(null, statusNotFound,
                    $"Can not find xamarin style by key {key}");
            }
        }
    }
}
