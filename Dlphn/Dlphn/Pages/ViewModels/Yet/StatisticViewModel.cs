using System;
using System.Collections.Generic;
using System.Text;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.StatisticPage.StatisticPage"/>
    public class StatisticViewModel : BaseViewModel
    {
        #region Constructors

        public StatisticViewModel() : base(constEnum.Pages.StatisticPage)
        { }

        #endregion
    }
}
