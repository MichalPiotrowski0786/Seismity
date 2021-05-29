using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class StringTestsForUI
    {
        static object[] TestCases0 = 
        {
            new object[] {"0","24.05.2021","4","54.29","22.49","15"},
            new object[] {"1","01.01.1980","0.1","0.0","0.0","600"},
            new object[] {"2","31.05.2020","1","60.0","60.0","0"},
            new object[] {"3","01.01.01","0.001","1.0","1.0","0.1"},
            new object[] {"4","05.05.2005","0.05","22.22","22.22","0.0001"}
        };

        static object[] TestCases1 = 
        {
            new object[] {"0","24.05.2021","5","54.29","22.49","15",100f},
            new object[] {"1","01.01.1980","0.1","0.0","0.0","600",24.51f},
            new object[] {"2","31.05.2020","0.05","60.0","60.0","1",0.1f},
            new object[] {"3","01.01.01","0.001","1.0","1.0","0.1",22.22f},
            new object[] {"4","05.05.2005","0","22.22","22.22","5",9415.1515f}
        };

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryName(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.name.ToString() != null && e.name.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryDate(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.time.ToString() != null && e.time.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryMag(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.mag.ToString() != null && e.mag.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryLat(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.lat.ToString() != null && e.lat.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryLon(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.lon.ToString() != null && e.lon.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
        public void TestParsingEarthquakesDataToStringTryDepth(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);

            Assert.That(e.depth.ToString() != null && e.depth.ToString() != "");    
        }

        [Test, TestCaseSource("TestCases0")]
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

        [Test, TestCaseSource("TestCases0")]
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

        [Test, TestCaseSource("TestCases1")]
        public void TestCalculateVec3FromLatLonMethod(
            string n, 
            string t, 
            string m,
            string lon,
            string lat,
            string d,
            float r)
        {
            Earthquake e = new Earthquake(n,t,m,lon,lat,d);
            GameObject testObject = new GameObject();
            testObject.AddComponent<uiController>();

            Vector3 testVector = Vec3FromLatLon(e,r);
            Vector3 testedVector = testObject.GetComponent<uiController>().CalculateVec3FromLatLon(e,r);

            Assert.AreEqual(testVector,testedVector);
        }

        private Vector3 Vec3FromLatLon(Earthquake e, float r)
        {
            var threePosition = Quaternion.AngleAxis((float)e.lon,-Vector3.up) 
                * Quaternion.AngleAxis((float)e.lat, -Vector3.right) 
                * new Vector3(0f, 0f, 1f) * r;

            return threePosition;
        }
    }
}
