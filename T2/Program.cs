using System;

class Program
{
	static void Main(string[] args)
	{
		Console.Write("Enter the first 9 digits of the ISBN: ");
		string isbnInput = Console.ReadLine();

		char checkDigit = CalculateCheckDigit(isbnInput);

		Console.WriteLine("The complete ISBN is: " + isbnInput + checkDigit);
	}

	static char CalculateCheckDigit(string isbn)
	{
		int total = 0;

		for (int i = 0; i < 9; i++)
		{
			total += int.Parse(isbn[i].ToString()) * (10 - i);
		}

		int checkDigit = (11 - (total % 11)) % 11;

		if (checkDigit == 10)
		{
			return 'X';
		}
		else
		{
			return (char)(checkDigit + '0');
		}
	}

}
