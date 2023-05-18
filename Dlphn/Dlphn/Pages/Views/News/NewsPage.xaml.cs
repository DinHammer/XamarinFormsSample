using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dtTemplate = Dlphn.Staff.DataTemplates;
using mdl = Dlphn.Models;
using viewModels = Dlphn.Pages.ViewModels;

namespace Dlphn.Pages.Views.News
{

    /// <see cref="Dlphn.Pages.ViewModels.News.NewsViewModel"/>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
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
                else if (item is mdl.MdlNewsTitle mdlNewsTitle)
                {
                    return new dtTemplate.DtNewsTitle(mdlNewsTitle);
                }
                else if (item is mdl.MdlNewsDataShort mdlNewsDataShort)
                {
                    return new dtTemplate.DtNewsDataShort(mdlNewsDataShort);
                }
                else
                {
                    return new dtTemplate.DtEmpty();
                }
            }
        }
    }
}