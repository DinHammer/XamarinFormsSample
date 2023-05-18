using System;
using System.Collections.Generic;
using smpTools = Delphin.Abstraction.Staff.SimpleTools;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TmpText tmpText = new TmpText();
            tmpText.accounts = new List<string> { "300", "400" };
            tmpText.account = new List<int> { 300, 400 };

            //var vJson = smpTools.Instance.JsnGetStringByData(tmpText);

            //string strJson = vJson.Data;
        }
    }

    class TmpText
    {
        public List<string> accounts{get;set;}
        public List<int> account { get; set; }
    }
}
