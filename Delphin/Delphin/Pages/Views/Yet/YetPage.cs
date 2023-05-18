using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using constEnum = Delphin.Constants.ConstantEnum;
using viewModel = Delphin.Pages.ViewModels.Yet;
using stylePage = Delphin.Staff.Styles.StylePage;
using constText = Delphin.Constants.ConstantText;
using mdls = Delphin.Models;
using customCells = Delphin.Staff.Customs.Cells;
using FFImageLoading.Svg.Forms;
using srvImage = Delphin.Staff.Services.ServiceImage;

namespace Delphin.Pages.Views.Yet
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.ViewModels.Yet.YetViewModel">
    public class YetPage : BasePage
    {
        viewModel.YetViewModel viewModel;
        public YetPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            viewModel = this.BindingContext as viewModel.YetViewModel;

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(viewModel.PageDataCollection));
            collectionView.ItemTemplate = new TemplateSelector();
            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 10
            };
            collectionView.EmptyView = constText.PageText.lbl_text_downloading;
            collectionView.Style = stylePage.Yet.stlCollectionView;

            //SvgCachedImage svgCachedImage = new SvgCachedImage();
            //svgCachedImage.HeightRequest = 100;
            //svgCachedImage.WidthRequest = 100;
            ////svgCachedImage.Aspect = Aspect.AspectFit;
            //var img = srvImage.Instance.GetYetIcon(constEnum.EnumClientMobile.Pages.PersonalAccount);
            //svgCachedImage.Source = img;

            //StackLayout stackLayout = new StackLayout();
            //stackLayout.Children.Add(svgCachedImage);
            //stackLayout.Children.Add(collectionView);


            //Button btnPersonalAccount = new Button();
            //btnPersonalAccount.Text = constEnum.EnumClientMobile.Pages.PersonalAccount.ToString();
            //btnPersonalAccount.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToPersonalAccount));

            //Button btnCounters = new Button();
            //btnCounters.Text = constEnum.EnumClientMobile.Pages.Counters.ToString();
            //btnCounters.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToCounters));

            //Button btnRates = new Button();
            //btnRates.Text = constEnum.EnumClientMobile.Pages.Rates.ToString();
            //btnRates.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToRates));

            //Button btnPrivileges = new Button();
            //btnPrivileges.Text = constEnum.EnumClientMobile.Pages.Privileges.ToString();
            //btnPrivileges.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToPrivileges));

            //Button btnStatistics = new Button();
            //btnStatistics.Text = constEnum.EnumClientMobile.Pages.Statistics.ToString();
            //btnStatistics.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToStatistics));

            //Button btnAccount = new Button();
            //btnAccount.Text = constEnum.EnumClientMobile.Pages.Account.ToString();
            //btnAccount.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToAccount));

            //Button btnContacts = new Button();
            //btnContacts.Text = constEnum.EnumClientMobile.Pages.Contacts.ToString();
            //btnContacts.SetBinding(Button.CommandProperty, nameof(viewModel.CmdGoToContacs));

            //StackLayout stackLayout = new StackLayout();
            //stackLayout.Children.Add(btnPersonalAccount);
            //stackLayout.Children.Add(btnCounters);
            //stackLayout.Children.Add(btnRates);
            //stackLayout.Children.Add(btnPrivileges);
            //stackLayout.Children.Add(btnStatistics);
            //stackLayout.Children.Add(btnAccount);
            //stackLayout.Children.Add(btnContacts);
            this.Content = collectionView;
            this.Style = stylePage.stlView;
        }

        class TemplateSelector : DataTemplateSelector
        {
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                return new DtCell((mdls.MdlYetCell)item);
            }

            class DtCell : DataTemplate
            {
                public DtCell(mdls.MdlYetCell data)
                    : base(() => CreateView(data)) { }
                static View CreateView(mdls.MdlYetCell data)
                {
                    customCells.CellYet cell = new customCells.CellYet();
                    cell.BindingContext = data;
                    cell.lbl.Text = data.str;
                    cell.cmd_tap = data.cmd_tap;
                    cell.svgCachedImage.Source = data.imageSource;
                    return cell;
                }
            }
        }
    }
}
