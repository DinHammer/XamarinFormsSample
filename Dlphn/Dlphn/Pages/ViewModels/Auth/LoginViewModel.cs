using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using constEnums = Dlphn.Constants.ConstEnums;
using srv = Dlphn.Staff.Services;
using dalSrvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;
using dtObj = Delphin.Abstraction.DataObjects;
using srvAuth = Dlphn.Staff.Services.SrvAuth;
using System.Linq;
using Dlphn.Constants;

namespace Dlphn.Pages.ViewModels.Auth
{
    /// <see cref="Dlphn.Pages.Views.Auth.LoginPage.LoginPage"/>
    public class LoginViewModel : BaseViewModel
    {
        #region Fields
        private string strUserData = string.Empty;
        private string strPassword = string.Empty;
        #endregion

        #region Properties
        public string StrUserData
        {
            get => Get(strUserData);
            set => Set(value);
        }

        public string StrPassword
        {
            get => Get(strPassword);
            set => Set(value);
        }
        #endregion

        #region Constructors
        public LoginViewModel() : base(constEnums.Pages.LoginPage)
        {
#if DEBUG
            switch (App.typeAppStart)
            {
                case App.TypeAppStart.tpDebugLogin:
                    strUserData = ConstString.KeyMoq.strPhone;
                    strPassword = ConstString.KeyMoq.strPassoword;
                    break;
            }
#endif
        }
        #endregion

        #region Methods
        public ICommand CmdLogin => MakeCommand(async () =>
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            dtObj.ObjLoginIn objLoginIn = new dtObj.ObjLoginIn(StrUserData, StrPassword);
            var vOut = await dalSrvWebApi.Users.GetLoggIn(objLoginIn, cancellationToken);
            if (!vOut.IsValid)
            {                
                IsBusy = false;
                return;
            }
            string strTokenAccess = vOut.Data.tokens.access;
            //string strTokenRefresh = vOut.Data.tokens.refresh;

            var vTokens = await srvAuth.Instance.SetTokens(vOut.Data.tokens);
            if (!vTokens.IsValid)
            {
                IsBusy = false;
                return;
            }

            string strUserId= vOut.Data.user;
            var vAccountFirst= await srvAuth.Instance.SetUserId(strUserId);
            if (!vAccountFirst.IsValid)
            {
                IsBusy = false;
                return;
            }

            dtObj.ObjUserAccountIn objIn = new dtObj.ObjUserAccountIn(strUserId, strTokenAccess);
            var vAccount = await dalSrvWebApi.Users.GetAccounts(objIn, cancellationToken);
            if (!vAccount.IsValid)
            {
                IsBusy = false;
                return;
            }

            var vAccountId = await srvAuth.Instance.SetAccountId(vAccount.Data.objects.First().tabn);
            if (!vAccountId.IsValid)
            {
                IsBusy = false;
                return;
            }

            await srv.SrvNavigation.Instance.NavigateTwo(constEnums.Pages.MainPage, isNewNavigationStack: true);
        });
        #endregion
    }
}
