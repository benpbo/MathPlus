using System;

namespace MathPlus.Complex
{
    public struct Complex : IEquatable<Complex>
    {
        public static readonly Complex i;
        public static readonly Complex One;
        public static readonly Complex Zero;


        public double real { get; set; }
        public double imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public Complex(Complex z) : this(z.real, z.imaginary) { }
        static Complex()
        {
            i = new Complex(0, 1);
            One = new Complex(1, 0);
            Zero = new Complex(0, 0);
        }

        public void Add(double num) => real += num;
        public void Add(Complex z)
        {
            real += z.real;
            imaginary += z.imaginary;
        }
        public void Multiply(double num)
        {
            real *= num;
            imaginary *= num;
        }
        public void Multiply(Complex z)
        {
            real = real * z.real - imaginary * z.imaginary;
            imaginary = real * z.imaginary + z.real * imaginary;
        }

        public static Complex Add(Complex z, double num) => new Complex(z.real + num, z.imaginary);
        public static Complex Add(Complex z1, Complex z2) => new Complex(z1.real + z2.real, z1.imaginary + z2.imaginary);
        public static Complex Multiply(Complex z, double num) => new Complex(z.real * num, z.imaginary * num);
        public static Complex Multiply(Complex z1, Complex z2)
        {
            double real = z1.real * z2.real - z1.imaginary * z2.imaginary;
            double imag = z1.real * z2.imaginary + z2.real * z1.imaginary;
            return new Complex(real, imag);

        }

        public static Complex operator +(Complex z, double num) => Add(z, num);
        public static Complex operator +(Complex z1, Complex z2) => Add(z1, z2);
        public static Complex operator *(Complex z, double num) => Multiply(z, num);
        public static Complex operator *(Complex z1, Complex z2) => Multiply(z1, z2);

        public bool Equals(Complex other) => real == other.real && imaginary == other.imaginary;

        public override string ToString() => $"{real} + i{imaginary}";
    }
}
