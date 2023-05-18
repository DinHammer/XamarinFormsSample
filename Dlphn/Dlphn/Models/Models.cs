using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using dtObj = Delphin.Abstraction.DataObjects;
using constString = Dlphn.Constants.ConstString;
using constEnums = Dlphn.Constants.ConstEnums;
using srvImage = Dlphn.Staff.Services.SrvImage;
using Xamarin.Forms;
using baseBindable = Dlphn.Pages.ViewModels.BaseBindable;
using smpTools = Dlphn.Staff.SimpleTools;

namespace Dlphn.Models
{

    public class MdlSpace
    { }

    public class MdlMeterDataSendNo
    {
        private dtObj.MetersData _metersData;
        private dtObj.PokazanTarif _pokazanTarif;        
        public MdlMeterDataSendNo(dtObj.MetersData metersData, dtObj.PokazanTarif pokazanTarif)
        {
            _pokazanTarif = pokazanTarif;
            _metersData = metersData;
            StrUnitOfMeasurement = smpTools.Instance.GetUnitOfMeasurement(_metersData.serv_printname);
        }

        public string StrUnitOfMeasurement { get; private set; }
        public string StrLastValue => $"{_pokazanTarif.latest_pokazan} {StrUnitOfMeasurement}";
        public string StrTarifName => _pokazanTarif.tarif_name;
    }

    public class MdlMeterDataSendYes
    { }
    
    public class MdlMeterDataSendHeader
    {
        private dtObj.MetersData _metersData;
        public MdlMeterDataSendHeader(dtObj.MetersData metersData)
        {
            _metersData = metersData;
        }

        public string StrMeterType => _metersData.serv_printname;
        public string StrMeterName => $"{constString.KeyMetter.strMeter} {_metersData.shetchik_number}";
        public string StrMeterDescription => _metersData.shetchik_description;
    }

    public class MdlMeterDataSendButton
    {
        public MdlMeterDataSendButton(ICommand cmd)
        {
            CmdAction = cmd;
        }

        public ICommand CmdAction { get; private set; }
    }

    public class MdlMetersDataHistoryHeader
    { }
    public class MdlMetersDataHistoryDate
    {
        private DateTime _dateTime;
        public MdlMetersDataHistoryDate(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public string StrDateTime => _dateTime.ToString("dd MMMM yyyy");

    }
    public class MdlMetersDataHistoryValue
    {
        private dtObj.MetersData _metersData { get; set; }
        private dtObj.PokazanTarif _pokazanTarif { get; set; }
        public MdlMetersDataHistoryValue(dtObj.MetersData metersData, dtObj.PokazanTarif pokazanTarif, DateTime dateTime)
        {
            _metersData = metersData;
            _pokazanTarif = pokazanTarif;
            DtMeasurement = dateTime;
            StrUnitOfMeasurement = smpTools.Instance.GetUnitOfMeasurement(_metersData.serv_printname);
        }

        private string StrUnitOfMeasurement { get; set; }

        public DateTime DtMeasurement { get; private set; }
        public string StrName => GetStrName(_metersData.serv_printname, _pokazanTarif.tarif_name);
        public string StrValue => $"{_pokazanTarif.latest_pokazan} {StrUnitOfMeasurement}";

        private string GetStrName(string strMeterType, string strTarifName)
        {
            string output = string.Empty;

            switch (strMeterType)
            {
                case constString.KeyMetter.strElectricity:
                    output = $"{strMeterType}, {strTarifName}";
                    break;
                case constString.KeyMetter.strWaterColdShort:
                case constString.KeyMetter.strWaterHotShort:
                    output = strMeterType;
                    break;
            }

            return output;
        }
    }

    public class MdlMeterSendData
    {
        public MdlMeterSendData(ICommand cmd)
        {
            Cmd = cmd;
        }
        public ICommand Cmd { get; set; }
    }

    public class MdlMeterEnergyData : baseBindable
    {
        #region Fields
        private string _strEnergyValue = string.Empty;
        #endregion

        #region Properties
        public string StrEnergeyValue 
        {
            get => Get(_strEnergyValue);
            set => Set(value);
        }
        #endregion

        public MdlMeterEnergyData()
        {
            //StrEnergeyValue = strEnergyValue;
        }
        
    }

    public class MdlMeterWaterData
    { }


    public class MdlPersonalData
    {
        public MdlPersonalData(string strToken, string strAccountId)
        {
            this.StrToken= strToken;
            this.StrAccountId= strAccountId;
        }

        public string StrToken { get; private set; }
        public string StrAccountId { get; private set; }
    }

    public class MdlYetCell
    {
        public MdlYetCell(string strText, constEnums.Pages page, ICommand cmd)
        {
            this.StrText = strText;
            this.ImgSource = srvImage.Instance.GetYetImage(page).Data;
            this.Page = page;
            this.Cmd = cmd;
        }

