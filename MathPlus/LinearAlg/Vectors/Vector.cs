using System;

namespace MathPlus.LinearAlg.Vectors
{
    public class Vector : IEquatable<Vector>
    {
        public int Rank { get => values.Length; }
        public double Magnitude { get => Math.Sqrt(Math.Abs(this * this)); }

        protected double[] values;

        public Vector(params double[] values)
        {
            this.values = new double[values.Length];
            for (int i = 0; i < this.values.Length; i++)
            {
                this.values[i] = values[i];
            }
        }
        public Vector(Vector other) : this(other.values) { }

        public double this[int i] {
            get => values[i];
            set => values[i] = value;
        }
        
        public static Vector GetZeroVector(int Rank)
        {
            double[] arr = new double[Rank];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            return new Vector(arr);
        }

        public void Add(Vector v)
        {
            if (Rank != v.Rank) throw new Exception("Vectors dont match in diamentions");

            for (int i = 0; i < Rank; i++)
            {
                values[i] += v.values[i];
            }
        }

        public void Subtract(Vector v) => Add(-v);

        public void ScalarMultiplication(double scalar) => values = (scalar * this).values;

        public static Vector Add(Vector u, Vector v)
        {
            if (u.Rank != v.Rank) throw new Exception("Vectors dont match in diamentions");

            double[] arr = new double[u.Rank];
            for (int i = 0; i < u.Rank; i++)
            {
                arr[i] = u.values[i] + v.values[i];
            }

            return new Vector(arr);
        }
        public static Vector Subtract(Vector u, Vector v) => Add(u, -v);
        public static Vector ScalarMultiplication(double scalar, Vector u)
        {
            double[] arr = new double[u.Rank];
            for (int i = 0; i < u.Rank; i++)
            {
                arr[i] *= scalar;
            }
            return new Vector(arr);
        }
        public static double DotProduct(Vector u, Vector v)
        {
            if (u.values.Length != v.values.Length) throw new Exception("Vectors dont match in diamentions");

            double product = 0;
            for (int i = 0; i < u.values.Length; i++)
            {
                product += u.values[i] * v.values[i];
            }
            return product;
        }

        public static Vector operator +(Vector u, Vector v) => Add(u, v);
        public static Vector operator -(Vector u, Vector v) => Subtract(u, v);
        public static Vector operator -(Vector u) => ScalarMultiplication(-1, u);
        public static Vector operator *(double scalar, Vector u) => ScalarMultiplication(scalar, u);
        public static double operator *(Vector u, Vector v) => DotProduct(u, v);

        public double GetValueAtIndex(int i) => values[i];

        public override string ToString()
        {
            string s = "";
            foreach (var value in values)
            {
                s += value + " ";
            }
            return s;
        }
        public bool Equals(Vector other)
        {
            if (Rank != other.Rank) return false;

            for (int i = 0; i < Rank; i++)
            {
                if (values[i] != other.values[i]) return false;
            }
            return true;
        }
    }
}
