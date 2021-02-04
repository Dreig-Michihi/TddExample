using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
            SystemOfLinearEquation sle = new SystemOfLinearEquation(m);
            Assert.AreEqual("0=0\n0=0\n0=0\n", sle.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntConstructorWithNegativeArgumet()
        {
            int m = -2;
            Assert.Equals(typeof(ArgumentException), new SystemOfLinearEquation(m));
        }
        [TestMethod]
        public void ThisSetterAndGetter()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(2);
            sle[1] = new LinearEquation(new double[] { 4, 5, 2 });
            Assert.AreEqual("2x2+5x1+4=0", sle[1].ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThisSetterWithWrongArgument()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(2);
            Assert.Equals(typeof(IndexOutOfRangeException), sle[3] = new LinearEquation(new double[4] { 1, 2, 3, 4 }));//может тут бы подошел и OutOfRangeException?
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThisGetterWithWrongArgument()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(1);
            Assert.Equals(typeof(IndexOutOfRangeException), sle[-4].ToString());//может тут бы подошел и OutOfRangeException?
        }
        [TestMethod]
        public void Solve()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(3);
            sle[0] = new LinearEquation(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquation(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquation(new double[] { 3, 2, 1, -2 });
            Assert.IsTrue(new double[] { -1, 3, 2 }.SequenceEqual(sle.Solve()));
        }
        [TestMethod]
        public void SolveWithSameEquations()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(4);
            sle[0] = new LinearEquation(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquation(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquation(new double[] { 11, 2, -1, -3 });
            sle[3] = new LinearEquation(new double[] { 3, 2, 1, -2 });
            Assert.IsTrue(new double[] { -1, 3, 2 }.SequenceEqual(sle.Solve()));
        }
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void SolveWithContradictoryEquations()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(4);
            sle[0] = new LinearEquation(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquation(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquation(new double[] { 3, 2, 1, -2 });
            sle[3] = new LinearEquation(new double[] { 4, 2, 2, -2 });
            Assert.Equals(typeof(ArithmeticException), sle.Solve());

        }
    }
}
