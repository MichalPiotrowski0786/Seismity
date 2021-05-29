using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class VariablesTestForCamera
    {
        [Test]
        public void CameraControllerTest_TestTranslateBackVector()
        {
            GameObject testObject = new GameObject();
            testObject.AddComponent<CameraController>();

            Vector3 testVariable = new Vector3(0,0,-10);
            Vector3 testedVariable = testObject.GetComponent<CameraController>().translateBack;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorUp()
        {
            Vector3 testVariable = new Vector3(0,1,0);
            Vector3 testedVariable = Vector3.up;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorDown()
        {
            Vector3 testVariable = new Vector3(0,-1,0);
            Vector3 testedVariable = Vector3.down;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorForward()
        {
            Vector3 testVariable = new Vector3(0,0,1);
            Vector3 testedVariable = Vector3.forward;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorBack()
        {
            Vector3 testVariable = new Vector3(0,0,-1);
            Vector3 testedVariable = Vector3.back;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorLeft()
        {
            Vector3 testVariable = new Vector3(-1,0,0);
            Vector3 testedVariable = Vector3.left;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorRight()
        {
            Vector3 testVariable = new Vector3(1,0,0);
            Vector3 testedVariable = Vector3.right;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorZero()
        {
            Vector3 testVariable = new Vector3(0,0,0);
            Vector3 testedVariable = Vector3.zero;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorOne()
        {
            Vector3 testVariable = new Vector3(1,1,1);
            Vector3 testedVariable = Vector3.one;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorMinusOne()
        {
            Vector3 testVariable = new Vector3(-1,-1,-1);
            Vector3 testedVariable = -Vector3.one;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorPosInfinity()
        {
            float posInf = float.PositiveInfinity;
            Vector3 testVariable = new Vector3(posInf,posInf,posInf);
            Vector3 testedVariable = Vector3.positiveInfinity;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorNegInfinity()
        {
            float negInf = float.NegativeInfinity;
            Vector3 testVariable = new Vector3(negInf,negInf,negInf);
            Vector3 testedVariable = Vector3.negativeInfinity;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [Test]
        public void CameraControllerTest_TestBuiltInVectorNegInfinity2()
        {
            float negInf2 = -float.PositiveInfinity;
            Vector3 testVariable = new Vector3(negInf2,negInf2,negInf2);
            Vector3 testedVariable = -Vector3.positiveInfinity;
            Assert.AreEqual(testVariable,testedVariable);
        }

        [TestCase(1,1,1)]
        [TestCase(0,1,1)]
        [TestCase(1,0,1)]
        [TestCase(1,1,0)]
        [TestCase(51,7,14)]
        [TestCase(-42,-6,14)]
        [TestCase(-5,-2,-6)]
        [TestCase(1.51f,5.31f,9.41f)]
        [TestCase(-5.1f,-6.41f,-5.141f)]
        [TestCase(-54.1f,51.1521f,-0.141f)]
        public void CameraControllerTest_TestTranslationOutput(float x, float y, float z)
        {
            GameObject testObject = new GameObject();
            testObject.AddComponent<CameraController>();
            Vector3 input = new Vector3(x,y,z);

            Quaternion testVariable = Quaternion.Euler(input);
            Quaternion testedVariable = testObject.GetComponent<CameraController>().Vec3ToQuat(input);
            Assert.AreEqual(testVariable,testedVariable);
        }


    }
}
