using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using stlPage = Delphin.Staff.Styles.StylePage;
using constTextPage = Delphin.Constants.ConstantText.PageText.Main;

namespace Delphin.Staff.Customs.Cells
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Main.MainPage">
    public class CellPokazaniyaSchetchika : Grid
    {
        Label lblTitle;
        public Label lblData;
        public Label lblValueWaterCold;
        public Label lblValueWaterHot;
        public Label lblValueElectroEnergyT1;
        public Label lblValueElectroEnergyT2;
        public CellPokazaniyaSchetchika(double width, double height)
        {
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            lblTitle = new Label();
            grid.Children.Add(lblTitle, 0, 0);

            lblData = new Label();
            grid.Children.Add(lblData, 0, 1);


            Label lblWaterCold = new Label();
            lblWaterCold.Text = constTextPage.lbl_cell_water_cold;
            grid.Children.Add(lblWaterCold, 0, 2);

            lblValueWaterCold = new Label();
            lblValueWaterCold.Style = stlPage.stlLabelRight;
            grid.Children.Add(lblValueWaterCold, 1, 2);


            Label lblWaterHot = new Label();
            lblWaterHot.Text = constTextPage.lbl_cell_water_hot;
            grid.Children.Add(lblWaterHot, 0, 3);

            lblValueWaterHot = new Label();
            lblValueWaterHot.Style = stlPage.stlLabelRight;
            grid.Children.Add(lblValueWaterHot, 1, 3);


            Label lblElectroEnergyT1 = new Label();
            lblElectroEnergyT1.Text = constTextPage.lbl_cell_electro_t1;
            grid.Children.Add(lblElectroEnergyT1, 0, 4);

            lblValueElectroEnergyT1 = new Label();
            lblValueElectroEnergyT1.Style = stlPage.stlLabelRight;
            grid.Children.Add(lblValueElectroEnergyT1, 1, 4);


            Label lblElectroEnergyT2 = new Label();
            lblElectroEnergyT2.Text = constTextPage.lbl_cell_electro_t2;
            grid.Children.Add(lblElectroEnergyT2, 0, 5);

            lblValueElectroEnergyT2 = new Label();
            lblValueElectroEnergyT2.Style = stlPage.stlLabelRight;
            grid.Children.Add(lblValueElectroEnergyT2, 1, 5);

            Frame frame = new Frame();
            frame.Content = grid;
            frame.Style = stlPage.stlCellFrame;

            this.RowDefinitions.Add(new RowDefinition { Height = height });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

            this.Children.Add(frame);
        }
        
    }
}
