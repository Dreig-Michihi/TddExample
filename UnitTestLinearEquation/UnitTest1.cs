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
        [ExpectedException(typeof(ArgumentException))]
        public void StringConstructorWithWrongInput()
        {
            string s = "5 1,2,3 seven gnsjldfsl 1.9g";
            Assert.Equals(typeof(ArgumentException), new LinearEquation(s));
        }
        [TestMethod]
        public void ListConstructorWithArray()
        {
            double[] array = new double[] { 2, -5.6, 7.2, -8 };
            LinearEquation le = new LinearEquation(array);
            Assert.IsTrue(array.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void ListConstructorWithList()
        {
            List<double> list = new List<double> { 2, -5.6, 7.2, -8 };
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
        [TestMethod]
        public void FillByDuplicates()
        {
            LinearEquation le = new LinearEquation(5);
            le.FillByDuplicates(4);
            Assert.IsTrue(new double[] { 4, 4, 4, 4, 4 }.SequenceEqual((double[])le));
        }
        [TestMethod]
        public void FillByRandomValues()
        {
            LinearEquation le1 = new LinearEquation(5);
            LinearEquation le2 = new LinearEquation(5);
            le1.FillByRandomValues(-10.5, 10.5, 123);
            le2.FillByRandomValues(-10.5, 10.5, 123);
            Assert.IsTrue(((double[])le1).SequenceEqual((double[])le2));
        }
        [TestMethod]
        public void FillByRandomValuesMinBiggerThanMax()
        {
            LinearEquation le = new LinearEquation(5);
            Assert.ThrowsException<ArgumentException>(() => le.FillByRandomValues(10.5, -10.5));
        }
        [TestMethod]
        public void SumWithSameCountOfCoefficientsInBothEquations()
        {
            LinearEquation l1 = new LinearEquation(new double[] { -1, 0, 1, 2 });
            LinearEquation l2 = new LinearEquation(new double[] { 3, 4, 5, -2 });
            Assert.IsTrue(new double[] { 2, 4, 6, 0 }.SequenceEqual((double[])(l1 + l2)));
        }
        [TestMethod]
        public void SumWithCountOfCoefficientsIsGreaterInFirstEquation()
        {
            LinearEquation l1 = new LinearEquation(new double[] { 1, -2, 3, 4 });
            LinearEquation l2 = new LinearEquation(new double[] { 3, 4 });
            Assert.IsTrue(new double[] { 4, 2, 3, 4 }.SequenceEqual((double[])(l1 + l2)));
        }
        [TestMethod]
        public void SumWithCountOfCoefficientsIsGreaterInSecondEcuation()
        {
            LinearEquation l1 = new LinearEquation(new double[] { 3, 4 });
            LinearEquation l2 = new LinearEquation(new double[] { 1, -2, 3, 4 });
            Assert.IsTrue(new double[] { 4, 2, 3, 4 }.SequenceEqual((double[])(l1 + l2)));
        }
        [TestMethod]
        public void SubstructionWithSameCountOfCoefficients()
        {
            LinearEquation l1 = new LinearEquation(new double[] { -1, 0, 1, 2 });
            LinearEquation l2 = new LinearEquation(new double[] { 3, 4, 5, -2 });
            Assert.IsTrue(new double[] { -4, -4, -4, 4 }.SequenceEqual((double[])(l1 - l2)));
        }
        [TestMethod]
        public void SubstructionWithCountOfCoefficientsIsGreaterInFirstEquation()
        {
            LinearEquation l1 = new LinearEquation(new double[] { 1, -2, 3, 4 });
            LinearEquation l2 = new LinearEquation(new double[] { 3, 4 });
            Assert.IsTrue(new double[] { -2, -6, 3, 4 }.SequenceEqual((double[])(l1 - l2)));
        }
        [TestMethod]
        public void SubstructionWithCountOfCoefficientsIsGreaterInSecondEcuation()
        {
            LinearEquation l1 = new LinearEquation(new double[] { 3, 4 });
            LinearEquation l2 = new LinearEquation(new double[] { 1, -2, 3, 4 });
            Assert.IsTrue(new double[] { 2, 6, -3, -4 }.SequenceEqual((double[])(l1 - l2)));
        }
        [TestMethod]
        public void MultiplicationLeft()
        {
            double r = 3;
            LinearEquation le = new LinearEquation(new double[] { 1, -2, 3, 4 });
            Assert.IsTrue(new double[] { 3, -6, 9, 12 }.SequenceEqual((double[])(r * le)));
        }
        [TestMethod]
        public void MultiplicationRight()
        {
            double r = -3;
            LinearEquation le = new LinearEquation(new double[] { 1, -2, 3, 4 });
            Assert.IsTrue(new double[] { -3, 6, -9, -12 }.SequenceEqual((double[])(le * r)));
        }
        [TestMethod]
        public void InverseLinearEquation()
        {
            LinearEquation le = new LinearEquation(new double[] { 1, -2, 3, -4, -5, 6, -7, 0, 1 });
            Assert.IsTrue(new double[] { -1, 2, -3, 4, 5, -6, 7, 0, -1 }.SequenceEqual((double[])(-le)));
        }
        [TestMethod]
        public void EqualityWithSameCountOfCoefficients1()
        {
            LinearEquation le1 = new LinearEquation(new double[] { 1, -2, 3, -4, -5, 6, -7, 0, 1 });
            LinearEquation le2 = new LinearEquation(new double[] { 1, -2, 3, -4, -5, 6, -7, 0, 1 });
            Assert.IsTrue(le1==le2);
        }
        [TestMethod]
        public void EqualityWithDifferentCountOfCoefficients()
        {
            LinearEquation le1 = new LinearEquation(new double[] { 1, -2, 3, -4, -5, 0, 0, 0, 0 });
            LinearEquation le2 = new LinearEquation(new double[] { 1, -2, 3, -4, -5 });
            Assert.IsTrue(le1 == le2);
        }
        [TestMethod]
        public void InequalityWithSameCountOfCoefficients()
        {
            LinearEquation le1 = new LinearEquation(new double[] { 1, -2, 6, -4, -5 });
            LinearEquation le2 = new LinearEquation(new double[] { 1, 2, 3, -4, -5 });
            Assert.IsTrue(le1 != le2);
        }
        [TestMethod]
        public void InequalityWithDifferentCountOfCoefficients()
        {
            LinearEquation le1 = new LinearEquation(new double[] { 1, -2, 6, -4, -5, 0, 0, 0, 0 });
            LinearEquation le2 = new LinearEquation(new double[] { 1, 2, 3, -4, -5 });
            Assert.IsTrue(le1 != le2);
        }
        [TestMethod]
        public void TrueEquation()
        {
            LinearEquation le = new LinearEquation(new double[3] { 2, 3, 1 });
            Assert.IsTrue(le ? true : false);
        }
        [TestMethod]
        public void FalseEquation()
        {
            LinearEquation le = new LinearEquation(new double[3] { 2, 0, 0 });
            Assert.IsFalse(le ? true : false);
        }
        [TestMethod]
        public void ToStringConversion()
        {
            LinearEquation le = new LinearEquation(new double[3] { 2, -1, 4 });
            Assert.AreEqual("4x2-1x1+2=0", le.ToString());
        }
        [TestMethod]
        public void ToStringWithMinus()
        {
            LinearEquation le = new LinearEquation(new double[3] { -5, 2, -4 });
            Assert.AreEqual("-4x2+2x1-5=0", le.ToString());
        }
        [TestMethod]
        public void ToStringWithZeroArgument()
        {
            LinearEquation le = new LinearEquation(new double[4] { 0, 2, 0, 4 });
            Assert.AreEqual("4x3+2x1=0", le.ToString());
        }
        [TestMethod]
        public void Coefficient()
        {
            LinearEquation le = new LinearEquation(new double[3] { 3, 2, 4 });
            Assert.AreEqual(2, le[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoefficientOutOfRange()
        {
            LinearEquation le = new LinearEquation(new double[6] { 2, 3, 1, 0, 0, 0 });
            Assert.Equals(typeof(ArgumentOutOfRangeException), le[4]);
        }
        [TestMethod]
        public void Degree()
        {
            LinearEquation le = new LinearEquation(new double[4] { 1, 2, 0, 4 });
            Assert.AreEqual(3, le.Degree);
        }
        [TestMethod]
        public void DegreeWithLeftZeros()
        {
            LinearEquation le = new LinearEquation(new double[4] { 0, 0, 1, 4 });
            Assert.AreEqual(3, le.Degree);
        }
        [TestMethod]
        public void DegreeWithRightZeros()
        {
            LinearEquation le = new LinearEquation(new double[4] { 1, 2, 0, 0 });
            Assert.AreEqual(1, le.Degree);
        }
    }
}
