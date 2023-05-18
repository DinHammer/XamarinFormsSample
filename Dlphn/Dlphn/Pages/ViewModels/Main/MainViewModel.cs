using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using srvAuth = Dlphn.Staff.Services.SrvAuth;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using System.Linq;
using System.Windows.Input;
using DevDH.Magic.Abstractions;
using System.Threading;
using smpTools = Dlphn.Staff.SimpleTools;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Main
{
    /// <see cref="Dlphn.Pages.Views.Main.MainPage.MainPage"/>
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public MainViewModel(bool isTest) : base(isTest)
        {
        }
        public MainViewModel(): base(constEnum.Pages.MainPage)
        {            
        }
        #endregion

        #region Methods
        public override async Task OnPageAppearing()
        {
            //return base.OnPageAppearing();            

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

            
            dtObj.ObjNewsIn objNewsIn = new dtObj.ObjNewsIn(strToken, strAccountId);
            dtObj.ObjKvIn objKvIn = new dtObj.ObjKvIn(strToken, strAccountId);

            #region NewsHot

            var vNewsHot = await dalWebApi.News.GetNewsHot(objNewsIn, cancellationToken);
            if (vNewsHot.IsValid)
            {

                var vHot = FillNewsHot(vNewsHot.Data);

                if (vHot.IsValid)
                {
                    prtAddItemsInDataSource(dataSource, vHot.Data);
                }
                else
                {
                    prtOnPageAppearingTrackError(
                        nameof(FillNewsHot),
                        vHot);
                }
                
            }
            else
            {
                prtOnPageAppearingTrackError(                    
                    nameof(dalWebApi.News.GetNewsHot),
                    vNewsHot);
                //prtSetError(vNewsHot);
                //return;
            }

            #endregion


            #region LicevoiSchetShort

            var vKvShort = await dalWebApi.Kv.GetKvLsShort(objKvIn, cancellationToken);
            if (vKvShort.IsValid)
            {
                mdl.MdlPersonalAccountShort mdlPersonalAccount = new mdl.MdlPersonalAccountShort(vKvShort.Data, CmdSendData, CmdPay);
                dataSource.Add(mdlPersonalAccount);
                dataSource.Add(new mdl.MdlSpace());
            }
            else
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.Kv.GetKvLsShort),
                    vKvShort);
                //prtSetError(vNewsHot);
                //return;
            }

            #endregion


            #region KvMetersLatest
            
            var vKvMettersLastData = await dalWebApi.Kv.GetKvMetersLatest(objKvIn, cancellationToken);

            if (vKvMettersLastData.IsValid)
            {
                var vMetersLatest = FillMetersLatestCells(vKvMettersLastData.Data.lstMetersData);

                if (vMetersLatest.IsValid)
                {
                    prtAddItemsInDataSource(dataSource, vMetersLatest.Data);
                    dataSource.Add(new mdl.MdlSpace());
                }
                else
                {
                    prtOnPageAppearingTrackError(
                        nameof(FillMetersLatestCells),
                        vMetersLatest);
                }
            }
            else
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.Kv.GetKvMetersLatest),
                    vKvMettersLastData);
            }

            
            

            #endregion

            #region NewsLast

            var vNewsLast = await dalWebApi.News.GetNewsLatest(objNewsIn, cancellationToken);
            if (vNewsLast.IsValid)
            {
                if (vNewsLast.Data.IsValid())
                {
                    foreach (var item in vNewsLast.Data.latestnews)
                    {
                        dataSource.Add(new mdl.MdlNewsOneData(item));
                    }

                    dataSource.Add(new mdl.MdlNewsGoTo(CmdNewsGoTo));
                }
            }
            else
            {
                prtOnPageAppearingTrackError(                    
                    nameof(dalWebApi.News.GetNewsLatest),
                    vNewsLast);
                prtSetError(vNewsHot);
                return;
            }

            #endregion

            dataCollection.MgcReplaceRange(dataSource);
        }

        public RequestResult<IList<object>> FillNewsHot(dtObj.ObjNewsHotOut objNewsHotOut)
        {
            if (objNewsHotOut.hotnews.Count == 0)
            {
                return new RequestResult<IList<object>>(null, RequestStatus.NoContent);
            }

            List<object> lstOut = new List<object>();
            mdl.MdlNewHot mdlNewHot = new mdl.MdlNewHot(objNewsHotOut.hotnews.First());
            lstOut.Add(mdlNewHot);

            return new RequestResult<IList<object>>(lstOut, RequestStatus.Ok);
        }

        public RequestResult<IList<object>> FillMetersLatestCells(
            List<dtObj. MetersData> lstMetersData)
        {

            List<object> output = new List<object>();
            output.Add(new mdl.MdlMetersLatestShortHeader());


            List<dtObj.MetersData> lstMetersDataClear = lstMetersData.Where(x =>
            !String.IsNullOrWhiteSpace(x.serv_printname) &&
            x.pokazanTarifs?.Count >= 1 &&
            !String.IsNullOrEmpty(x.shetchik_number)).ToList();
            
            if (lstMetersDataClear.Count == 0)
            {
                return new RequestResult<IList<object>>(null, RequestStatus.NoContent, "No valid MetersLatestCell data");
            }


            string strPokazanTarif = string.Empty;
            List<mdl.MdlMetersLatestShortData> items = new List<mdl.MdlMetersLatestShortData>();

            foreach (dtObj.MetersData metersData in lstMetersDataClear)
            {
                foreach (dtObj.PokazanTarif pokazanTarif in metersData.pokazanTarifs)
                {
                    strPokazanTarif = pokazanTarif.pokazan_date;
                    var vDateTime = smpTools.Instance.mgcConvertString2DateTime(strPokazanTarif);

                    if (vDateTime.IsValid)
                    {
                        items.Add(new mdl.MdlMetersLatestShortData(metersData, pokazanTarif, vDateTime.Data.DateTime));
                    }
                    else
                    {
                        prtTrackEvent(nameof(FillMetersLatestCells),
                            vDateTime);                        
                    }
                }
            }

            List<DateTime> lstDateTimes = items.GroupBy(x => x.dateTime).Select(x => x.Key).ToList<DateTime>();

            if (lstDateTimes.Count == 0)
            {
                return new RequestResult<IList<object>>(null, RequestStatus.NoContent, "No valid MetersLatestCell dateTimes");
            }

            foreach (DateTime dt in lstDateTimes)
            {
                List< mdl.MdlMetersLatestShortData> tmpMetersData = items.Where(x => x.dateTime == dt).ToList();
                output.Add(new mdl.MdlMetersLatestShortDate(dt));
                var groupByMetersNumber = tmpMetersData.GroupBy(x => x.StrMetersNumber);

                foreach (var item in groupByMetersNumber)
                {
                    output.Add(new mdl.MdlMetersLatestShortMetersNumber(item.Key));

                    foreach (var tmp in item)
                    {
                        output.Add(tmp);
                    }
                }
            }
            
            return new RequestResult<IList<object>>(output,RequestStatus.Ok);
        }        
        



        public ICommand CmdSendData => MakeCommand(async () =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            await srvNavigation.Instance.NavigateTwo(Constants.ConstEnums.Pages.SendMetersPage);

            IsBusy = false;
        });

        public ICommand CmdPay => MakeCommand(() =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            prtShowTbdMessage();


            IsBusy = false;
        });

        public ICommand CmdNewsGoTo => MakeCommand( async() =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            await srvNavigation.Instance.NavigateTwo(Constants.ConstEnums.Pages.NewsPage, isNewNavigationStack: true);


            IsBusy = false;
        });


        #endregion

    }
}
