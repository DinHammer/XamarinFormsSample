using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Delphin.NUnit
{
    public class InitTestClient
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData(
                    "TestUsver",
                    "MyNumber",
                    "test123");
                                    
            }
        }
    }
}