using DevDH.Magic.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using smpTools = Delphin.Abstraction.Staff.SimpleTools;


namespace Delphin.Abstraction.DataObjects
{
    public class ObjKvIn : BaseObjIn
    {
        public ObjKvIn(string strToken, string strAccount) : base(strToken, strAccount)
        {}        

        public ObjKvIn(ObjLoginOut dtOut) : base(dtOut)
        { }

        
    }

    public class ObjKvMetersIn : BaseObjIn
    {        
        public ObjKvMetersIn(string strToken, string strMetterId)
        {
            this.strToken = strToken;
            this.strMetterId = strMetterId;
        }
        public string strMetterId { get; set; }
    }

    public class ObjKvLsShortOut
    {
        

        /*[JsonProperty("FlatShortData")]
        public ObjKvFlatShortData flatShortData { get; set; }*/

        /*[JsonProperty("FIO")]
        public ObjKvFio fio { get; set; }*/

        [JsonProperty("Flat")]
        public ObjKvFlatShort flat { get; set; }

        [JsonProperty("Agreements")]
        public ObjKvAgreements agreements { get; set; }
    }
    #region ObjKvLsShortOut
    
    public class ObjKvFlatShortData
    {
        public string uk_uuid { get; set; }
        public string uk_account { get; set; }
    }

    public class ObjKvFio
    {
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string middle_name { get; set; }

        public override string ToString()
        {
            return $"{second_name} {first_name} {middle_name}";
        }
    }
    public class ObjKvFlatShort
    {
        public string uk_lsnumber { get; set; }
        public string full_address { get; set; }

        /*[JsonProperty("dom")]
        public ObjKvFlatDom dom { get; set; }
        public int flat_number { get; set; }
        public override string ToString()
        {
            return $"{dom.ToString()}, кв.{flat_number}";
        }*/
    }
    public class ObjKvFlatDom
    {
        public string region { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string home { get; set; }
        public string building { get; set; }
        public string korpus { get; set; }

        public override string ToString()
        {
            return $"{region}, {city}, ул. {street}, д.{home}к{korpus}";
        }
    }

    public class ObjKvAgreements
    {
        public string client_name { get; set; }
        public string dogovor { get; set; }
        public string contr_date_start { get; set; }
        public string contr_date_end { get; set; }
    }
    #endregion

    public class ObjKvMetersLatestOut
    {
        [JsonProperty("Meters")]
        public List<MetersData> lstMetersData {get;set;}

        #region Methods
        public bool IsValid()
        {
            bool output = false;

            if (lstMetersData?.Count > 0)
            {
                output = true;
            }
            
            return output;
        }
        
        #endregion
    }

    public class MetersData
    { 
        public string serv_printname { get; set; }
        public string shetchik_number { get; set; }
        public string shetchik_description { get; set; }

        public string check_time { get; set; }

        public string install_date { get; set; }

        public int tarifs_num { get; set; }

        [JsonProperty("pokazan_tarif")]
        public List<PokazanTarif> pokazanTarifs { get; set; }

        /*public string first_pokazan { get; set; }
        public string latest_pokazan { get; set; }
        public string pokazan_date { get; set; }*/

        

        /*public string pokazan_measure { get; set; }
        public string tarif1_name { get; set; }
        public string pokazan_tarif1 { get; set; }
        public string tarif2_name { get; set; }
        public string pokazan_tarif2 { get; set; }
        public string tarif3_name { get; set; }
        public string pokazan_tarif3 { get; set; }
        public string pokazan_date { get; set; }*/
    }

    public class PokazanTarif
    {
        public int tarif_id { get; set; }
        public string tarif_name { get; set; }
        public string first_pokazan { get; set; }
        public string latest_pokazan { get; set; }
        public string pokazan_date { get; set; }
        
        //public DateTime DtPokazan => GetDtPokazan().IsValid ? GetDtPokazan().Data.DateTime : default;

        public RequestResult<ObjDateTime> GetDtPokazan() => smpTools.Instance.mgcConvertString2DateTime(pokazan_date);
    }

    public class ObjKvFlowLatest
    {
        [JsonProperty("CashFlow")]
        public List<CashFlow> lstCashFlow { get; set; }

        public ObjKvFlowLatest()
        {
            lstCashFlow = new List<CashFlow>();
        }

        #region Methods
        public bool IsValid()
        {
            bool output = false;

            if (lstCashFlow?.Count > 0)
            {
                output = true;
            }

            return output;
        }

        
        /*public RequestResult<string[]> GetDateStartAndFinish()
        {
            string[] output=new string[2];
            

            var vData=GetListDateTime();
            if (!vData.IsValid)
            {
                return new RequestResult<string[]>(output, vData.Status);
            }

            DateTime dtStart = vData.Data.Min();
            DateTime dtFinish = vData.Data.Max();
            string strStart = GetStringFromDateTime(dtStart);
            string strFinish = GetStringFromDateTime(dtFinish);

            output[0] = strStart;
            output[1] = strFinish;  

            return new RequestResult<string[]>(output, RequestStatus.Ok);
        }        */

        /*private RequestResult<List<DateTime>> GetListDateTime()
        {
            List<bool> arrBool = lstCashFlow.Select(x=>x.IsDateTimeValid).ToList();

            bool isOk = arrBool.All(x => x == true);

            if (isOk)
            {
                List<DateTime> lst = lstCashFlow.Select(x => x.DateTime).ToList();
                return new RequestResult<List<DateTime>>(lst, RequestStatus.Ok);
            }
            else
            {
                return new RequestResult<List<DateTime>>(null, RequestStatus.NoContent);
            }            
        }*/

