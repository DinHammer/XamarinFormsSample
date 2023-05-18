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

    /// <see cref="Dlphn.Pages.ViewModels.Yet.PersonalAccountViewModel.PersonalAccountViewModel"/>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalAccountPage : ContentPage
    {
        public PersonalAccountPage()
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
                else if (item is mdl.MdlPersonalAccountItem mdlPersonalAccountItem)
                {
                    return new dtTemplate.DtPersonalAccountItem(mdlPersonalAccountItem);
                }
                else if (item is mdl.MdlPersonalAccountFlat mdlPersonalAccountFlat)
                {
                    return new dtTemplate.DtPersonalAccountFlat(mdlPersonalAccountFlat);
                }
                else if (item is mdl.MdlPersonalAccountRegisterResidentHeader mdlPersonalAccountRegisterResidentHeader)
                {
                    return new dtTemplate.DtPersonalAccountRegisterResidentHeader(mdlPersonalAccountRegisterResidentHeader);
                }
                else if (item is mdl.MdlPersonalAccountRegisterResidentItem mdlPersonalAccountRegisterResidentItem)
                {
                    return new dtTemplate.DtPersonalAccountRegisterResidentItem(mdlPersonalAccountRegisterResidentItem);
                }
                else if (item is mdl.MdlPersonalAccountServicesHeader mdlPersonalAccountServicesHeader)
                {
                    return new dtTemplate.DtPersonalAccountServicesHeader(mdlPersonalAccountServicesHeader);
                }
                else if (item is mdl.MdlPersonalAccountServicesItem mdlPersonalAccountServicesItem)
                {
                    return new dtTemplate.DtPersonalAccountServicesItem(mdlPersonalAccountServicesItem);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }
            }
        }
    }
}