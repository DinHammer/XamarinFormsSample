using System;
using System.Collections.Generic;
using System.Text;
using constText = Delphin.Constants.ConstantText;
using viewModel = Delphin.Pages.ViewModels.Yet;
using customView = Delphin.Staff.Customs.Controls;
using Xamarin.Forms;

namespace Delphin.Pages.Views.Yet
{
    /// <see cref="Delphin.Pages.ViewModels.Yet.PersonalAccountViewModel">
    public class PersonalAccountPage: BasePage
    {
        viewModel.PersonalAccountViewModel viewModel;
        public PersonalAccountPage()
        {
            viewModel = this.BindingContext as viewModel.PersonalAccountViewModel;

            double height = prtcGetHeight();
            customView.MagicModalToolbar toolbar = new customView.MagicModalToolbar(constText.PageText.Yet.PersonalAccount.title, height);
            toolbar.SetBinding(customView.MagicModalToolbar.PropertyCommandBack, nameof(viewModel.cmd_go_back));

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(toolbar);

            this.Content = stackLayout;
        }
    }
}
