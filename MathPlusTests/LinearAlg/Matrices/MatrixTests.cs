using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathPlus.LinearAlg.Matrices.Tests
{
    using Vectors;
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void LinearTransformationTest()
        {
            Matrix mat = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector vec = new Vector3(10, 11, 12);

            Assert.AreNotEqual(mat.LinearTransformation(vec), new Vector(138, 171, 204));
        }

        [TestMethod()]
        public void LinearTransformationTest1()
        {
            Matrix mat = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Vector vec = new Vector(7, 8);
            Assert.IsTrue(mat.LinearTransformation(vec).Equals(new Vector(39, 54, 69)));
        }
    }
}