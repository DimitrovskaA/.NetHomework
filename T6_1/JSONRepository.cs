using System.Text.Json;
using System.Configuration;
using Homewokr_6_1;

namespace Homework_6_1
{
	public class JSONRepository : IRepository<Catalog>
	{
		protected virtual string DirectoryPath { get; set; } = "json_directory";

		public JSONRepository()
		{
			DirectoryPath = ConfigurationManager.AppSettings["Repositories"] ?? DirectoryPath;
		}

		public void SaveCatalog(Catalog catalog, string filePath)
		{
			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}

			var authorGroups = catalog.SelectMany(book => book.Authors.Select(author => (author, book)))
									   .GroupBy(tuple => tuple.author);

			foreach (var group in authorGroups)
			{
				var author = group.Key;
				string authorFileName = $"{author.FirstName}_{author.LastName}.json";
				string fullFilePath = Path.Combine(filePath, authorFileName);

				var books = group.Select(g => new
				{
					g.book.Title,
					g.book.PublicationDate,
					ISBN = catalog.GetIsbnByBook(g.book),
					Authors = g.book.Authors.Select(a => new { a.FirstName, a.LastName, a.DateOfBirth })
				}).ToList();

				var json = System.Text.Json.JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
				File.WriteAllText(fullFilePath, json);
			}
		}

		public Catalog LoadCatalog(string filePath)
		{
			var catalog = new Catalog();
			if (!Directory.Exists(filePath))
			{
				return catalog; 
			}

			var jsonFiles = Directory.GetFiles(filePath, "*.json");

			foreach (var file in jsonFiles)
			{
				var books = System.Text.Json.JsonSerializer.Deserialize<List<dynamic>>(File.ReadAllText(file));
				foreach (var book in books)
				{
					var authors = ((JsonElement)book.Authors).EnumerateArray()
									.Select(a => new Author(
										a.GetProperty("FirstName").GetString(),
										a.GetProperty("LastName").GetString(),
										a.GetProperty("DateOfBirth").GetDateTime()))
									.ToArray();

					string isbn = book.ISBN;
					catalog.AddBook(isbn, new Book(book.Title, book.PublicationDate, authors));
				}
			}
			return catalog;
		}
	}
}
