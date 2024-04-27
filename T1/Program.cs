﻿namespace Homework_Task1_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter two integers a and b:");
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());

			Console.WriteLine($"Integers in the range from {a} to {b} with exactly two symbols A in their duodecimal representation:");

			if (a <= b)
			{
				for (int i = a; i <= b; i++)
				{
					CheckAndPrintIntegersWithTwoAs(i);
				}
			}
			else
			{
				for (int i = a; i >= b; i--)
				{
					CheckAndPrintIntegersWithTwoAs(i);
				}
			}

			Console.ReadKey();
		}
		static void CheckAndPrintIntegersWithTwoAs(int number)
		{
			string duodecimalRepresentation = ConvertToDuodecimal(number);
			int countA = CountSymbol(duodecimalRepresentation, 'A');

			if (countA == 2)
			{
				Console.Write(number + "   ");
			}

		}
		static string ConvertToDuodecimal(int number)
		{
			/*const string duoSystemSymbols = "0123456789AB";
			string result = "";

			do
			{
				int remainder = number % 12;
				result = duoSystemSymbols[remainder] + result;
				number /= 12;
			} while (number > 0);

			return result;*/
			const string duoSystemSymbols = "0123456789AB";
			string result = "";

			/*if (number == 0)
			{
				return "0";
			}*/

			bool isNegative = false;
			if (number < 0)
			{
				isNegative = true;
				number = Math.Abs(number);
			}

			while (number != 0)
			{
				int remainder = number % 12;
				result = duoSystemSymbols[remainder] + result;
				number /= 12;
			}

			if (isNegative)
			{
				result = "-" + result;
			}

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