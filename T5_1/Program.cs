namespace Homework_5_1
{
	public class Program
	{
		static void Main(string[] args)
		{
			SparseMatrix matrix = new SparseMatrix(3, 4);

			matrix[0, 1] = 1;
			matrix[1, 2] = 2;
			matrix[2, 0] = 3;
			matrix[2, 2] = 4;
	
			Console.WriteLine("Sparse Matrix:");
			Console.WriteLine(matrix);

			Console.WriteLine("All elements:");
			foreach (var element in matrix)
			{
				Console.Write(element + " ");
			}

			Console.WriteLine("\nNon-zero elements:");
			foreach (var (i, j, value) in matrix.GetNonzeroElements())
			{
				Console.WriteLine($"({i}, {j}): {value}");
			}
			Console.WriteLine("Count of 0: " + matrix.GetCount(0));
			Console.WriteLine("Count of 5: " + matrix.GetCount(5)); 
		}
	}
}