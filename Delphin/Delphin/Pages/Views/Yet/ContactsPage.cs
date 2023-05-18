using System;
using System.Collections.Generic;
using System.Text;
using constText = Delphin.Constants.ConstantText;
using viewModel = Delphin.Pages.ViewModels.Yet;
using customView = Delphin.Staff.Customs.Controls;
using Xamarin.Forms;

namespace Delphin.Pages.Views.Yet
{
    /// <see cref="Delphin.Pages.ViewModels.Yet.ContactsViewModel">
    public class ContactsPage : BasePage
    {
        viewModel.ContactsViewModel viewModel;
        public ContactsPage()
        {
            viewModel = this.BindingContext as viewModel.ContactsViewModel;

            double height = prtcGetHeight();
            customView.MagicModalToolbar toolbar = new customView.MagicModalToolbar(constText.PageText.Yet.Contacts.title, height);
            toolbar.SetBinding(customView.MagicModalToolbar.PropertyCommandBack, nameof(viewModel.cmd_go_back));

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(toolbar);

            this.Content = stackLayout;
        }
    }
}
