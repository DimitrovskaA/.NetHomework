using Homework_2_2;

namespace DiagonalMatrixx
{
	[TestClass]
	public class DigaonalMatrixTests
	{
		[TestMethod]
		public void TestAddExtensionMethod()
		{
			var matrix1 = new DiagonalMatrix(1, 2, 3);
			var matrix2 = new DiagonalMatrix(4, 5, 6);

			var resultMatrix = matrix1.Add(matrix2);

			Assert.AreEqual(5, resultMatrix[0, 0]);
			Assert.AreEqual(7, resultMatrix[1, 1]);
			Assert.AreEqual(9, resultMatrix[2, 2]);
		}

		[TestMethod]
		public void TestTrackMethod()
		{
			var matrix = new DiagonalMatrix(1, 2, 3);

			var trackSum = matrix.Track();

			Assert.AreEqual(6, trackSum);
		}
	}
}