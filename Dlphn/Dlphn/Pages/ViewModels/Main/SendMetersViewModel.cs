using System;
using System.Collections.Generic;
using System.Text;

using srvAuth = Dlphn.Staff.Services.SrvAuth;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
using smpTools = Dlphn.Staff.SimpleTools;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Main
{
    /// <see cref="Dlphn.Pages.Views.Main.SendMetersPage.SendMetersPage"/>
    public class SendMetersViewModel: BaseViewModel
    {
        #region Fields
        private string strEnergyValue = string.Empty;
        #endregion

        #region Properties

        public string StrEnergyValue
        {
            get => Get(strEnergyValue);
            set => Set(value);
        }

        private mdl.MdlMeterEnergyData energyData { get; set; }

        #endregion

        #region Constructors

        public SendMetersViewModel() : base(constEnum.Pages.SendMetersPage)
        { }

        #endregion

        public override async Task OnPageAppearing()
        {
            dataSource.Clear();            

            var vPersonalData = await prtGetPersonalData();
            if (!vPersonalData.IsValid)
            {
                prtOnPageAppearingTrackError(                
                    nameof(prtGetPersonalData),
                    vPersonalData);
                return;
            }

            string strToken = vPersonalData.Data.StrToken;
            string strAccountId = vPersonalData.Data.StrAccountId;
            
            dtObj.ObjKvIn objIn = new dtObj.ObjKvIn(vPersonalData.Data.StrToken, vPersonalData.Data.StrAccountId);
            var vOut = await dalWebApi.Kv.GetKvMetersData(objIn, cancellationToken);

            if (vOut.IsValid)
            {

                var vCellData = FillCells(vOut.Data.lstMetersData);

                if (vCellData.IsValid)
                {
                    prtAddItemsInDataSource(dataSource, vCellData.Data);
                }
                else
                {
                    prtOnPageAppearingTrackError(
                    nameof(FillCells),
                    vCellData);
                }
            }
            else
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.Kv.GetKvMetersData),
                    vOut);
            }                        

            prtAdd2DataCollection(dataSource);
        }

        public RequestResult<IList<object>> FillCells(List<dtObj.MetersData> lstMetersData)
        {
            List<object> lstOutput = new List<object>();
            List<mdl.MdlMetersDataHistoryValue> lstHistory = new List<mdl.MdlMetersDataHistoryValue>();

            List<dtObj.MetersData> lstMetersDataClear = lstMetersData.Where(x =>
            !String.IsNullOrWhiteSpace(x.serv_printname) &&
            x.pokazanTarifs?.Count >= 1 &&
            !String.IsNullOrEmpty(x.shetchik_number)).ToList();

            if (lstMetersDataClear.Count == 0)
            {
                return new RequestResult<IList<object>>(null, RequestStatus.NoContent, "No valid MetersData data");
            }

            mdl.MdlMeterDataSendHeader mdlMeterDataSendHeader = null;
            mdl.MdlMeterDataSendNo mdlMeterDataSendNo = null;
            foreach (dtObj.MetersData metersData in lstMetersDataClear)
            {
                mdlMeterDataSendHeader = new mdl.MdlMeterDataSendHeader(metersData);
                lstOutput.Add(mdlMeterDataSendHeader);

                foreach (dtObj.PokazanTarif pokazanTarif in metersData.pokazanTarifs)
                {
                    mdlMeterDataSendNo = new mdl.MdlMeterDataSendNo(metersData, pokazanTarif);
                    lstOutput.Add(mdlMeterDataSendNo);
                    var vDate = smpTools.Instance.mgcConvertString2DateTime(pokazanTarif.pokazan_date);

                    if (vDate.IsValid)
                    {
                        lstHistory.Add(new mdl.MdlMetersDataHistoryValue(metersData, pokazanTarif, vDate.Data.DateTime));
                    }
                    else
                    {
                        prtTrackEvent(nameof(FillCells),
                            vDate);
                    }
                    
                }
            }

            lstOutput.Add(new mdl.MdlMeterDataSendButton(CmdSendData));
            lstOutput.Add(new mdl.MdlMetersDataHistoryHeader());
            List<DateTime> lstDateTime = lstHistory.GroupBy(x=>x.DtMeasurement).Select(x => x.Key).ToList();

            foreach (DateTime dateTime in lstDateTime)
            {
                lstOutput.Add(new mdl.MdlMetersDataHistoryDate(dateTime));
                var vDataByDateTime = lstHistory.Where(x => x.DtMeasurement == dateTime).ToList();
                vDataByDateTime.ForEach(x => lstOutput.Add(x));
            }            

            return new RequestResult<IList<object>>(lstOutput, RequestStatus.Ok);
        }

        public ICommand CmdSendData => MakeCommand(() =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            //string str = energyData.StrEnergeyValue;


            IsBusy = false;
        });
    }
}