        public string StrText { get; set; }
        public ICommand Cmd { get; set; }
        public ImageSource ImgSource { get; set; }
        public constEnums.Pages Page { get; set; }
    }
    public class MdlNewsTitle
    {
        public MdlNewsTitle(string strMonthName)
        {
            StrMonthName = strMonthName;
        }
        public string StrMonthName { get; set; }
    }


    public class MdlNewsDataShort
    {
        
        public MdlNewsDataShort(dtObj.ObjectNews data, ICommand cmdTap)
        {
            context = data;
            CmdTap = cmdTap;
        }

        public dtObj.ObjectNews context { get; private set; }

        public string strDate => context.date_pub.ToString("dd MMMM yyyy");

        public string strText => context.title;

        public ICommand CmdTap { get; private set; }
    }

    public class MdlError
    {
        public MdlError()
        {
            imageSource = srvImage.Instance.GetErrorImage();
        }
        public MdlError(string str): this()
        {
            this.str = str;
        }
        public string str { get; private set; }

        public Xamarin.Forms.ImageSource imageSource { get; private set; }
    }

    public class MdlHistoryHeader
    {        
        public MdlHistoryHeader(string[] array)
        {
            strDtStart=array[0];
            strDtFinish=array[1];
        }

        string strDtStart { get; set; }
        string strDtFinish { get; set; }

        public string strText 
        {
            get => $"{strDtStart} - {strDtFinish}";
        }
    }

    public class MdlHistoryData
    {
        
        public MdlHistoryData(dtObj.CashFlow cashFlow, 
            Xamarin.Forms.Style styleLbl,
            Xamarin.Forms.ImageSource imageSource,
            ICommand cmdGoTo)
        {
            this.cashFlow = cashFlow;
            StyleLbl = styleLbl;
            this.imageSource = imageSource;
            this.cmdGoTo = cmdGoTo;
        }

        public ICommand cmdGoTo { get; private set; }

        public dtObj.CashFlow cashFlow { get; private set; }

        public Xamarin.Forms.ImageSource imageSource { get; private set; }
        public Xamarin.Forms.Style StyleLbl {get; private set; }

        public string strDayAndMonth
        {
            get => cashFlow?.DateTime.ToString("dd MMMM");
        }
        public string strYear
        {
            get => cashFlow?.DateTime.Year.ToString();
        }
        public string strOperationSaldo
        {
            get => GetCorretString(cashFlow.operat_saldo_e);
        }
        public string strOperationSum
        {
            get => GetCorretString(cashFlow.operations_sum);
        }

        string GetCorretString(string str) => $"{str} руб";


        
    }

    public class MdlNewsOneData
    {
        public MdlNewsOneData(dtObj.ObjectNews data)
        {
            this.strDayAndMonth = data.date_pub.Date.ToString("M MMMM");
            this.strYear = data.date_pub.Year.ToString();
            this.strText = data.body;
        }

        public string strDayAndMonth { get; set; }
        public string strYear { get; set; }
        public string strText { get; set; }
        
    }

    public class MdlNewsGoTo
    {
        public MdlNewsGoTo(ICommand cmdGoTo)
        {
            this.cmdGoTo = cmdGoTo;
        }
        public ICommand cmdGoTo { get; set; }
    }

    public class MdlMetersLatestShortHeader
    { }

    public class MdlMetersLatestShortDate
    {
        private DateTime _dateTime;
        public MdlMetersLatestShortDate(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public string StrDateTime => _dateTime.ToString("yyyy MMMM dd");
    }

    public class MdlMetersLatestShortMetersNumber
    {        
        public MdlMetersLatestShortMetersNumber(string metersNumber)
        {
            StrMetersNumber = metersNumber;
        }

        public string StrMetersNumber { get; private set; }
    }

    public class MdlMetersLatestShortData
    {
        private dtObj.MetersData _metersData;
        private dtObj.PokazanTarif _pokazanTarif;
        private DateTime _dateTime;
        public MdlMetersLatestShortData(dtObj.MetersData metersData, dtObj.PokazanTarif pokazanTarif, DateTime dateTime)
        {
            _metersData = metersData;
            _pokazanTarif = pokazanTarif;
            _dateTime = dateTime;
            StringUnitOfMeasurement = smpTools.Instance.GetUnitOfMeasurement(_metersData.serv_printname);
        }

        private string StringUnitOfMeasurement { get; set; }

        public DateTime dateTime => _dateTime;
        //public string StrDateTime => _dateTime.ToString("dd MMMM yyyy");

        public string StrMetersNumber => _metersData.shetchik_number;

        public string StrText => _metersData.pokazanTarifs?.Count>0? 
            $"{_metersData.serv_printname}, {_pokazanTarif.tarif_name}":
            $"{_metersData.serv_printname}";
        public string StrValue => $"{_pokazanTarif.latest_pokazan} {StringUnitOfMeasurement}";
    }

