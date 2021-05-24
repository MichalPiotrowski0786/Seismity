using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [Test]
        public void GetEarthGameObjectTest()
        {
            string earthquakeData = Resources.Load("/data.csv").ToString();
            Assert.IsNotNull(earthquakeData,"working");
        }

    }
}
