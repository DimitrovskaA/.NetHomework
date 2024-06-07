using Homework_7_1.DAL;
using Homework_7_1.Entities;

namespace Homework_7_1.Infrastructure
{
	public static class LibraryLoader
	{
		public static (Library paperLibrary, Library ebookLibrary) LoadLibraries(string csvFilePath)
		{
			var paperBooks = new Catalog();
			var eBooks = new Catalog();
			var publishers = new HashSet<string>();
			var formats = new HashSet<string>();

			using (var reader = new StreamReader(csvFilePath))
			{
				var header = reader.ReadLine();

				string line;
				while ((line = reader.ReadLine()) != null)
				{
					var parts = line.Split(',');
					if (parts.Length < 7) continue; 

					var authorsRaw = parts[0].Split(';');
					var authors = authorsRaw.Select(a =>
					{
						var authorParts = a.Split(' ');
						var firstName = authorParts.Length > 1 ? authorParts[0] : "";
						var lastName = authorParts.Length > 1 ? authorParts[1] : authorParts[0];
						return new Author(firstName, lastName, null);
					}).ToList();

					var availableFormats = parts[1].Split(';').ToList();
					var resourceIdentifier = parts[2];
					var publicationDate = DateTime.TryParse(parts[3], out DateTime parsedDate) ? parsedDate : (DateTime?)null;
					var publisher = parts[4];
					var externalIds = parts[5].Split(';').ToList();
					var title = parts[6];
					if (externalIds.Any(e => e.StartsWith("urn:isbn")))
					{
						paperBooks.AddBook(externalIds.First(), new PaperBook(title, publicationDate, authors, publisher, externalIds));
						publishers.Add(publisher);
					}
					else
					{
						eBooks.AddBook(resourceIdentifier, new EBook(title, publicationDate, authors, resourceIdentifier, availableFormats));
						formats.UnionWith(availableFormats);
					}
				}
			}

			return (
				new Library(paperBooks, publishers.ToList()),
				new Library(eBooks, formats.ToList())
			);

		}
	}
}