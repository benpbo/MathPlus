namespace MathPlus.Calculus
{
    class GeneralFunction
    {
        public delegate double ContinuousFunction(double x);

        public double TrapezoidalIntegration(ContinuousFunction Func, double a, double b, double precision = 100)
        {
            double stepSize = (b - a) / precision, sum = 0;
            for (double i = a; i < b; i += stepSize)
            {
                sum += stepSize * (Func(i) + Func(i + stepSize)) / 2;
            }
            return sum;
        }
    }
}
