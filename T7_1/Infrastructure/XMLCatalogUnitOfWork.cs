using Homework_7_1.DAL;
using Homework_7_1.Entities;
using Homework_7_1.Interfaces;
using Homework_7_1.Repositories;
using System.Configuration;
using System.Xml.Serialization;

namespace Homework_7_1.Infrastructure
{
	public class XMLCatalogUnitOfWork : IUnitOfWork<Catalog>
	{
		private XMLCatalogRepository _xmlCatalogRepository;

		public XMLCatalogRepository XMLCatalogRepository => _xmlCatalogRepository ??= new XMLCatalogRepository();
		public IEnumerable<Catalog> GetAll()
		{
			List<Catalog> catalogs = new List<Catalog>();

			string filePath = ConfigurationManager.AppSettings["Repositories"];

			if (!Directory.Exists(filePath))
			{
				return catalogs; 
			}

			var xmlFiles = Directory.GetFiles(filePath, "*.xml");

			foreach (var xmlFile in xmlFiles)
			{
				var catalog = new Catalog();
				List<BookEntity> books;

				using (StreamReader reader = new StreamReader(xmlFile))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(List<BookEntity>));
					books = (List<BookEntity>)serializer.Deserialize(reader);
				}

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
					string authorFileName = $"{author.FirstName}_{author.LastName}.xml";
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

					using (StreamWriter writer = new StreamWriter(fullFilePath))
					{
						XmlSerializer serializer = new XmlSerializer(typeof(List<BookEntity>));
						serializer.Serialize(writer, books);
					}
				}
			}
		}
	}
}
