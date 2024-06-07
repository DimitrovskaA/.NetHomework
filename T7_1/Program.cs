using Homework_7_1.Infrastructure;

namespace Homework_7_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books_info.csv");

			if (!File.Exists(csvFilePath))
			{
				Console.WriteLine("CSV file not found: " + csvFilePath);
				return;
			}

			var (paperLibrary, ebookLibrary) = LibraryLoader.LoadLibraries(csvFilePath);

			Console.WriteLine("Paper Book Titles:");
			foreach (var title in paperLibrary.Catalog.GetBookTitles())
			{
				Console.Write(title + ", ");
			}

			Console.WriteLine("\nEBook Titles:");
			foreach (var title in ebookLibrary.Catalog.GetBookTitles())
			{
				Console.Write(title + ", ");
			}

			Console.WriteLine("\nPublishers:");
			foreach (var publisher in paperLibrary.PressReleaseItems)
			{
				Console.Write(publisher + ", ");
			}

			Console.WriteLine("\nEBook Formats:");
			foreach (var format in ebookLibrary.PressReleaseItems)
			{
				Console.Write(format + ", ");
			}
		}
	}
}
