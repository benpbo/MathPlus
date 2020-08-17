using System;
using System.Numerics;
using System.Diagnostics;
using MathPlus.LinearAlg.Matrices;

namespace MathPlusTimeTests
{
    class Program
    {
        static void Main()
        {
            int iterations = (int)10E+6;
            Stopwatch sw = new Stopwatch();

            Matrix4x4 m1 = new Matrix4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4x4 m2 = new Matrix4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17);
            double[,] m = new double[,] {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {13,14,15,16 }
            };
            Matrix m3 = new Matrix(m);
            Matrix m4 = new Matrix(m);

            sw.Start();
            MatrixMultiplicationNumerics(iterations, m1, m2);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            sw.Start();
            MatrixMultiplicationMathPlus(iterations, m3, m4);
            sw.Stop();
            ts = sw.Elapsed;

            elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }


        private static void MatrixMultiplicationNumerics(int length, Matrix4x4 m1, Matrix4x4 m2)
        {
            for (int i = 0; i < length; i++)
            {
                m1 *= m2;
            }
        }
        private static void MatrixMultiplicationMathPlus(int length, Matrix m1, Matrix m2)
        {
            for (int i = 0; i < length; i++)
            {
                m1 *= m2;
            }
        }


        private static void MatrixEqualityTest(int iterations)
        {
            Stopwatch sw = new Stopwatch();
            Matrix4x4 m1 = new Matrix4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4x4 m2 = new Matrix4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17);
            sw.Start();
            MatrixEqualityNumerics(iterations, m1, m2);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            double[,] m = new double[,] {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {13,14,15,16 }
            };
            Matrix m3 = new Matrix(m);
            Matrix m4 = new Matrix(m);
            sw.Start();
            MatrixEqualityMathPlus(iterations, m3, m4);
            sw.Stop();
            ts = sw.Elapsed;

            elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        private static void MatrixEqualityMathPlus(int length, Matrix m1, Matrix m2)
        {
            bool b;
            for (int i = 0; i < length; i++)
            {
                 b = m1.Equals(m2);
            }
        }

        private static void MatrixEqualityNumerics(int length, Matrix4x4 m1, Matrix4x4 m2)
        {
            bool b;
            for (int i = 0; i < length; i++)
            {
                b = m1.Equals(m2);
            }
        }

    }
}
