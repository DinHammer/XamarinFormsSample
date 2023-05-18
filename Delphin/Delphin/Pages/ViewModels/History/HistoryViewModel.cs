using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Input;
using constEnum = Delphin.Constants.ConstantEnum;

namespace Delphin.Pages.ViewModels.History
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.History.HistoryPage">
    public class HistoryViewModel : BaseViewModel
    {

        private Xamarin.Forms.Color _color_toolbar = Xamarin.Forms.Color.Black;
        public Xamarin.Forms.Color color_toolbar
        {
            get => Get(_color_toolbar);
            set => Set(value);
        }

        public ICommand cmd_go_to_history_payment => MakeNavigateToCommand(constEnum.EnumClientMobile.Pages.HistoryPayment, constEnum.EnumClientMobile.NavigationMode.Modal);
    }
}
