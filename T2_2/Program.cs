namespace Homework_2_2
{
	public class Program
	{
		static void Main(string[] args)
		{
			var matrix1 = new DiagonalMatrix(5, 5, 5);
			var matrix2 = new DiagonalMatrix(2, 2, 2 ,1);

			//DiagonalMatrix matrix2 = new DiagonalMatrix(0, 0,0);

			DiagonalMatrix sumMatrix = matrix1.Add(matrix2);
			string diagSize1 = matrix1.ToString();
			string diagSize2 = matrix2.ToString();
			Console.WriteLine($"{diagSize1}\nMatrix 1:");
			PrintMatrix(matrix1);

			Console.WriteLine($"{diagSize2}\nMatrix 2:");
			PrintMatrix(matrix2);

			Console.WriteLine("Sum Matrix:");
			PrintMatrix(sumMatrix);

			Console.WriteLine($"Matrix 1 elements sum =: {matrix1.Track()}");
			Console.WriteLine($"Matrix 2 elements sum =: {matrix2.Track()}");
			Console.WriteLine($"Sum Matrix Track: {sumMatrix.Track()}");

			Console.WriteLine($"Matrix 1 Equals Matrix 2: {matrix1.Equals(matrix2)}");
			Console.WriteLine($"Matrix 1 Equals Sum Matrix: {matrix1.Equals(sumMatrix)}");
        }

		static void PrintMatrix(DiagonalMatrix matrix)
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