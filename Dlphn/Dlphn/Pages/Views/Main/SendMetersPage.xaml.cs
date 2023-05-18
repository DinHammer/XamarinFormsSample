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

namespace Dlphn.Pages.Views.Main
{
    /// <see cref="Dlphn.Pages.ViewModels.Main.SendMetersViewModel.SendMetersViewModel"/>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendMetersPage : ContentPage
    {
        public SendMetersPage()
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
                else if (item is mdl.MdlSpace mdlSpace)
                {
                    return new dtTemplate.DtSpace();
                }
                else if (item is mdl.MdlMetersDataHistoryDate mdlMetersDataHistoryDate)
                {
                    return new dtTemplate.DtMetersDataHistoryDate(mdlMetersDataHistoryDate);
                }
                else if (item is mdl.MdlMetersDataHistoryHeader mdlMetersDataHistoryHeader)
                {
                    return new dtTemplate.DtMetersDataHistoryHeader(mdlMetersDataHistoryHeader);
                }
                else if (item is mdl.MdlMetersDataHistoryValue mdlMetersDataHistoryValue)
                {
                    return new dtTemplate.DtMetersDataHistoryValue(mdlMetersDataHistoryValue);
                }
                else if (item is mdl.MdlMeterDataSendButton mdlMetersDataSendButton)
                {
                    return new dtTemplate.DtMetersDataSendButton(mdlMetersDataSendButton);
                }
                else if (item is mdl.MdlMeterDataSendHeader mdlMetersDataSendHeader)
                {
                    return new dtTemplate.DtMetersDataSendHeader(mdlMetersDataSendHeader);
                }
                else if (item is mdl.MdlMeterDataSendNo mdlMetersDataSendNo)
                {
                    return new dtTemplate.DtMetersDataSendNo(mdlMetersDataSendNo);
                }
                else if (item is mdl.MdlMeterDataSendYes mdlMetersDataSendYes)
                {
                    return new dtTemplate.DtMetersDataSendYes(mdlMetersDataSendYes);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }
            }
        }
    }
}