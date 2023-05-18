using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Abstraction.DataObjects
{
    public class ObjPageMain
    {
        public ObjNewsLatestOut news_latest { get; set; }
        public ObjNewsHotOut news_hot { get; set; }
    }

    public class ObjPageNews
    {
        public ObjectNewsData news_data { get; set; }
    }
}
