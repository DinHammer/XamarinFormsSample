using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
//using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using customControls = Delphin.Staff.Customs.Controls;
using constEnum = Delphin.Constants.ConstantEnum;

[assembly: ExportRenderer(typeof(Delphin.Staff.Customs.Controls.MagicTabbedPage), typeof(Delphin.Droid.Renders.RenderMagicTabbedPage))]
namespace Delphin.Droid.Renders
{
    public class RenderMagicTabbedPage : 
        TabbedPageRenderer
        //BottomNavigationView.IOnNavigationItemSelectedListener
        //BottomNavigationView.IOnNavigationItemReselectedListener
        //TabLayout.IOnTabSelectedListener
    {

        public RenderMagicTabbedPage(Context context) : base(context) { }
        //{
        //    //magicTabbedPage = this.Element as customControls.MagicTabbedPage;
        //}

        
        //bool BottomNavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected(IMenuItem item)
        //{
        //    var magicTabbedPage = this.Element as customControls.MagicTabbedPage;
            
        //    string title = item.ToString();

        //    magicTabbedPage.action_tabbed_change?.Invoke(title);
            
        //    return true;
        //}

        //void BottomNavigationView.IOnNavigationItemReselectedListener.OnNavigationItemReselected(IMenuItem item)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement != null)
        //    { 
        //    }

        //    if (e.OldElement != null)
        //    { 
        //    }
        //}

        //void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
        //{
        //    System.Diagnostics.Debug.WriteLine("TabReselected");
        //}
    }
}