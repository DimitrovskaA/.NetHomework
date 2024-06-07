using Homework_7_1.DAL;
using Homework_7_1.Entities;
using Homework_7_1.Interfaces;
using Homework_7_1.Repositories;
using System.Configuration;
using System.Text.Json;

namespace Homework_7_1.Infrastructure
{
	public class JSONCatalogUnitOfWork : IUnitOfWork<Catalog>
	{
		private JSONCatalogRepository _jsonCatalogRepository;
		public JSONCatalogRepository JSONCatalogRepository => _jsonCatalogRepository ??= new JSONCatalogRepository();

		public void SaveAll(IEnumerable<Catalog> catalogs)
		{
			string filePath = ConfigurationManager.AppSettings["Repositories"];

			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}

			foreach (var catalog in catalogs)
			{
				var authorGroups = catalog.SelectMany(book => book.Authors.Select(author => (author, book)))
										   .GroupBy(tuple => tuple.author);

				foreach (var group in authorGroups)
				{
					var author = group.Key;
					string authorFileName = $"{author.FirstName}_{author.LastName}.json";
					string fullFilePath = Path.Combine(filePath, authorFileName);

					var books = group.Select(g => new BookEntity
					{
						Title = g.book.Title,
						PublicationDate = g.book.PublicationDate,
						Authors = g.book.Authors.Select(a => new AuthorEntity
						{
							FirstName = a.FirstName,
							LastName = a.LastName,
							DateOfBirth = a.DateOfBirth
						}).ToList()
					}).ToList();

					var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
					File.WriteAllText(fullFilePath, json);
				}
			}
		}
		public IEnumerable<Catalog> GetAll()
		{
			List<Catalog> catalogs = new List<Catalog>();

			string filePath = ConfigurationManager.AppSettings["Repositories"];

			if (!Directory.Exists(filePath))
			{
				return catalogs; 
			}

			var jsonFiles = Directory.GetFiles(filePath, "*.json");

			foreach (var jsonFile in jsonFiles)
			{
				var catalog = new Catalog();
				var books = JsonSerializer.Deserialize<List<BookEntity>>(File.ReadAllText(jsonFile));

				foreach (var book in books)
				{
					var authors = book.Authors.Select(a => new Author(a.FirstName, a.LastName, a.DateOfBirth)).ToList();
					string isbn = book.ISBN;
					catalog.AddBook(isbn, new Book(book.Title, book.PublicationDate, authors));
				}

				catalogs.Add(catalog);
			}

			return catalogs;
		}
	}
}
