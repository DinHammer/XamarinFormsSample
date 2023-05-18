using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Delphin.Staff.Customs.Controls
{
    public class MagicTabbedPage : Xamarin.Forms.TabbedPage
    {
        public Action<string> action_tabbed_change;
        
        public MagicTabbedPage()
        {
            
            //this.On<Android>().DisableSwipePaging();
            //this.On<Android>().DisableSmoothScroll();// .DisableSwipePaging();
            this.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //this.On<Android>().SetIsSmoothScrollEnabled(false);            
                        
        }

        
        

        //private void MagicTabbedPage_CurrentPageChanged(object sender, EventArgs e)
        //{
        //    int index = this.Children.IndexOf(this.CurrentPage);
        //    if (index == 1)
        //    {
        //        //this.CurrentPage.Navigation
        //        return;
        //    }
        //    int_last_index = index;

        //    //throw new NotImplementedException();
        //}

        //public static BindableProperty PropertyCommandTabChange = BindableProperty.Create(nameof(CommandTabChange), typeof(ICommand), typeof(MagicTabbedPage), null);

        //public ICommand CommandTabChange
        //{
        //    get
        //    {
        //        return (ICommand)this.GetValue(PropertyCommandTabChange);
        //    }
        //    set
        //    {
        //        this.SetValue(PropertyCommandTabChange, value);
        //    }
        //}

        

    }
}
