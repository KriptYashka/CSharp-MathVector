using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp_LinearAlgebra;
using System;

namespace MathVectorTests
{
    [TestClass]
    public class ClassTestsMathVector
    {
        /* �������� */
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
        public void TestIndexGet()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            double expected = 3;
            double actual = vector[2];
            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void TestIndexSet()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            vector[0] = 10;
            double expected = 10;
            double actual = vector[0];
            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void TestIndexGetOutMore()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                double actual = vector[10];
            });
        }
        [TestMethod]
        public void TestIndexGetOutLess()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                double actual = vector[-1];
            });
        }
        [TestMethod]
        public void TestIndexSetOutMore()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                vector[10] = 2;
            });
        }
        [TestMethod]
        public void TestIndexSetOutLess()
        {
            double[] points = new double[] { 1, 2, 3 };
            MathVector vector = new MathVector(points);
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                vector[-1] = 2;
            });
        }

        [TestMethod]
        public void TestLengthWithoutPoints()
        {
            double[] points = new double[] { };
            MathVector vector = new MathVector(points);
            double expected = 0;
            double actual = vector.Length;
            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void TestLength()
        {
            double[] points = new double[] { 2, -3, 1, -1, 1 };
            MathVector vector = new MathVector(points);

            double expected = 4;
            double actual = vector.Length;

            Assert.AreEqual(expected, actual, 0.000001);
        }
        /* �������� */

        /* ����������� */
        [TestMethod]
        public void TestSumNumber()
        {
            double[] points1 = new double[] { 1, 1, 1 };
            double[] points2 = new double[] { 6, 6, 6 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)vector.SumNumber(5);

            AssertEqualVectors(expected, actual);
        }
        [TestMethod]
        public void TestSumOperatorNumber()
        {
            double[] points1 = new double[] { 1, 1, 1 };
            double[] points2 = new double[] { 6, 6, 6 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)(vector + 5);

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestMinusOperatorNumber()
        {
            double[] points1 = new double[] { 10, 10, 5 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector = new MathVector(points1);

            MathVector expected = new MathVector(points2);
            MathVector actual = (MathVector)(vector - 5);

            AssertEqualVectors(expected, actual);
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

            AssertEqualVectors(expected, actual);
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

            AssertEqualVectors(expected, actual);
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

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestSumDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            
            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)vector1.Sum(vector2);
            });
        }

        [TestMethod]
        public void TestSumOperatorDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            
            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)(vector1 + vector2);
            });
        }

        [TestMethod]
        public void TestMinusOperatorDiffrentDimensions()
        {
            double[] points1 = new double[] { 10, 10, 5, 1 };
            double[] points2 = new double[] { 5, 5, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            
            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)(vector1 - vector2);
            });
        }

        /* ��������� */

        [TestMethod]
        public void TestMultiplyNumber()
        {
            double[] points1 = new double[] { 1, -1, 0, 9.5 };
            double[] pointsExpected = new double[] {2, -2, 0, 19 };
            MathVector vector1 = new MathVector(points1);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1.MultiplyNumber(2));

            AssertEqualVectors(expected, actual);
        }
        [TestMethod]
        public void TestMultiplyVector()
        {
            double[] points1 = new double[] { -0.5, 2, 19 };
            double[] points2 = new double[] { 0.5, 6, 0 };
            double[] pointsExpected = new double[] { -0.25, 12, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1.Multiply(vector2));

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestMultiplyOperationNumber()
        {
            double[] points1 = new double[] { -0.5, 2, 19, 0 };
            double[] pointsExpected = new double[] { -1, 4, 38, 0 };
            MathVector vector1 = new MathVector(points1);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 * 2);

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestMultiplyOperationVector()
        {
            double[] points1 = new double[] { -0.5, 2, 19 };
            double[] points2 = new double[] { 0.5, 6, 0 };
            double[] pointsExpected = new double[] { -0.25, 12, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 * vector2);

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestScalarMultiplyVector()
        {
            double[] points1 = new double[] { -0.5, 2, 19 };
            double[] points2 = new double[] { 2, 2, 0 };
            double expected = 3;
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            double actual = vector1.ScalarMultiply(vector2);

            Assert.AreEqual(expected, actual, 0.00001);
        }
        [TestMethod]
        public void TestScalarMultiplyOperationVector()
        {
            double[] points1 = new double[] { -0.5, 2, 19 };
            double[] points2 = new double[] { 2, 2, 0 };
            double expected = 3;
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            double actual = vector1 % vector2;

            Assert.AreEqual(expected, actual, 0.00001);
        }


        [TestMethod]
        public void TestMultiplyDiffrentDimensions()
        {
            double[] points1 = new double[] { -0.5, 2, 19, 0 };
            double[] points2 = new double[] { 0.5, 6, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)(vector1 * vector2);
            });
        }

        /* ������� */

        [TestMethod]
        public void TestDivNumber()
        {
            double[] points1 = new double[] { 30, 20, -10 };
            double[] pointsExpected = new double[] { 3, 2, -1 };
            MathVector vector1 = new MathVector(points1);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1.Divide(10));

            AssertEqualVectors(expected, actual);
        }
        [TestMethod]
        public void TestDivVector()
        {
            double[] points1 = new double[] { 30, 20, -10 };
            double[] points2 = new double[] { 3, 2, 1 };
            double[] pointsExpected = new double[] { 10, 10, -10 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1.Divide(vector2));

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestDivOperationNumber()
        {
            double[] points1 = new double[] { 30, 20, -10 };
            double[] pointsExpected = new double[] { 3, 2, -1 };
            MathVector vector1 = new MathVector(points1);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 / 10);

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestDivOperationVector()
        {
            double[] points1 = new double[] { 30, 20, -10 };
            double[] points2 = new double[] { 3, 2, 1 };
            double[] pointsExpected = new double[] { 10, 10, -10 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            MathVector expected = new MathVector(pointsExpected);
            MathVector actual = (MathVector)(vector1 / vector2);

            AssertEqualVectors(expected, actual);
        }

        [TestMethod]
        public void TestDivOperationDiffrentDimensions()
        {
            double[] points1 = new double[] { -0.5, 2, 19, 0 };
            double[] points2 = new double[] { 0.5, 6, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)(vector1 / vector2);
            });
        }

        [TestMethod]
        public void TestDivDiffrentDimensions()
        {
            double[] points1 = new double[] { -0.5, 2, 19, 0 };
            double[] points2 = new double[] { 0.5, 6, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            Assert.ThrowsException<Exception>(delegate {
                MathVector actual = (MathVector)(vector1.Divide(vector2));
            });
        }

        [TestMethod]
        public void TestDivZeroVector()
        {
            double[] points1 = new double[] { 0, 0, 1 };
            double[] points2 = new double[] { 0, 1, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);
            Assert.ThrowsException<DivideByZeroException>(delegate {
                MathVector actual = (MathVector)(vector1.Divide(vector2));
            });
        }
        [TestMethod]
        public void TestDivZeroNumber()
        {
            double[] points1 = new double[] { 0, 0, 1 };
            MathVector vector1 = new MathVector(points1);

            Assert.ThrowsException<DivideByZeroException>(delegate {
                MathVector actual = (MathVector)(vector1.Divide(0));
            });

        }
        [TestMethod]
        public void TestDivOperationZeroVector()
        {
            double[] points1 = new double[] { 0, 0, 1 };
            double[] points2 = new double[] { 0, 1, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            Assert.ThrowsException<DivideByZeroException>(delegate {
                MathVector actual = (MathVector)(vector1 / vector2);
            });
        }
        [TestMethod]
        public void TestDivOperationZeroNumber()
        {
            double[] points1 = new double[] { 0, 0, 1 };
            MathVector vector1 = new MathVector(points1);

            Assert.ThrowsException<DivideByZeroException>(delegate {
                MathVector actual = (MathVector)(vector1 / 0);
            });
        }

        [TestMethod]
        public void TestCalcDistTouched()
        {
            double[] points1 = new double[] { 0, 1, 1 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(vector1);

            double expected = 0;
            double actual = vector1.CalcDistance(vector2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcDist()
        {
            double[] points1 = new double[] { 0, 0, 10 };
            double[] points2 = new double[] { 0, 0, 0 };
            MathVector vector1 = new MathVector(points1);
            MathVector vector2 = new MathVector(points2);

            double expected = 10;
            double actual = vector1.CalcDistance(vector2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEnum()
        {
            double[] points1 = new double[] { 0, 0, 10 };
            double[] expected = new double[] { 0, 0, 10 };
            MathVector vector1 = new MathVector(points1);
            double[] actual = new double[3];
            int i = 0;
            foreach (double point in vector1)
            {
                actual[i++] = point;
            }

            bool flag = true;
            for (i = 0; i < 3; ++i)
            {
                if (actual[i] != expected[i])
                {
                    flag = false;
                }
            }

            Assert.IsTrue(flag);
        }
        static private void AssertEqualVectors(MathVector vector1, MathVector vector2)
        {
            Assert.AreEqual(vector1.Dimensions, vector2.Dimensions);
            for (int i = 0; i < vector1.Dimensions; ++i)
            {
                Assert.AreEqual(vector1[i], vector2[i]);
            }
        }
    }
}
