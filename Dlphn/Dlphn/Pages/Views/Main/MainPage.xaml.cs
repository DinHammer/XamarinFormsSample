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
    /// <see cref="Dlphn.Pages.ViewModels.Main.MainViewModel"/>
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            collectionView.ItemTemplate = new TemplateSelector();
        }

        #region OnPageAction

        viewModels.BaseViewModel baseViewModel=>BindingContext as viewModels.BaseViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run( async() => 
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
                else if (item is mdl.MdlNewHot mdlNewHot)
                {
                    return new dtTemplate.DtNewHot(mdlNewHot);
                }
                else if (item is mdl.MdlSpace mdlSpace)
                {
                    return new dtTemplate.DtSpace();
                }
                else if (item is mdl.MdlPersonalAccountShort mdlPersonalAccountShort)
                {
                    return new dtTemplate.DtPersonalAccountShort(mdlPersonalAccountShort);
                }
                else if (item is mdl.MdlMetersLatestShortDate mdlMetersLatestShortDate)
                {
                    return new dtTemplate.DtMettersLatestShortDate(mdlMetersLatestShortDate);
                }
                else if (item is mdl.MdlMetersLatestShortHeader mdlMetersLatestShortHeader)
                {
                    return new dtTemplate.DtMettersLatestShortHeader();
                }
                else if (item is mdl.MdlMetersLatestShortData mdlMetersLatestShortData)
                {
                    return new dtTemplate.DtMettersLatestShortData(mdlMetersLatestShortData);
                }
                else if (item is mdl.MdlMetersLatestShortMetersNumber mdlMetersLatestShortMetersNumber)
                {
                    return new dtTemplate.DtMettersLatestShortMeterNumber(mdlMetersLatestShortMetersNumber);
                }
                else if (item is mdl.MdlNewsOneData mdlNewsOneData)
                {
                    return new dtTemplate.DtNewsOneData(mdlNewsOneData);
                }
                else if (item is mdl.MdlNewsGoTo mdlNewsGoTo)
                {
                    return new dtTemplate.DtNewsGoTo(mdlNewsGoTo);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }                                
            }
        }
    }
}