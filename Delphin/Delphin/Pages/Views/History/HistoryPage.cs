using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
//using viewModel = Delphin.Pages.ViewModels.History.HistoryViewModel;
using viewModel = Delphin.Pages.ViewModels.History;
using constTextPage = Delphin.Constants.ConstantText.PageText;
using stylePage = Delphin.Staff.Styles.StylePage;

namespace Delphin.Pages.Views.History
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.ViewModels.History.HistoryViewModel">
    public class HistoryPage: BasePage
    {
        viewModel.HistoryViewModel viewModel;
        public HistoryPage()
        {

            

            viewModel = this.BindingContext as viewModel.HistoryViewModel;
            Label lblAllOperation = new Label();
            lblAllOperation.Text = constTextPage.History.btn_title_all_operation;
            lblAllOperation.Style = stylePage.History.stlToolbarLabel;

            Label lblNachislenia = new Label();
            lblNachislenia.Text = constTextPage.History.btn_title_nachislenia;
            lblNachislenia.Style = stylePage.History.stlToolbarLabel;

            Label lblOplati = new Label();
            lblOplati.Text = constTextPage.History.btn_title_oplati;
            lblOplati.Style = stylePage.History.stlToolbarLabel;

            Grid gridTitle = new Grid();
            gridTitle.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridTitle.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridTitle.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridTitle.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gridTitle.Children.Add(lblAllOperation, 0, 0);
            gridTitle.Children.Add(lblNachislenia, 1, 0);
            gridTitle.Children.Add(lblOplati, 2, 0);

            NavigationPage.SetTitleView(this, gridTitle);
            NavigationPage.SetHasBackButton(this, false);
            //this.SetBinding(NavigationPage.BarBackgroundColorProperty, nameof(viewModel.color_toolbar));
            //var nav_page = this as NavigationPage;
            //nav_page.BarBackgroundColor = Color.Black;

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(viewModel.PageDataCollection));
            //collectionView.ItemTemplate = new TemplateSelector(myWidth, myHeight);
            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
            collectionView.EmptyView = constTextPage.lbl_text_downloading;

            this.Content = collectionView;
            this.Style = stylePage.stlView;
        }
    }
}
