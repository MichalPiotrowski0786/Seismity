using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {

        [UnityTest]
        public IEnumerator GetEarthGameObjectTest()
        {
            // var dataGameObject = MonoBehaviour.Instantiate(GameObject.FindGameObjectWithTag("EarthTag").);
            // EarthquakesController output = dataGameObject.GetComponent<EarthquakesController>();
            // yield return new WaitForSeconds(.1f);
            // Assert.That(output,Is.Not.Null);
            yield return null;
        }

    }
}
