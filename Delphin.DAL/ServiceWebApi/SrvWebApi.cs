using System;
using System.Collections.Generic;
using System.Text;
using constString = Delphin.Abstraction.Constants.ConstantText;

namespace Delphin.DAL.ServiceWebApi
{
    public class SrvWebApi
    {
        public static void Init(string base_uri = constString.WebApi.web_api_url, bool is_mock=false)
        {
            Action.ActionStaff.Init(base_uri);
            //Staff = new Action.ActionStaff(base_uri);

            if (is_mock)
            {
                Users = new Moq.ActionUsers();
                News=new Moq.ActionNews();
                Kv=new Moq.ActionKvartplata();
            }
            else
            {                                
                Users = new Action.ActionUser();
                News = new Action.ActionNews();
                Kv = new Action.ActionKvartplata();
            }
                                    
            Uk = new Action.ActionUpravlyayushchayaKompaniya();
            Ls = new Action.ActionLitsevoySchet();
            Flat = new Action.ActionFlat();

            Test = new Moq.ActionTest();
        }

        //internal static IActionStaff Staff { get; private set; }
        public static IActionAuth Auth { get; private set; }
        public static IActionNews News { get; private set; }
        //public static IActionPageNews PageNews { get; private set; }
        //public static IActionPageOther PageOther { get; private set; }
        public static IActionUsers Users { get; private set; }
        public static IActionUpravlyayushchayaKompaniya Uk { get; private set; }
        public static IActionActionLitsevoySchet Ls { get; private set; }
        public static IActionFlat Flat { get; private set; }

        public static IActionKvartplata Kv { get; private set; }

        public static IActionTest Test { get; private set; }
    }
}
