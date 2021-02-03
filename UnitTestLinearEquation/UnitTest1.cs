using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Task2_cs;
namespace UnitTestLinearEquation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringConstructor()
        {
            string s = "1 2,3 4 6,2 5,28 0 1";
            LinearEquation le = new LinearEquation(s);
            Assert.IsTrue(new double[] { 1, 2.3, 4, 6.2, 5.28, 0, 1 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void StringConstructorIsEmpty()
        {
            string s = "";
            LinearEquation le = new LinearEquation(s);
            Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void StringConstructorWithOneNumber()
        {
            string s = "5";
            LinearEquation le = new LinearEquation(s);
            Assert.IsTrue(new double[] { 5, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void StringConstructorWithWrongInput()
        {
            string s = "5 1,2,3 seven gnsjldfsl 1.9g";
            Assert.Equals(typeof(ArgumentException), new LinearEquation(s));
        }
        [TestMethod]
        public void ListConstructorWithArray()
        {
            double[] array = new double[] { 2, 1, 5.6, 7, 8 };
            LinearEquation le = new LinearEquation(array);
            Assert.IsTrue(array.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void ListConstructorWithList()
        {
            List<double> list = new List<double> { 2, 1, 5.6, 7, 8 };
            LinearEquation le = new LinearEquation(list);
            Assert.IsTrue(list.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void ListConstructorWithEmptyCollection()
        {
            double[] emptyArray = new double[] {};
            LinearEquation le = new LinearEquation(emptyArray);
            Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void ListConstructorWithOneElement()
        {
            double[] array = new double[] { 3 };
            LinearEquation le = new LinearEquation(array);
            Assert.IsTrue(new double[] { 3, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void LinearEquationConstructor()
        {
            double[] arr = new double[4] { 0, -5.6, 4, 7 };
            LinearEquation le1 = new LinearEquation(arr);
            LinearEquation le2 = new LinearEquation(le1);
            Assert.IsTrue(((double[])le1).SequenceEqual((double[])le2));
        }
        [TestMethod]
        public void IntConstructor()
        {
            int n = 3;
            LinearEquation le = new LinearEquation(n);
            Assert.IsTrue(new double[] { 0, 0, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void IntConstructorWithZero()
        {
            int n = 0;
            LinearEquation le = new LinearEquation(n);
            Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void IntConstructorWithOne()
        {
            int n = 1;
            LinearEquation le = new LinearEquation(n);
            Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntConstructorLessThanZero()
        {
            int n = -1;
            Assert.Equals(typeof(ArgumentException), new LinearEquation(n));
        }
    }
}
