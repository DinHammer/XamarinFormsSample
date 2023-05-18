using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using constEnums = Dlphn.Constants.ConstEnums;
using Xamarin.Forms;

namespace Dlphn.Staff.Services
{
    public class SrvNavigation
    {
        static readonly Lazy<SrvNavigation> LazyInstance = new Lazy<SrvNavigation>(() => new SrvNavigation(), true);
        public static SrvNavigation Instance => LazyInstance.Value;

        public async Task NavigateTwo(
            constEnums.Pages page, 
            bool isNewNavigationStack = false,
            string strNavigationParams="")
        {
            string strPage = page.ToString();

            if (isNewNavigationStack)
            {
                strPage = $"//{strPage}";
            }

            if (strNavigationParams != "")
            {
                strPage = $"{strPage}?{strNavigationParams}";
            }

            await Shell.Current.GoToAsync(strPage);
        }
    }
}
