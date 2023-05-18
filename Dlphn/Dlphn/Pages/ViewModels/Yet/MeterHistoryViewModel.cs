using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.MeterHistoryPage.MeterHistoryPage"/>
    public class MeterHistoryViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public MeterHistoryViewModel() : base(constEnum.Pages.MeterHistoryPage)
        { }

        #endregion

        #region Methods

        public override async Task OnPageAppearing()
        {
            dataSource.Clear();

            var vPersonalData = await prtGetPersonalData();
            if (!vPersonalData.IsValid)
            {
                return;
            }

            string strToken = vPersonalData.Data.StrToken;
            string strAccountId = vPersonalData.Data.StrAccountId;

            dtObj.ObjKvMetersIn objKvMetersIn = new dtObj.ObjKvMetersIn(strToken, strAccountId);

            var vKvMetersHistory = await dalWebApi.Kv.GetKvMetersHistory(objKvMetersIn, cancellationToken);
            if (!vKvMetersHistory.IsValid)
            { }

            dataSource.Add(new mdl.MdlMeterHistoryTitle());
            dataSource.Add(new mdl.MdlMeterHistoryItem());

            dataCollection.MgcReplaceRange(dataSource);
        }

        #endregion
    }
}
