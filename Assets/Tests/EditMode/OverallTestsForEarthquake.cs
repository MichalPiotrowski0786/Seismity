using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class OverallTestsForEarthquake
    {
        static object[] TestCases = 
        {
            new object[] {"0","24.05.2021","4","54.29","22.49","15"},
            new object[] {"1","01.01.1980","0.1","0.0","0.0","600"},
            new object[] {"2","31.05.2020","9","60.0","60.0","1"},
            new object[] {"3","01.01.01","1","1.0","1.0","0.1"},
            new object[] {"4","05.05.2005","3","22.22","22.22","5"},
        };

        [Test, TestCaseSource("TestCases")]
        public void TestFixingInputErrorsAtInitTryDepth(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            float testedDepth = e.depth;

            Assert.GreaterOrEqual(testedDepth,10);
        }

        [Test, TestCaseSource("TestCases")]
        public void TestFixingInputErrorsAtInitTryMag(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            float testedMag = e.mag;

            Assert.GreaterOrEqual(testedMag,0.1);
        }

    }
}
