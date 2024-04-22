
namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter two integers a and b:");
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());

			Console.WriteLine($"Integers in the range from {a} to {b} with exactly two symbols A in their duodecimal representation:");

			for (int i = a; i <= b; i++)
			{
				string duodecimalRepresentation = ConvertToDuodecimal(i);
				int countA = CountSymbol(duodecimalRepresentation, 'A');

				if (countA == 2)
				{
					Console.Write(i + "   ");
				}
			}

		}
		static string ConvertToDuodecimal(int number)
		{
			const string digits = "0123456789AB";
			string result = "";

			do
			{
				int remainder = number % 12;
				result = digits[remainder] + result;
				number /= 12;
			} while (number > 0);

			return result;
		}

		static int CountSymbol(string str, char symbol)
		{
			int count = 0;
			foreach (char c in str)
			{
				if (c == symbol)
				{
					count++;
				}
			}
			return count;
		}
	}
}