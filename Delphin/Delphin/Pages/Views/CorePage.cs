using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using viewModels = Delphin.Pages.ViewModels;
using constNumeric = Delphin.Constants.ConstantNumeric;

namespace Delphin.Pages.Views
{
    public class CorePage : ContentPage, IDisposable
    {
        protected viewModels.BaseViewModel BaseViewModel => BindingContext as viewModels.BaseViewModel;

        public CorePage() { }

        public string str_page_name { get; set; }

        public void Dispose()
        {
            BaseViewModel?.Dispose();
        }

        public void SetAutomationId(string automationId)
        {
            this.AutomationId = automationId;
        }

        public void SetTitle(string text)
        {
            this.Title = text;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
            {
                Dispose();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await Task.Delay(constNumeric.event_handler_loop);// Allow UI to handle events loop
                if (BaseViewModel != null)
                {
                    await BaseViewModel.OnPageAppearing();
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Task.Run(async () =>
            {
                await Task.Delay(constNumeric.event_handler_loop);// Allow UI to handle events loop
                if (BaseViewModel != null)
                {
                    await BaseViewModel.OnPageDisappearing();
                }
            });
        }

        public class BasePage<T> : BasePage where T : viewModels.BaseViewModel
        {
            public T ViewModel => BaseViewModel as T;
        }
    }
}
