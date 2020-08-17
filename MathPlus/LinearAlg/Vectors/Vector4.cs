namespace MathPlus.LinearAlg.Vectors
{
    class Vector4 : Vector
    {
        public double X { get => values[0]; set => values[0] = value; }
        public double Y { get => values[1]; set => values[1] = value; }
        public double Z { get => values[2]; set => values[2] = value; }
        public double W { get => values[3]; set => values[3] = value; }

        public Vector4(double x, double y, double z, double w) : base(x, y, z, w) { }
    }
}
