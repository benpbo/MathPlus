namespace MathPlus.LinearAlg.Vectors
{

    public class Vector2 : Vector
    {
        public double X { get => values[0]; set => values[0] = value; }
        public double Y { get => values[1]; set => values[1] = value; }

        public Vector2(double x, double y) : base(x, y) { }

    }

}
