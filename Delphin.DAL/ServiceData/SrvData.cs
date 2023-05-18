using System;
using System.Collections.Generic;
using System.Text;
using srvWebApi = Delphin.DAL.ServiceWebApi.SrvWebApi;

namespace Delphin.DAL.ServiceData
{
    public class SrvData
    {
        public static void Init(bool isMoq=false)
        {
            if (isMoq)
            {

            }
            else
            {
                //Users = new srvWebApi.Users();
            }


            PageMain = new Action.ActionPageMain();
            PageNews = new Action.ActionPageNews();
        }

        public static IActionPageMain PageMain { get; private set; }
        public static IActionPageNews PageNews { get; private set; }

        public static IActionUsers Users { get; private set; }
    }
}
