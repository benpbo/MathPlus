using System.Linq;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MathPlus.LinearAlg.Matrices
{
    using Vectors;

    public class Matrix : IEquatable<Matrix>
    {
        protected double[,] values;
        public bool IsSquare { get => values.GetLength(0) == values.GetLength(1); }
        public Matrix(double[,] values)
        {
            this.values = new double[values.GetLength(0), values.GetLength(1)];
            for (int i = 0; i < this.values.GetLength(0); i++)
            {
                for (int j = 0; j < this.values.GetLength(1); j++)
                {
                    this.values[i, j] = values[i, j];
                }
            }
        }

        public static Matrix GetZeroMatrix(int rows, int columns)
        {
            double[,] values = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    values[i, j] = 0;
                }
            }

            return new Matrix(values);
        }

        public Matrix(Matrix other) : this(other.values) { }

        public static Vector LinearTransformation(Matrix m, Vector u)
        {
            Vector[] vectors = new Vector[m.values.GetLength(0)];
            for (int i = 0; i < m.values.GetLength(0); i++)
            {
                vectors[i] = new Vector(m.GetRow(i));
            }

            Vector final = Vector.GetZeroVector(m.values.GetLength(1));
            for (int i = 0; i < vectors.Length; i++)
            {
                final += u[i] * vectors[i];
            }

            return final;
        }

        public Vector LinearTransformation(Vector u) => LinearTransformation(this, u);

        public static Matrix MatrixMultiplication(Matrix a, Matrix b)
        {
            if (a.values.GetLength(0) != b.values.GetLength(1)) return null;

            int n = a.values.GetLength(1);
            int m = a.values.GetLength(0); // = b.values.GetLength(1)
            int p = b.values.GetLength(0);

            double[,] c = new double[p, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m; k++)
                    {
                        sum += a.values[i, k] * b.values[k, j];
                    }
                    c[i, j] = sum;
                }
            }
            return new Matrix(c);
        }

        public static Matrix operator *(Matrix m1, Matrix m2) => MatrixMultiplication(m1, m2);

        public static Vector operator *(Matrix m, Vector u) => LinearTransformation(m, u);

        public double this[int i, int j]
        {
            get => this.values[i, j];
            set => this.values[i, j] = value;
        }

        public double[] GetColumn(int columnNumber)
        {
            return Enumerable.Range(0, values.GetLength(0))
                    .Select(x => values[x, columnNumber])
                    .ToArray();
        }

        public double[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, values.GetLength(1))
                    .Select(x => values[rowNumber, x])
                    .ToArray();
        }

        public bool Equals([AllowNull] Matrix other)
        {
            if (this.values.GetLength(0) != other.values.GetLength(0) || this.values.GetLength(1) != other.values.GetLength(1)) return false;
            
            for (int i = 0; i < this.values.GetLength(0); i++)
            {
                for (int j = 0; j < this.values.GetLength(1); j++)
                {
                    if (this[i, j] != other[i, j]) return false;
                }
            }

            return true;
        }
    }
}
