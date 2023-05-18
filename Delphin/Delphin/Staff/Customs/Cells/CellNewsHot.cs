using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using stlPage = Delphin.Staff.Styles.StylePage;

namespace Delphin.Staff.Customs.Cells
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Main.MainPage">
    public class CellNewsHot: Grid
    {
        public Label lbl;
        public CellNewsHot(double width, double height)
        {
            lbl = new Label();
            lbl.Style = stlPage.stlLabelCenter;

            this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            this.Children.Add(lbl, 0, 0);
            //this.Style = stlPage.Main.stlCellHotNewsBackgroundColor;
        }
    }
}
