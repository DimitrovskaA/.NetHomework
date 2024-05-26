using Homework_5_1;

namespace SparseMatrixTests
{
	[TestClass]
	public class SparseMatrixTest
	{
		[TestMethod]
		public void CorrectValuesTest()
		{
			SparseMatrix matrix = new SparseMatrix(3, 4);

			matrix[0, 1] = 1;
			matrix[1, 2] = 2;
			matrix[2, 0] = 3;
			matrix[2, 2] = 4;

			Assert.AreEqual(1, matrix[0, 1]);
			Assert.AreEqual(2, matrix[1, 2]);
			Assert.AreEqual(3, matrix[2, 0]);
			Assert.AreEqual(4, matrix[2, 2]);
		}
		[TestMethod]
		public void CountNonZeroElementsTest()
		{
			SparseMatrix matrix = new SparseMatrix(3, 4);

			matrix[0, 1] = 1;
			matrix[1, 2] = 2;
			matrix[2, 0] = 3;
			matrix[2, 2] = 4;

			var nonzeroElements = matrix.GetNonzeroElements().ToList();
			Assert.AreEqual(4, nonzeroElements.Count);
			
		}
		[TestMethod]
		public void CountZeroElementsTest()
		{
			SparseMatrix matrix = new SparseMatrix(3, 4);

			matrix[0, 1] = 1;
			matrix[1, 2] = 2;
			matrix[2, 0] = 3;
			matrix[2, 2] = 4;

			Assert.AreEqual(8, matrix.GetCount(0));
		}
	}
}	