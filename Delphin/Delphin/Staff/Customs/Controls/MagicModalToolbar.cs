using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using stlPage = Delphin.Staff.Styles.StylePage;
using srvImage = Delphin.Staff.Services.ServiceImage;
using constText = Delphin.Constants.ConstantText;
using FFImageLoading.Svg.Forms;
using System.Windows.Input;

namespace Delphin.Staff.Customs.Controls
{
    public class MagicModalToolbar : Grid
    {
        public static BindableProperty PropertyCommandBack = BindableProperty.Create(nameof(CommandBack), typeof(ICommand), typeof(MagicModalToolbar), null);

        public ICommand CommandBack
        {
            get
            {
                return (ICommand)this.GetValue(PropertyCommandBack);
            }
            set
            {
                this.SetValue(PropertyCommandBack, value);
            }
        }

        public MagicModalToolbar(string str_title, double height)
        {
            TapGestureRecognizer tapBack = new TapGestureRecognizer();
            tapBack.Tapped += TapBack_Tapped;

            this.BackgroundColor = Color.FromHex("3F515F");
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            double my_height = height / 10;

            SvgCachedImage ImageBack = new SvgCachedImage();
            ImageBack.Source = srvImage.Instance.GetToolbarBackArrow();
            ImageBack.WidthRequest = ImageBack.HeightRequest = my_height / 2;
            ImageBack.HorizontalOptions = LayoutOptions.Start;
            ImageBack.Margin = new Thickness(20, 10, 0, 10);

            StackLayout panelToolbarLeft = new StackLayout();
            panelToolbarLeft.Children.Add(ImageBack);
            panelToolbarLeft.GestureRecognizers.Add(tapBack);

            this.Children.Add(panelToolbarLeft, 0, 0);


            Label lblTitle = new Label();
            lblTitle.HorizontalTextAlignment = TextAlignment.Center;
            lblTitle.VerticalTextAlignment = TextAlignment.Center;            
            lblTitle.TextColor = Color.White;
            lblTitle.Text = str_title;
            lblTitle.Margin = new Thickness(0, 12, 0, 0);

            StackLayout panelToolbarCenter = new StackLayout();
            panelToolbarCenter.VerticalOptions = LayoutOptions.FillAndExpand;
            panelToolbarCenter.HorizontalOptions = LayoutOptions.FillAndExpand;
            panelToolbarCenter.Children.Add(lblTitle);

            this.Children.Add(panelToolbarCenter, 1, 0);
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            CommandBack?.Execute("");
        }
    }
}
