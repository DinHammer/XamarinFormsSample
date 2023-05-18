using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Auth
{
    /// <see cref="Dlphn.Pages.Views.Auth.CheckCodeByPhonePage.CheckCodeByPhonePage"/>
    [QueryProperty(nameof(StrTitle), nameof(StrTitle))]
    public class CheckCodeByPhoneViewModel : BaseViewModel
    {
        #region Methods

        private string strUserCode = string.Empty;
        private string strTitle = string.Empty;

        #endregion

        #region Properties

        public string StrUserCode
        {
            get => Get(strUserCode);
            set => Set(value);
        }

        public string StrTitle
        {
            get => Get(strTitle);
            set => Set(value);
        }

        #endregion

        #region Constructors

        public CheckCodeByPhoneViewModel() : base(constEnum.Pages.TmpPage)
        { }

        #endregion

        #region Methods
        #endregion
    }
}
