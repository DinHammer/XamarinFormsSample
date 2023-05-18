using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using constEnums = Dlphn.Constants.ConstEnums;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.MetersPage.MetersPage"/>
    public class MetersViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public MetersViewModel() : base(constEnums.Pages.MetersPage)
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

            dtObj.ObjKvIn objKvIn = new dtObj.ObjKvIn(strToken, strAccountId);

            var vKvMetersDetail = await dalWebApi.Kv.GetKvMetersDetail(objKvIn, cancellationToken);
            if (!vKvMetersDetail.IsValid)
            { }

            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlMetersTitle());
            dataSource.Add(new mdl.MdlMetersItem(null, CmdBtn));

            dataCollection.MgcReplaceRange(dataSource);
        }

        public ICommand CmdBtn => MakeCommand(async (item) =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            await srvNavigation.Instance.NavigateTwo(
               constEnums.Pages.MeterHistoryPage);
            //await srvNavigation.Instance.NavigateTwo(Constants.ConstEnums.Pages.SendMetersPage);

            IsBusy = false;
        });

        #endregion
    }
}
