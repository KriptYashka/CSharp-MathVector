using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp_LinearAlgebra;

namespace MathVectorTests
{
    [TestClass]
    public class ClassTestsMathVector
    {
        /* Свойства */

        [TestMethod]
        public void TestDimensions()
        {
            double[] points = new double[]{ 1, 2, 3 };
            MathVector vector = new MathVector(points);
            int expected = 3;
            int actual = vector.Dimensions;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndex()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            double expected = 3;
            double actual = vector[2];
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestLength_1()
        {
            double[] points = new double[] { -10 };
            MathVector vector = new MathVector(points);
            double expected = 10;
            double actual = vector.Length;
            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void TestLength_2()
        {
            double[] points = new double[] { 2, -3, 1, -1, 1 };
            MathVector vector = new MathVector(points);

            double expected = 4;
            double actual = vector.Length;

            Assert.AreEqual(expected, actual, 0.000001);
        }
        /* Операции */

        /* Сумирование */
        [TestMethod]
        public void TestSumNumber()
        {
            double[] points1 = new double[] { 1, 1, 1 };
            double[] points2 = new double[] { 6, 6, 6 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)vector.SumNumber(5);

            Assert.IsTrue(expected == actual);
        }
        [TestMethod]
        public void TestSumOperatorNumber()
        {
            double[] points1 = new double[] { 1, 1, 1 };
            double[] points2 = new double[] { 6, 6, 6 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)(vector + 5);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMinusOperatorNumber()
        {
            double[] points1 = new double[] { 10, 10, 5 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)(vector - 5);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestSumVector()
        {
            double[] points1 = new double[] { 1, 1, 1, 3 };
            double[] points2 = new double[] { 6, 6, 6, -2 };
            double[] pointsExpected = new double[] { 7, 7, 7, 1 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)vector1.Sum(vector2);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestSumOperatorVector()
        {
            double[] points1 = new double[] { 1, 1, 1, 3 };
            double[] points2 = new double[] { 6, 6, 6, -2 };
            double[] pointsExpected = new double[] { 7, 7, 7, 1 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 + vector2);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMinusOperatorVector()
        {
            double[] points1 = new double[] { 1, 1, 1, 3 };
            double[] points2 = new double[] { 6, 6, 6, -2 };
            double[] pointsExpected = new double[] { -5, -5, -5, 5 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 - vector2);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestSumDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            MathVector actual = (MathVector)vector1.Sum(vector2);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestSumOperatorDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            MathVector actual = (MathVector)(vector1 + vector2);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestMinusOperatorDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            MathVector actual = (MathVector)(vector1 - vector2);

            Assert.IsNull(actual);
        }

    }
}
