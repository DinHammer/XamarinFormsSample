using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using viewModels = Dlphn.Pages.ViewModels;

namespace Dlphn.Pages.Views.Tmp
{
    /// <see cref="Dlphn.Pages.ViewModels.Tmp.TmpViewModel"/>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TmpPage : ContentPage
    {
        public TmpPage()
        {
            InitializeComponent();

            //frame.ra
        }

        #region OnPageAction

        viewModels.BaseViewModel baseViewModel => BindingContext as viewModels.BaseViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await Task.Delay(Dlphn.Constants.ConstNumeric.event_handler_loop);
                if (baseViewModel != null)
                {
                    await baseViewModel.OnPageAppearing();
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Task.Run(async () =>
            {
                await Task.Delay(Dlphn.Constants.ConstNumeric.event_handler_loop);
                if (baseViewModel != null)
                {
                    await baseViewModel.OnPageDisappearing();
                }
            });
        }

        #endregion
    }
}