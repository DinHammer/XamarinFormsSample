using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using stlPage = Delphin.Staff.Styles.StylePage;

namespace Delphin.Staff.Customs.Cells
{

    public class CellNewsHeader : Grid
    {
        public Label lblTitle;
        public Label lblDate;
        public CellNewsHeader(double width, double height)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            lblTitle = new Label();
            lblTitle.Style = stlPage.stlLabelCenter;
            this.Children.Add(lblTitle, 0, 0);

            lblDate = new Label();
            this.Children.Add(lblDate, 0, 1);
        }
    }

    public class CellNewsTitle: Grid
    {
        public Label lbl;
        public CellNewsTitle(double width, double height)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            lbl = new Label();

            StackLayout panelLine = new StackLayout();
            panelLine.BackgroundColor = Color.Black;
            panelLine.HeightRequest = 2;
            panelLine.HorizontalOptions = LayoutOptions.Fill;            

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(lbl);
            stackLayout.Children.Add(panelLine);
            stackLayout.Margin = new Thickness(5, 10, 5, 10);

            this.Children.Add(stackLayout, 0, 0);
        }
    }

    public class CellNewsBody:Grid
    {
        public Label lblTitle;
        public Label lblBody;
        public ICommand cmd_go_to { get; set; }
        TapGestureRecognizer tapGesture;
        public CellNewsBody(double width, double height)
        {
            tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;

            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            lblTitle = new Label();
            lblTitle.Style = stlPage.News.stlLabelNewsTitle;

            lblBody = new Label();
            lblBody.Style = stlPage.stlLabelCenter;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(lblTitle);
            stackLayout.Children.Add(lblBody);

            this.Children.Add(stackLayout,0,0);
            this.GestureRecognizers.Add(tapGesture);
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            cmd_go_to?.Execute(BindingContext);
        }
    }
}
