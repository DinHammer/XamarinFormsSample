using System;
using System.Collections.Generic;
using System.Text;
using constEnum = Dlphn.Constants.ConstEnums;

namespace Dlphn.Pages.ViewModels.Yet
{
    /// <see cref="Dlphn.Pages.Views.Yet.ContactsPage.ContactsPage"/>
    public class ContactsViewModel : BaseViewModel
    {
        #region Constructors

        public ContactsViewModel() : base(constEnum.Pages.ContactsPage)
        { }

        #endregion

    }
}
