using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using stylePage = Delphin.Staff.Styles.StylePage.Main;

namespace Delphin.Pages.Views.Main
{
    public class DefaultPage : ContentPage
    {
        public DefaultPage()
        {
            Label label = new Label();
            label.Text = "Init Девелопинг";
            label.Style = stylePage.stlLabel;
            label.VerticalOptions = LayoutOptions.Center;

            this.Content = label;
        }
    }
}
