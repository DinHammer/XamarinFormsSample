using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mdl = Dlphn.Models;
using dtTemplate = Dlphn.Staff.DataTemplates;

namespace Dlphn.Pages.Views.Yet
{
    /// <see cref="Dlphn.Pages.ViewModels.Yet.YetViewModel"/>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YetPage : ContentPage
    {
        public YetPage()
        {
            InitializeComponent();

            collectionView.ItemTemplate = new TemplateSelector();
            
        }

        #region OnPageAction

        Dlphn.Pages.ViewModels.BaseViewModel baseViewModel => BindingContext as Dlphn.Pages.ViewModels.BaseViewModel;

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
                if (item is mdl.MdlYetCell mdlYetCell)
                {
                    return new dtTemplate.DtYetCell(mdlYetCell);
                }
                if (item is mdl.MdlError mdlError)
                {
                    return new dtTemplate.DtError(mdlError);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }
            }
        }
    }
}