    public class MdlMettersShortData
    {
        #region Fields
        dtObj.ObjKvMetersLatestOut data;
        #endregion

        #region Properties
        public string strDateTime { get; set; }

        public string strWaterColdName { get; set; }
        public string strWaterColdValue { get; set; }

        public string strWaterHotName { get; set; }
        public string strWaterHotValue { get; set; }

        public string strEnergyT1Name { get; set; }
        public string strEnergyT1Value { get; set; }

        public string strEnergyT2Name { get; set; }
        public string strEnergyT2Value { get; set; }
        #endregion
        public MdlMettersShortData(dtObj.ObjKvMetersLatestOut data)
        {
            this.data = data;
            //this.strDateTime = data.lstMetersData.First().pokazan_date;

            //this.strPokazanieName = data.serv_printname;
            //this.strPokazanieValue = $"{data.pokazan_tarif1} {data.pokazan_measure}";
        }

        #region Methods
        public RequestResult FillWaterCold()
        {
            var item = GetDataByPrintName(constString.KeyMetter.strWaterCold);
            if (!item.IsValid)
            {
                return new RequestResult(item.Status, item.Message);
            }

            this.strWaterColdName = item.Data.serv_printname;
            this.strWaterColdValue = GetValue(item.Data);

            return new RequestResult(RequestStatus.Ok);
        }

        public RequestResult FillWaterHot()
        {
            var item = GetDataByPrintName(constString.KeyMetter.strWaterHot);
            if (!item.IsValid)
            {
                return new RequestResult(item.Status, item.Message);
            }

            this.strWaterHotName = item.Data.serv_printname;
            this.strWaterHotValue = GetValue(item.Data);

            return new RequestResult(RequestStatus.Ok);
        }

        public RequestResult FillElectroT1()
        {
            var item = GetDataByPrintName(constString.KeyMetter.strElectroT1);
            if (!item.IsValid)
            {
                return new RequestResult(item.Status, item.Message);
            }

            this.strEnergyT1Name = item.Data.serv_printname;
            this.strEnergyT1Value = GetValue(item.Data);

            return new RequestResult(RequestStatus.Ok);
        }

        public RequestResult FillElectroT2()
        {
            var item = GetDataByPrintName(constString.KeyMetter.strElectroT2);
            if (!item.IsValid)
            {
                return new RequestResult(item.Status, item.Message);
            }

            this.strEnergyT2Name = item.Data.serv_printname;
            this.strEnergyT2Value = GetValue(item.Data);

            return new RequestResult(RequestStatus.Ok);
        }

        string GetValue(dtObj.MetersData data, constEnums.TypeTarif typeTarif=constEnums.TypeTarif.T1)
        {
            string strPakazanieValue = string.Empty;
            /*switch (typeTarif)
            {
                case constEnums.TypeTarif.T1:
                    strPakazanieValue = data.pokazan_tarif1;
                    break;
                case constEnums.TypeTarif.T2:
                    strPakazanieValue = data.pokazan_tarif2;
                    break;
                case constEnums.TypeTarif.T3:
                    strPakazanieValue = data.pokazan_tarif3;
                    break;
            }

            return $"{strPakazanieValue} {data.pokazan_measure}";*/
            return strPakazanieValue;
        }

        RequestResult<dtObj.MetersData> GetDataByPrintName(string key)
        {
            var item = data.lstMetersData.Where(x => x.serv_printname.Equals(key)).FirstOrDefault();
            if (item == null)
            {
                return new RequestResult<dtObj.MetersData>(null, RequestStatus.NotFound, $"No data for key: {key}");
            }
            else
            {
                return new RequestResult<dtObj.MetersData>(item, RequestStatus.Ok);
            }
        }
        #endregion

    }

    public class MdlNewHot
    {
        public MdlNewHot(dtObj.ObjectNews objectNews)
        {
            this.strText = objectNews.body;
        }
        public string strText { get; set; }
    }

    public class MdlPersonalAccountShort
    {
        public MdlPersonalAccountShort(dtObj.ObjKvLsShortOut data, ICommand cmdlSendData, ICommand cmdlPay)
        {
            this.strFIO = data.agreements.client_name;// .fio.ToString();
            this.strAddres = data.flat.full_address;// .ToString();
            this.strAccount = data.flat.uk_lsnumber;// .flatShortData.uk_account;
            this.strDogovor = data.agreements.dogovor;
            this.cmdlSendData = cmdlSendData;
            this.cmdlPay = cmdlPay; 
        }

        public string strFIO { get; set; }
        public string strAddres { get; set; }
        public string strAccount { get; set; }
        public string strDogovor { get; set; }

        public ICommand cmdlSendData { get; set; }
        public ICommand cmdlPay { get; set; }
    }
}
