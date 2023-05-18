using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using srvAuth = Dlphn.Staff.Services.SrvAuth;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using DevDH.Magic.Abstractions;
using Xamarin.Forms;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.History
{
    /// <see cref="Dlphn.Pages.Views.History.HistoryDetailPage.HistoryDetailPage"/>
    [QueryProperty(nameof(StrId), nameof(StrId))]
    public class HistoryDetailViewModel : BaseViewModel
    {
        #region Fields

        private string _strId;

        #endregion

        #region Properties

        public string StrId
        {
            get => Get(_strId);
            set => Set(value);
        }

        #endregion

        #region Constructors

        public HistoryDetailViewModel() : base(constEnum.Pages.HistoryDetailPage)
        {
            //dataCollection = new DevDH.Magic.Abstractions.Magic.MgcObservableCollection<object>();
        }

        #endregion

        #region Methods

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

#if DEBUG
            StrId = "1";
#endif

            var vTmp = await dalWebApi.Kv.GetKvFlowDetails(new dtObj.ObjKvFlowDetailIn(StrId, strToken), cancellationToken);
            if (!vTmp.IsValid)
            {
                prtOnPageAppearingTrackError(
                    nameof(dalWebApi.Kv.GetKvFlowDetails),
                    vTmp);

                prtSetError(vTmp);

                return;
            }

            dataCollection.MgcReplaceRange(dataSource);
        }

        

        #endregion
    }
}
