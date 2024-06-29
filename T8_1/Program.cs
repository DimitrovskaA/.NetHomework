﻿namespace Homework_8
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var paperBookFactory = new PaperBookFactory();
			var eBookFactory = new EBookFactory();

			var paperLibary = new Libary(paperBookFactory.CreateCatalog(), paperBookFactory.CreatePressReleaseItems());
			var eBookLibary = new Libary(eBookFactory.CreateCatalog(), eBookFactory.CreatePressReleaseItems());

			var booksInfoPath = "books_info.csv";
			await LoadBooksFromCSVAsync(booksInfoPath, paperLibary, eBookLibary);

			await InitializeEBookPages(eBookLibary);

			var jsonRepo = new JSONRepository();
			jsonRepo.Save(paperLibary.Catalog, "paper_library.json");
			jsonRepo.Save(eBookLibary.Catalog, "ebook_library.json");

			var xmlRepo = new XMLRepository();
			xmlRepo.Save(paperLibary.Catalog, "paper_library.xml");
			xmlRepo.Save(eBookLibary.Catalog, "ebook_library.xml");

			Console.WriteLine("Libraries saved to JSON and XML repositories.");
		}

		private static async Task LoadBooksFromCSVAsync(string filePath, Libary paperLibrary, Libary eBookLibrary)
		{
			var lines = await File.ReadAllLinesAsync(filePath);
			foreach (var line in lines.Skip(1))
			{
				var columns = line.Split(',');

				var creator = columns[0];
				var format = columns[1];
				var identifier = columns[2];
				var publicDate = columns[3];
				var publisher = columns[4];
				var relatedExternalId = columns[5];
				var title = columns[6];

				if (format.Contains("EPUB"))
				{
					var eBook = new EBook(creator, format, identifier, publicDate, publisher, relatedExternalId, title);
					eBookLibrary.Catalog.Books.Add(eBook);
				}
				else
				{
					var paperBook = new PaperBook(creator, format, identifier, publicDate, publisher, relatedExternalId, title);
					paperLibrary.Catalog.Books.Add(paperBook);
				}
			}
		}
	}
}
