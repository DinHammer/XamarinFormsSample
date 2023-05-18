using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using smpTools = Dlphn.Staff.SimpleTools;
using DevDH.Magic.Abstractions;
using constEnums = Dlphn.Constants.ConstEnums;
using constString = Dlphn.Constants.ConstString;

namespace Dlphn.Staff.Services
{
    public class SrvImage
    {
        static readonly Lazy<SrvImage> LazyInstance = new Lazy<SrvImage>(() => new SrvImage(), true);
        public static SrvImage Instance => LazyInstance.Value;
        System.Reflection.Assembly assembly;
        
        public static void Init()
        {
            Instance.Initialize();
        }

        void Initialize()
        {            
            this.assembly = System.Reflection.Assembly.GetExecutingAssembly();
        }

        public RequestResult<ImageSource> GetImage(string key)
        {            
            key = $"{key}.png";

            var vRsr = smpTools.Instance.mgcRsrGetFullName(assembly, key);
            if (!vRsr.IsValid)
            {
                return new RequestResult<ImageSource>(null, vRsr.Status, $"Нет картинки для {key}, с ошибкой: {vRsr.Message}");
            }

            ImageSource imageSource = ImageSource.FromResource(vRsr.Data);
            return new RequestResult<ImageSource>(imageSource, RequestStatus.Ok);
        }

        public ImageSource GetErrorImage()
        {
            var vOut = GetImage("evrei");
            return vOut.Data;
        }

        public RequestResult<ImageSource> GetYetImage(constEnums.Pages page)
        {
            string key = string.Empty;

            switch (page)
            {
                case constEnums.Pages.AccountPage:
                    key = constString.KeyImage.Accounts;
                    break;
                case constEnums.Pages.ContactsPage:
                    key = constString.KeyImage.Contacts;
                    break;
                case constEnums.Pages.MetersPage:
                    key = constString.KeyImage.Meters;
                    break;
                case constEnums.Pages.PersonalAccountPage:
                    key = constString.KeyImage.PersonalAccount;
                    break;
                case constEnums.Pages.PrivilegesPage:
                    key = constString.KeyImage.Privileges;
                    break;
                case constEnums.Pages.RatesPage:
                    key = constString.KeyImage.Rates;
                    break;
                case constEnums.Pages.StatisticPage:
                    key = constString.KeyImage.Statistic;
                    break;

            }

            var result = GetImage(key);
            return result;
        }
        
    }
}
