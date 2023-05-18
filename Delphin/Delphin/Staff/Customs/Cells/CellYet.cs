using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using stylePage = Delphin.Staff.Styles.StylePage;

namespace Delphin.Staff.Customs.Cells
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Yet.YetPage">
    public class CellYet : Frame
    {
        public Label lbl;
        public SvgCachedImage svgCachedImage;
        public ICommand cmd_tap { get; set; }
        TapGestureRecognizer tapGesture;
        public CellYet()
        {
            tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(7, GridUnitType.Star) });

            svgCachedImage = new SvgCachedImage();
            //svgCachedImage.BackgroundColor = Color.Red;
            svgCachedImage.Aspect = Aspect.AspectFit;
            grid.Children.Add(svgCachedImage, 0, 0);

            lbl = new Label();
            lbl.Style = stylePage.Yet.stlCellLabel;
            grid.Children.Add(lbl, 1, 0);

            this.Content = grid;
            this.Style = stylePage.Yet.stlCellFrame;
            this.GestureRecognizers.Add(tapGesture);
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            cmd_tap?.Execute(BindingContext);
        }
    }
}
