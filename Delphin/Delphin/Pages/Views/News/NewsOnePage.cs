using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using srvImage = Delphin.Staff.Services.ServiceImage;
using constText = Delphin.Constants.ConstantText;
using customCell = Delphin.Staff.Customs.Cells;
using customView = Delphin.Staff.Customs.Controls;
using stlPage = Delphin.Staff.Styles.StylePage;
using System.Xml.Linq;
using mdls = Delphin.Models;
using viewModel = Delphin.Pages.ViewModels.News;

namespace Delphin.Pages.Views.News
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.ViewModels.News.NewsOneViewModel">
    public class NewsOnePage: BasePage
    {
        viewModel.NewsOneViewModel viewModel;
        public NewsOnePage()
        {            
            viewModel = this.BindingContext as viewModel.NewsOneViewModel;

            double width = prtcGetWidth();
            double height = prtcGetHeight();
            double my_height = height / 10;

            #region Toolbar

            customView.MagicModalToolbar toolbar = new customView.MagicModalToolbar(constText.PageText.News.title_news_one, height);
            toolbar.SetBinding(customView.MagicModalToolbar.PropertyCommandBack, nameof(viewModel.cmd_go_back));
            
            #endregion

            #region Header
            SvgCachedImage ImageLeft = new SvgCachedImage();
            ImageLeft.Source = srvImage.Instance.GetNewsArrowIcon(SwipeDirection.Left);

            SvgCachedImage ImageRight = new SvgCachedImage();
            ImageRight.Source = srvImage.Instance.GetNewsArrowIcon(SwipeDirection.Right);


            Label lblLeft = new Label();
            lblLeft.Text = constText.PageText.News.lbl_left;

            Label lblRight = new Label();
            lblRight.Text = constText.PageText.News.lbl_right;

            StackLayout panelLeft = new StackLayout();
            panelLeft.Orientation = StackOrientation.Horizontal;
            panelLeft.HorizontalOptions = LayoutOptions.Start;
            panelLeft.VerticalOptions = LayoutOptions.Center;
            panelLeft.Children.Add(ImageLeft);
            panelLeft.Children.Add(lblLeft);

            StackLayout panelRight = new StackLayout();
            panelRight.Orientation = StackOrientation.Horizontal;
            panelRight.HorizontalOptions = LayoutOptions.End;
            panelRight.VerticalOptions = LayoutOptions.Center;
            panelRight.Children.Add(lblRight);
            panelRight.Children.Add(ImageRight);

            
            
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = my_height });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(panelLeft, 0, 0);
            grid.Children.Add(panelRight, 1, 0);

            #endregion

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(viewModel.CollectionData));
            collectionView.ItemTemplate = new TemplateSelector(width, height);
            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
            
            StackLayout stackLayoutMain = new StackLayout();
            stackLayoutMain.Children.Add(toolbar);
            stackLayoutMain.Children.Add(grid);
            stackLayoutMain.Children.Add(collectionView);
            
            this.Content = stackLayoutMain;            
        }

        class TemplateSelector : DataTemplateSelector
        {
            double width { get; set; }
            double height { get; set; }
            public TemplateSelector(double width, double height)
            {
                this.width = width;
                this.height = height;
            }
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                if (item is mdls.MdlNewsHeader mdlNewsHeader)
                {
                    return new DtNewsHeader(width, height, mdlNewsHeader);
                }
                else
                {
                    throw new NotImplementedException();
                }
                
            }

            class DtNewsHeader : DataTemplate
            {
                public DtNewsHeader(double width, double height, mdls.MdlNewsHeader data)
                    : base(() => CreateView(width, height, data)) { }
                static View CreateView(double width, double height, mdls.MdlNewsHeader data)
                {
                    customCell.CellNewsHeader cell = new customCell.CellNewsHeader(width,height);

                    cell.lblTitle.Text = data.str_body;
                        cell.lblDate.Text = data.str_title;

                    return cell;
                }
            }

            class DtNewsBody : DataTemplate
            { }
        }
    }
}
