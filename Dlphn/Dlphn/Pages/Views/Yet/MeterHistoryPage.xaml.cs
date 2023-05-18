using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using viewModels = Dlphn.Pages.ViewModels;
using mdl = Dlphn.Models;
using dtTemplate = Dlphn.Staff.DataTemplates;

namespace Dlphn.Pages.Views.Yet
{
    /// <see cref="Dlphn.Pages.ViewModels.Yet.MeterHistoryViewModel.MeterHistoryViewModel"/>


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeterHistoryPage : ContentPage
    {
        public MeterHistoryPage()
        {
            InitializeComponent();
            collectionView.ItemTemplate = new TemplateSelector();
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

        class TemplateSelector : DataTemplateSelector
        {
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                if (item is mdl.MdlError mdlError)
                {
                    return new dtTemplate.DtError(mdlError);
                }                
                else if (item is mdl.MdlMeterHistoryTitle mdlMeterHistoryTitle)
                {
                    return new dtTemplate.DtMeterHistoryTitle(mdlMeterHistoryTitle);
                }
                else if (item is mdl.MdlMeterHistoryItem mdlMeterHistoryItem)
                {
                    return new dtTemplate.DtMeterHistoryItem(mdlMeterHistoryItem);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }
            }
        }
    }
}