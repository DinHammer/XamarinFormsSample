using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using srvAuth = Dlphn.Staff.Services.SrvAuth;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using srvImage = Dlphn.Staff.Services.SrvImage;
using constString = Dlphn.Constants.ConstString;
using constEnum = Dlphn.Constants.ConstEnums;
using System.Windows.Input;
using DevDH.Magic.Abstractions;
using smpTools = Dlphn.Staff.SimpleTools;

namespace Dlphn.Pages.ViewModels.History
{
    /// <see cref="Dlphn.Pages.Views.History.HistoryPage.HistoryPage"/>
    public class HistoryViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public HistoryViewModel(bool isTest) : base(isTest)
        { }
        public HistoryViewModel() : base(constEnum.Pages.HistoryPage)
        {
            //dataCollection = new DevDH.Magic.Abstractions.Magic.MgcObservableCollection<object>();
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

            var vKvFlowLatest = await dalWebApi.Kv.GetKvFlowLatest(new dtObj.ObjKvIn(strToken, strAccountId), cancellationToken);
            if (vKvFlowLatest.IsValid)
            {

                var vData = FillKvFlowLatest(vKvFlowLatest.Data);
                if (vData.IsValid)
                {
                    prtAddItemsInDataSource(dataSource, vData.Data);
                }
                else
                {
                    prtOnPageAppearingTrackError(
                    nameof(FillKvFlowLatest),
                    vData);
                }
                
            }
            else
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.Kv.GetKvFlowLatest),
                    vKvFlowLatest);
                prtSetError(vKvFlowLatest);
                return;
            }

            dataCollection.MgcReplaceRange(dataSource);
        }

        public RequestResult<IList<object>> FillKvFlowLatest(dtObj.ObjKvFlowLatest objKvFlowLatest)
        {
            IList<object> vOut=new List<object>();

            bool isValid = objKvFlowLatest.lstCashFlow?.Count > 0;

            if (isValid==false)
            {
                return new RequestResult<IList<object>>(null, RequestStatus.NoContent, "No valid data");
            }

            var vStart = smpTools.Instance.GetDateSatartAndFinishFromLstCashFlow(objKvFlowLatest.lstCashFlow);

            if (!vStart.IsValid)
            {
                return new RequestResult<IList<object>>(null, vStart.Status, vStart.Message);
            }

            vOut.Add(new mdl.MdlHistoryHeader(vStart.Data));

            Xamarin.Forms.ImageSource imageSource = null;

            var vImage = srvImage.Instance.GetImage(constString.KeyImage.HistoryDataImage);
            if (!vImage.IsValid)
            {
                return new RequestResult<IList<object>>(null, vImage.Status, vImage.Message);
            }

            imageSource = vImage.Data;


            int count = objKvFlowLatest.lstCashFlow.Count;
            dtObj.CashFlow cashFlow = null;
            Xamarin.Forms.Style style = null;

            for (int i = 0; i < count; i++)
            {
                var vStyle = GetStyleById(i);

                if (vStyle.IsValid)
                {
                    style = vStyle.Data;
                }
                else
                {
                    prtTrackEvent(nameof(FillKvFlowLatest), vStyle);
                }

                cashFlow = objKvFlowLatest.lstCashFlow[i];
                vOut.Add(new mdl.MdlHistoryData(cashFlow, style, imageSource, CmdGoTo));
            }

            return new RequestResult<IList<object>>(vOut, RequestStatus.Ok);
        }

        RequestResult<Xamarin.Forms.Style> GetStyleById(int id)
        {
            string key = "stlLblBlue";            
            int value = id % 2;

            if (value == 0)
            {
                key = "stlLblRed";
            }

            return smpTools.Instance.GetXamarinStyleByKey(key);
            
        }

        public ICommand CmdGoTo => MakeCommand(async (item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            int id = ((dtObj.CashFlow)item).id;

           await srvNavigation.Instance.NavigateTwo(
               Constants.ConstEnums.Pages.HistoryDetailPage,
               strNavigationParams: $"{nameof(HistoryDetailViewModel.StrId)}={id}");

            IsBusy = false;
        });


        public ICommand CmdAllOperations => MakeCommand((item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            prtShowTbdMessage();

            IsBusy = false;
        });

        public ICommand CmdAllCharges => MakeCommand((item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            prtShowTbdMessage();

            IsBusy = false;
        });

        public ICommand CmdPayments => MakeCommand((item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            prtShowTbdMessage();

            IsBusy = false;
        });

        #endregion
    }
}
