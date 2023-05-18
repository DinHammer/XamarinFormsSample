using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using models = Delphin.Models;
using constTextPage = Delphin.Constants.ConstantText.PageText.Main;

namespace Delphin.Staff.Customs.Cells
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="Delphin.Pages.Views.Main.MainPage">
    public class CellPersonalAccount: Grid
    {
        Label lblTitle;
        Label lblName;
        Label lblAddress;
        Label lblPersonalAccount;
        Label lblBalance;
        Label lblPersonalAccountValue;
        Label lblBalanceValue;
        public Button btnTrnasferEvedance;
        Button btnPay;
        public CellPersonalAccount(double width, double height)
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
            lblTitle.Text = constTextPage.lbl_cell_title;
            grid.Children.Add(lblTitle, 0, 0);
            Grid.SetColumnSpan(lblTitle, 2);

            lblName = new Label();
            lblName.SetBinding(Label.TextProperty, nameof(models.MdlPersonalAccount.str_name));
            grid.Children.Add(lblName, 0, 1);
            Grid.SetColumnSpan(lblName, 2);

            lblAddress = new Label();
            lblAddress.SetBinding(Label.TextProperty, nameof(models.MdlPersonalAccount.str_adress));
            grid.Children.Add(lblAddress, 0, 2);
            Grid.SetColumnSpan(lblAddress, 2);

            lblPersonalAccount = new Label();
            lblPersonalAccount.Text = constTextPage.lbl_cell_personal_account;
            grid.Children.Add(lblPersonalAccount, 0, 3);

            lblBalance = new Label();
            lblBalance.Text = constTextPage.lbl_cell_balabct;
            grid.Children.Add(lblBalance, 1, 3);

            lblPersonalAccountValue = new Label();
            lblPersonalAccountValue.SetBinding(Label.TextProperty, nameof(models.MdlPersonalAccount.str_personal_account_value));
            grid.Children.Add(lblPersonalAccountValue, 0, 4);

            lblBalanceValue = new Label();
            lblBalanceValue.SetBinding(Label.TextProperty, nameof(models.MdlPersonalAccount.str_balance_value));
            grid.Children.Add(lblBalanceValue, 1, 4);

            btnTrnasferEvedance = new Button();
            btnTrnasferEvedance.Text = constTextPage.btn_cell_trsnsfer_evidance;
            grid.Children.Add(btnTrnasferEvedance, 0, 5);

            btnPay = new Button();
            btnPay.Text = constTextPage.btn_cell_pay;
            grid.Children.Add(btnPay, 1, 5);

            Frame frame = new Frame();
            frame.Content = grid;
            frame.Padding = new Thickness(0);

            this.RowDefinitions.Add(new RowDefinition { Height = height });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

            this.Children.Add(frame);

        }
    }
}
