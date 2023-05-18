using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using mdls = Delphin.Models;
using srvImage = Delphin.Staff.Services.ServiceImage;
using stlPage = Delphin.Staff.Styles.StylePage;
using constText = Delphin.Constants.ConstantText;

namespace Delphin.Staff.Customs.Popup
{
    public class PopupNewsOne : BasePopupPage
    {
        //mdls.MdlNewsHeader mdlNewsHeader { }
        public PopupNewsOne(mdls.MdlNewsHeader data)
        {
            this.BindingContext = new PopupNewsOneVM(data);

            double height = prtcGetHeight();
            double my_height = height / 10;
            #region Toolbar
            Grid toolbar = new Grid();            
            toolbar.BackgroundColor = Color.Blue;
            toolbar.RowDefinitions.Add(new RowDefinition { Height = my_height });
            toolbar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            toolbar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            toolbar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            SvgCachedImage ImageBack = new SvgCachedImage();
            ImageBack.Source = srvImage.Instance.GetToolbarBackArrow();
            //ImageBack.WidthRequest = ImageBack.HeightRequest = my_height / 2;
            ImageBack.VerticalOptions = LayoutOptions.Center;
            
            StackLayout panelToolbarLeft = new StackLayout();
            panelToolbarLeft.BackgroundColor = Color.Red;
            panelToolbarLeft.VerticalOptions = LayoutOptions.FillAndExpand;
            panelToolbarLeft.HorizontalOptions = LayoutOptions.FillAndExpand;
            panelToolbarLeft.Children.Add(ImageBack);            

            toolbar.Children.Add(panelToolbarLeft, 0, 0);

            Label lblTitle = new Label();
            //lblTitle.Style = stlPage.stlLabelCenter;
            lblTitle.HorizontalTextAlignment = TextAlignment.Center;
            lblTitle.VerticalTextAlignment = TextAlignment.Center;
            lblTitle.TextColor = Color.White;
            lblTitle.Text = constText.PageText.News.title_news_one;            

            StackLayout panelToolbarCenter = new StackLayout();
            panelToolbarCenter.VerticalOptions = LayoutOptions.FillAndExpand;
            panelToolbarCenter.HorizontalOptions = LayoutOptions.Center;
            panelToolbarCenter.Children.Add(lblTitle);

            toolbar.Children.Add(panelToolbarCenter, 1, 0);
            #endregion

            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor= Color.FromHex("3F515F");
            stackLayout.Children.Add(toolbar);
            this.Content = stackLayout;
        }
    }

    public class PopupNewsOneVM : BasePopupViewModel
    {
        mdls.MdlNewsHeader data { get; set; }
        public PopupNewsOneVM(mdls.MdlNewsHeader data)
        {
            this.data = data;
        }
    }
}
