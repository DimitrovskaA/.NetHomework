namespace Homework_4_1
{ 
	public class Program
	{
		static void Main(string[] args)
		{
			var matrix1 = new DiagonalMatrix<int>(3);
			matrix1[0, 0] = 1;
			matrix1[1, 1] = 1;
			matrix1[2, 2] = 1;

			var matrix2 = new DiagonalMatrix<int>(4);
			matrix2[0, 0] = 2;
			matrix2[1, 1] = 2;
			matrix2[2, 2] = 2;
			matrix2[3, 3] = 1;

			var sumMatrix = matrix1.Add(matrix2, (x, y) => x + y);

			Console.WriteLine("Matrix 1:");
			PrintMatrix(matrix1);

			Console.WriteLine("Matrix 2:");
			PrintMatrix(matrix2);

			Console.WriteLine("Matrix1 + Matrix 2:");
			PrintMatrix(sumMatrix);

			var tracker = new MatrixTracker<int>(matrix1);
			matrix1[1, 1] = 10;
			matrix1[2, 2] = 20;
			Console.WriteLine("Matrix 1 after changes:");
			PrintMatrix(matrix1);

			tracker.Undo();
			Console.WriteLine("Matrix 1 after undo:");
			PrintMatrix(matrix1);
		
		}
		static void PrintMatrix<T>(DiagonalMatrix<T> matrix)
		{
			for (int i = 0; i < matrix.Size; i++)
			{
				for (int j = 0; j < matrix.Size; j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}