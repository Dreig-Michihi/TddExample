using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2_cs;

namespace UnitTestSystemOfLinearEquation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IntConstructor()
        {
            int m = 3;
            SystemOfLinearEquation sle = new SystemOfLinearEquation(2);
            Assert.AreEqual("0=0\n0=0\n", sle.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntConstructorWithNegativeArgumet()
        {
            int m = -2;
            Assert.Equals(typeof(ArgumentException), new SystemOfLinearEquation(m));
        }
        [TestMethod]
        public void Getter()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(1);
            Assert.AreEqual("0=0", sle[0].ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetterWithWrongArgument()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(1);
            Assert.Equals(typeof(ArgumentException), sle[-4].ToString());//может тут бы подошел и OutOfRangeException?
        }
        [TestMethod]
        public void SetterAndGetter()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(2);
            sle[1] = new LinearEquation(new double[] { 4, 5, 2 });
            Assert.AreEqual("2x2+5x1+4=0", sle[1].ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetterWithWrongArgument()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(2);
            Assert.Equals(typeof(ArgumentException), sle[3] = new LinearEquation(new double[4] { 1, 2, 3, 4 }));//может тут бы подошел и OutOfRangeException?
        }
    }
}
