using System;
using System.Collections.Generic;
using System.Text;
using smpTools = Delphin.Staff.SimpleTools;
using constEnum = Delphin.Constants.ConstantEnum;
using DevDH.Magic.Abstractions;
using Xamarin.Forms;

namespace Delphin.Staff.Services
{
    public class ServiceImage
    {
        static readonly Lazy<ServiceImage> LazyInstance = new Lazy<ServiceImage>(() => new ServiceImage(), true);
        public static ServiceImage Instance => LazyInstance.Value;
        System.Reflection.Assembly assembly;

        public static void Init()
        {
            Instance.Initialize();
        }
        void Initialize()
        {
            this.assembly = System.Reflection.Assembly.GetExecutingAssembly();
        }

        public FFImageLoading.Svg.Forms.SvgImageSource GetToolbarBackArrow()
        {
            string key = "toolbar_back_arrow.svg";
            var requestResult = smpTools.Instance.RsrGetFullName(assembly, key);
            FFImageLoading.Svg.Forms.SvgImageSource imageSource = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(requestResult.Data);
            return imageSource;
        }

        public FFImageLoading.Svg.Forms.SvgImageSource GetNewsArrowIcon(SwipeDirection swipeDirection)
        {
            RequestResult<string> requestResult = default;
            string key = string.Empty;

            switch (swipeDirection)
            {
                case SwipeDirection.Left:
                    key = "news_arrow_left.svg";
                    break;
                case SwipeDirection.Right:
                    key = "news_arrow_right.svg";
                    break;
                default:
                    throw new ArgumentNullException($"No arrow for direction: {swipeDirection}");
            }

            requestResult = smpTools.Instance.RsrGetFullName(assembly, key);
            FFImageLoading.Svg.Forms.SvgImageSource imageSource = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(requestResult.Data);
            return imageSource;
        }
        //SvgImageSource.FromResource
        public FFImageLoading.Svg.Forms.SvgImageSource GetYetIcon(constEnum.EnumClientMobile.Pages pages)
        {
            RequestResult<string> requestResult = default;
            string key = string.Empty;
            switch (pages)
            {
                case constEnum.EnumClientMobile.Pages.PersonalAccount:
                    key = "licevoi_schet.svg";                                    
                    break;
                case constEnum.EnumClientMobile.Pages.Counters:
                    key = "schetchiki.svg";
                    break;
                case constEnum.EnumClientMobile.Pages.Rates:
                    key= "tarifi.svg";
                    break;
                case constEnum.EnumClientMobile.Pages.Privileges:
                    key = "lgoti.svg";
                    break;
                case constEnum.EnumClientMobile.Pages.Statistics:
                    key = "statistika.svg";
                    break;
                case constEnum.EnumClientMobile.Pages.Account:
                    key = "akkount.svg";
                    break;
                case constEnum.EnumClientMobile.Pages.Contacts:
                    key = "kontakti.svg";
                    break;
                default:
                    throw new ArgumentNullException($"No Eshe image for page: {pages}");
            }
            //key = $"{key}.svg";
            requestResult = smpTools.Instance.RsrGetFullName(assembly, key);
            FFImageLoading.Svg.Forms.SvgImageSource imageSource = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(requestResult.Data);
            return imageSource;
        }

        #region GetTabbedPageImage
        public Xamarin.Forms.ImageSource GetTabbedPageImage(string tabbed_name)
        {
            RequestResult<string> requestResult = default;
            if (tabbed_name == constEnum.EnumClientMobile.Pages.Main.ToString())
            {
                requestResult = smpTools.Instance.RsrGetFullName(assembly, "main_select_yes.png");
            }
            else if (tabbed_name == constEnum.EnumClientMobile.Pages.History.ToString())
            {
                requestResult = smpTools.Instance.RsrGetFullName(assembly, "operation_select_no.png");
            }
            else if (tabbed_name == constEnum.EnumClientMobile.Pages.News.ToString())
            {
                requestResult = smpTools.Instance.RsrGetFullName(assembly, "news_select_no.png");
            }
            else if (tabbed_name == constEnum.EnumClientMobile.Pages.Yet.ToString())
            {
                requestResult = smpTools.Instance.RsrGetFullName(assembly, "eshe_select_no.png");
            }
            else
            {
                throw new ArgumentNullException($"No tabbed image for: {tabbed_name}");
            }

            Xamarin.Forms.ImageSource imageSource = Xamarin.Forms.ImageSource.FromResource(requestResult.Data);
            return imageSource;
        }
        #endregion
    }
}
