using System;
using System.Collections.Generic;
using System.Text;
using constText = Delphin.Constants.ConstantText;
using viewModel = Delphin.Pages.ViewModels.Yet;
using customView = Delphin.Staff.Customs.Controls;
using Xamarin.Forms;

namespace Delphin.Pages.Views.Yet
{
    /// <see cref="Delphin.Pages.ViewModels.Yet.CountersViewModel">
    public class CountersPage: BasePage
    {
        viewModel.CountersViewModel viewModel;
        public CountersPage()
        {
            viewModel = this.BindingContext as viewModel.CountersViewModel;

            double height = prtcGetHeight();
            customView.MagicModalToolbar toolbar = new customView.MagicModalToolbar(constText.PageText.Yet.Counters.title, height);
            toolbar.SetBinding(customView.MagicModalToolbar.PropertyCommandBack, nameof(viewModel.cmd_go_back));

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(toolbar);

            this.Content = stackLayout;
        }
    }
}