        /*private string GetStringFromDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy");
        }*/
        #endregion
    }
    public class CashFlow
    {
        public CashFlow() { }
        public CashFlow(string date, string operations_sum, string operat_saldo_e)
        {
            this.date = date;
            this.operations_sum = operations_sum;
            this.operat_saldo_e=operat_saldo_e;
        }

        public string operation_type { get; set; }
        public string date { get; set; }
        public string operations_sum { get; set; }
        public string operat_saldo_e { get; set; }
        public int id { get; set; }

        public DateTime DateTime=> DateTime.Parse(date);        

        public bool IsDateTimeValid
        {
            get
            {
                DateTime dateTime;
                return DateTime.TryParse(date, out dateTime);
            }
        }
    }

    public class ObjKvFlowDetailOut
    {
        [JsonProperty("CashFlowDetail")]
        public CashFlowDetails cashFlowDetails { get; set; }
    }

    public class ObjKvFlowDetailIn : BaseObjIn
    {
        public ObjKvFlowDetailIn(int id, string strToken)
        {
            Id= id.ToString();
            this.strToken = strToken;
        }
        public ObjKvFlowDetailIn(string id, string strToken)
        {
            Id = id;
            this.strToken = strToken;
        }

        /*public ObjKvFlowDetailIn(int id, ObjLoginOut dtOut) : base(dtOut)
        {
            Id = id;
        }*/

        public string Id { get; set; }
    }

    public class CashFlowDetails
    {
        public string operation_type { get; set; }
        public string date { get; set; }
        public string operat_saldo_b { get; set; }
        public string operat_saldo_e { get; set; }

        /*[JsonProperty("worked_id")]
        public WorkedId worked_Id { get; set; }*/

        [JsonProperty("operation_saldo")]
        public List<OperationSaldo> operationSaldos { get; set; }

    }

    public class OperationSaldo
    {
        public string period { get; set; }
        public string myusluga { get; set; }
        public string operations_sum { get; set; }
    }

    /*public class WorkedId
    { 
        public string date { get; set; }
        public string serv_printname { get; set; }
        public string vid_uslugi { get; set; }
        public string worked_sum { get; set; }
        public string saldo_e { get; set; }
    }*/

    public class ObjKvFlowOut
    {
        [JsonProperty("CashFlowAll")]
        public List<CashFlowAll> lstCashFlowAll { get; set; }
    }

    public class CashFlowAll
    {
        public string type { get; set; }
        public string date { get; set; }
        public string operations_sum { get; set; }
        public string operat_saldo_e { get; set; }
    }

    
    public class ObjKvMetersHistoryOut
    {
        [JsonProperty("MetersHistory")]
        public List<MetersHistory> lstMetersHistory { get; set; }
    }

    public class MetersHistory
    {
        public string pokazan_tarif1 { get; set; }
        public string pokazan_tarif2 { get; set; }
        public string pokazan_tarif3 { get; set; }
        public string pokazan_date { get; set; }
    }

    public class ObjKvMetersDataOut
    {
        [JsonProperty("MetersData")]
        public List<MetersData> lstMetersData { get; set; }
    }

    public class ObjKvLsDetail
    {
        [JsonProperty("FlatShortData")]
        public ObjKvFlatShortData flatShortData { get; set; }

        [JsonProperty("FIO")]
        public ObjKvFio fio { get; set; }

        [JsonProperty("Flat")]
        public ObjKvFlat flat { get; set; }

        [JsonProperty("Agreements")]
        public ObjKvAgreements agreements { get; set; }
    }

    public class ObjKvFlat
    {
        [JsonProperty("dom")]
        public ObjKvFlatDom dom { get; set; }
        public int flat_number { get; set; }
        public string flat_total_square { get; set; }
        public string flat_live_square { get; set; }
    }

    public class ObjKvLsServicesOut
    {
        [JsonProperty("MyUslugi")]
        public List<MyUslugi> lstMyUslugi { get; set; }
    }
    public class MyUslugi
    {
        public string serv_printname { get; set; }
        public string created_date { get; set; }
    }

    public class ObjKvMetersDetailOut
    {
        [JsonProperty("MetersDetail")]
        public List<MetersDetail> lstMeterDetail { get; set; }
    }
    public class MetersDetail
    {
        public string serv_printname { get; set; }
        public string marka1 { get; set; }
        public string n_scetch { get; set; }
        public string opisanie { get; set; }
        public string plomba { get; set; }
        public string install_date { get; set; }
        public string check_time { get; set; }
        public int id { get; set; }
    }

    public class ObjKvTarifOut
    {
        [JsonProperty("TarifData")]
        public List<TarifData> lstTarifData { get; set; }
    }
    public class TarifData
    {
        public string serv_printname { get; set; }
        public string tarif1_name { get; set; }
        public string tarif2_name { get; set; }
        public string tarif3_name { get; set; }
        public string measure { get; set; }

        [JsonProperty("my_tarif")]
        public MyTarif myTarif { get; set; }
    }

    public class MyTarif
    {
        [JsonProperty("uk_tarif_price")]
        public List<UkTarifPrice> lstUkTarifPrices { get; set; }
    }
    public class UkTarifPrice
    {
        public string tarif_price_value_t1 { get; set; }
        public string tarif_price_value_t2 { get; set; }
        public string tarif_price_value_t3 { get; set; }
        public string price_value_start_date { get; set; }
    }
}
