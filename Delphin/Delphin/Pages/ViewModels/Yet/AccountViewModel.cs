using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delphin.Pages.ViewModels.Yet
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Yet.AccountPage">
    public class AccountViewModel : BaseViewModel
    {
        public ICommand cmd_go_back => MakeCommand(() =>
        {
            NavigateBack(mode: Constants.ConstantEnum.EnumClientMobile.NavigationMode.Modal);
        });
    }
}
