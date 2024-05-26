using Homework_4_1;

namespace MatrixTests
{
	[TestClass]
	public class MatrixTestss
	{
		[TestMethod]
		public void AddTwoMatricesTest()
		{
			var matrix1 = new DiagonalMatrix<int>(3);
			matrix1[0, 0] = 5;
			matrix1[1, 1] = 5;
			matrix1[2, 2] = 5;

			var matrix2 = new DiagonalMatrix<int>(3);
			matrix2[0, 0] = 2;
			matrix2[1, 1] = 2;
			matrix2[2, 2] = 2;

			var sumMatrix = matrix1.Add(matrix2, (x, y) => x + y);

			Assert.AreEqual(7, sumMatrix[0, 0]);
			Assert.AreEqual(7, sumMatrix[1, 1]);
			Assert.AreEqual(7, sumMatrix[2, 2]);
		}

		[TestMethod]
		public void AddTwoMatricesDoubleTest()
		{
			var matrix1 = new DiagonalMatrix<double>(2);
			matrix1[0, 0] = 2.5;
			matrix1[1, 1] = 3.5;

			var matrix2 = new DiagonalMatrix<double>(2);
			matrix2[0, 0] = 1.5;
			matrix2[1, 1] = 2.5;

			var sumMatrix = matrix1.Add(matrix2, (x, y) => x + y);

			Assert.AreEqual(4.0, sumMatrix[0, 0]);
			Assert.AreEqual(6.0, sumMatrix[1, 1]);
		}
	}
}