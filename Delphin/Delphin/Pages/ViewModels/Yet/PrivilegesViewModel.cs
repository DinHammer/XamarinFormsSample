using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delphin.Pages.ViewModels.Yet
{
    /// <see cref="Delphin.Pages.Views.Yet.PrivilegesPage">
    public class PrivilegesViewModel : BaseViewModel
    {
        public ICommand cmd_go_back => MakeCommand(() =>
        {
            NavigateBack(mode: Constants.ConstantEnum.EnumClientMobile.NavigationMode.Modal);
        });
    }
}
