using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using viewModel = Delphin.Pages.ViewModels.News;
using stylePage = Delphin.Staff.Styles.StylePage;
using constText = Delphin.Constants.ConstantText;
using mdls = Delphin.Models;
using customCell = Delphin.Staff.Customs.Cells;

namespace Delphin.Pages.Views.News
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.ViewModels.News.NewsViewModel">
    public class NewsPage : BasePage
    {
        viewModel.NewsViewModel viewModel;
        public NewsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            viewModel = this.BindingContext as viewModel.NewsViewModel;

            double myWidth = prtcGetWidth();
            double myHeight = prtcGetHeight();

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(viewModel.CollectionData));
            collectionView.ItemTemplate = new TemplateSelector(myWidth, myHeight);
            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
            collectionView.EmptyView = constText.PageText.lbl_text_downloading;

            this.Content = collectionView;
            this.Style = stylePage.stlView;
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
                if (item is mdls.MdlNewsTitle mdlNewsTitle)
                {
                    return new DtNewsTitle(width, height, mdlNewsTitle);
                }
                else if (item is mdls.MdlNewsHeader mdlNewsBody)
                {
                    return new DtNewsBody(width, height, mdlNewsBody);
                }
                else
                {
                    throw new NotImplementedException();
                }
                
            }

            class DtNewsTitle : DataTemplate
            {
                public DtNewsTitle(double width, double height, mdls.MdlNewsTitle data)
                    : base(() => CreateView(width, height, data)) { }
                static View CreateView(double width, double height, mdls.MdlNewsTitle data)
                {
                    double my_width = width;
                    double my_height = height;
                    customCell.CellNewsTitle cell = new customCell.CellNewsTitle(my_width, my_height);
                    cell.lbl.Text = data.str;
                    return cell;
                }
            }

            class DtNewsBody : DataTemplate
            {
                public DtNewsBody(double width, double height, mdls.MdlNewsHeader data)
                    : base(() => CreateView(width, height, data)) { }
                static View CreateView(double width, double height, mdls.MdlNewsHeader data)
                {
                    double my_width = width;
                    double my_height = height;
                    customCell.CellNewsBody cell = new customCell.CellNewsBody(my_width, my_height);
                    cell.lblTitle.Text = data.str_title;
                    cell.lblBody.Text = data.str_body;
                    cell.cmd_go_to = data.cmd_go_to;
                    cell.BindingContext = data;
                    return cell;
                }
            }
        }
    }
}
