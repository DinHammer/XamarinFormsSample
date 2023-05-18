using System;
using System.Collections.Generic;
using System.Text;
using stylePage = Delphin.Staff.Styles.StylePage;
using Xamarin.Forms;

namespace Delphin.Staff.Customs.Views
{
    public class MagicLoading : ContentView
    {
        public MagicLoading()
        {
            ActivityIndicator activityIndicator = new ActivityIndicator();
            activityIndicator.Style = stylePage.stlActivityIndicator;

            activityIndicator.VerticalOptions = LayoutOptions.Center;
            activityIndicator.HorizontalOptions = LayoutOptions.Center;

            StackLayout stackLayout = new StackLayout();

            stackLayout.HorizontalOptions = LayoutOptions.Center;
            stackLayout.VerticalOptions = LayoutOptions.Center;

            stackLayout.Children.Add(activityIndicator);
            
            this.Content = activityIndicator;            
        }
    }

    public class MagicError : ContentView
    {
        public MagicError()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackLayout.VerticalOptions = LayoutOptions.FillAndExpand;

            stackLayout.BackgroundColor = Color.Red;

            this.Content = stackLayout;
        }
    }
}
