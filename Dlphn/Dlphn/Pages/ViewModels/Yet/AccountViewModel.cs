using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dalWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using srvNavigation = Dlphn.Staff.Services.SrvNavigation;
using srvAuth = Dlphn.Staff.Services.SrvAuth;
using constEnums = Dlphn.Constants.ConstEnums;
using dtObj = Delphin.Abstraction.DataObjects;
using mdl = Dlphn.Models;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.AccountPage.AccountPage"/>
    public class AccountViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public AccountViewModel() : base(constEnums.Pages.AccountPage)
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
            var vKvLsServices = await dalWebApi.Kv.GetKvLsServices(objKvIn, cancellationToken);
            if (!vKvLsServices.IsValid)
            { }

            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlAccountItem(CmdLogOut));
            dataSource.Add(new mdl.MdlSpace());
            dataSource.Add(new mdl.MdlAccountChangePassword(CmdChangePassword));

            dataCollection.MgcReplaceRange(dataSource);
        }

        public ICommand CmdLogOut => MakeCommand(async () =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            await srvNavigation.Instance.NavigateTwo(constEnums.Pages.LoginPage, isNewNavigationStack: true);
            srvAuth.Instance.ClearAll();

            IsBusy = false;
        });

        public ICommand CmdChangePassword => MakeCommand(() =>
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
