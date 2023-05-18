using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delphin.Pages.ViewModels.Yet
{
    /// <see cref="Delphin.Pages.Views.Yet.PersonalAccountPage">
    public class PersonalAccountViewModel : BaseViewModel
    {
        public ICommand cmd_go_back => MakeCommand(() =>
        {
            NavigateBack(mode: Constants.ConstantEnum.EnumClientMobile.NavigationMode.Modal);
        });
    }
}
