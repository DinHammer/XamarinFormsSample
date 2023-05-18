using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using stlPage = Delphin.Staff.Styles.StylePage;
using constTextPage = Delphin.Constants.ConstantText.PageText.Main;

namespace Delphin.Staff.Customs.Cells
{
    public class CellActialNewsTitle : Grid
    {
        public Label lbl;
        public CellActialNewsTitle(double width, double height)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            lbl = new Label();
            lbl.Style = stlPage.Main.stlCellNewsActualTitle;
            this.Children.Add(lbl, 0, 0);
            this.Style = stlPage.stlCellView;
        }
    }
    public class CellActualNews : Grid
    {
        //public Button btnGoTo;
        public Label lblTitle;
        public Label lblBody;
        public CellActualNews(double width, double height)
        {            
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            lblTitle = new Label();
            lblTitle.Style = stlPage.Main.stlCellNewsActualHeader;
            this.Children.Add(lblTitle, 0, 0);

            lblBody = new Label();
            this.Children.Add(lblBody, 1, 0);
            this.Style = stlPage.stlCellView;
        }
    }

    public class CellActualButton : Grid
    {
        public Button btn;
        public CellActualButton(double width, double height)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            btn = new Button();
            btn.Style = stlPage.stlBtnView;

            StackLayout stackLayout = new StackLayout();
            stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackLayout.Children.Add(btn);


            this.Children.Add(stackLayout, 0, 0);
            this.Style = stlPage.stlCellView;
        }
    }
}
