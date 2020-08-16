namespace MathPlus.LinearAlg.Vectors
{
    public class Vector3 : Vector
    {
        public double X { get => values[0]; set => values[0] = value; }
        public double Y { get => values[1]; set => values[1] = value; }
        public double Z { get => values[2]; set => values[2] = value; }

        public Vector3(double x, double y, double z) : base(x, y, z) { }

        public Vector3 CrossProduct(Vector3 v)
        {
            return new Vector3(values[1] * v.values[2] - v.values[1] * values[2],
                               values[2] * v.values[0] - v.values[2] * values[0],
                               values[0] * v.values[2] - v.values[0] * values[2]);
        }
    }
}
