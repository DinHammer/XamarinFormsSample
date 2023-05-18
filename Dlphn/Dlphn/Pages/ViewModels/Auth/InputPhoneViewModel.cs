using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using constString = Dlphn.Constants.ConstString;
using viewsAuth = Dlphn.Pages.Views.Auth;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Auth
{
    /// <see cref="Dlphn.Pages.Views.Auth.InputPhonePage.InputPhonePage"/>    
    public class InputPhoneViewModel : BaseViewModel
    {
        #region Methods
        private string strPhone=string.Empty;
        private string strUserPhone = string.Empty;
        #endregion

        #region Properties
        public string StrPhone
        {
            get => Get(strPhone);
            set=> Set(value);
        }

        #endregion

        #region Constructors

        public InputPhoneViewModel() : base(constEnum.Pages.TmpPage)
        {
            StrPhone = "+";
        }

        #endregion

        #region Methods
        public ICommand CmdCheckCodeByPhone => MakeCommand( async() =>
        {
            await Xamarin.Forms.Shell.Current.GoToAsync($"{nameof(viewsAuth.CheckCodeByPhonePage)}?{nameof(CheckCodeByPhoneViewModel.StrTitle)}={StrPhone}");
        });

        public ICommand CmdInputLoginAndPassword => MakeCommand(() =>
        {
            //await Shell.Current.GoToAsync($"{nameof(viewsAuth.CheckSmsCodePage)}");
        });
        #endregion
    }
}
