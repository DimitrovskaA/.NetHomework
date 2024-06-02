using Homework_6_1;

namespace Homewokr_6_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var author1 = new Author("J.K.", "Rowling", new DateTime(1965, 7, 31));
			var author2 = new Author("Clay", "Griffith", new DateTime(1967, 1, 1));
			var author3 = new Author("Susan", "Griffith", new DateTime(1959, 12, 31));

			var book1 = new Book("Harry Potter and the Chamber of Secrets", new DateTime(1998, 7, 2), new[] { author1 });
			var book2 = new Book("Flash: The Haunting of Barry Allen", new DateTime(2016, 11, 29), new[] { author2 });
			var book3 = new Book("Harry Potter and the Goblet of Fire", new DateTime(2000, 7, 8), new[] { author1 });
			var book4 = new Book("Arrow: A Generation of Vipers", new DateTime(2017, 3, 28), new[] { author2, author3 });


			var catalog = new Catalog();
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);
			catalog.AddBook("123-4-56-789012-7", book3);
			catalog.AddBook("978-0-45-284232-6", book4);

			var xmlRepo = new XMLRepository();
			xmlRepo.SaveCatalog(catalog, "catalog.xml");
			var loadedCatalogFromXml = xmlRepo.LoadCatalog("catalog.xml");
			Console.WriteLine("Catalog from XML is identical: " + (catalog.Equals(loadedCatalogFromXml) ? "Yes" : "No"));

			var jsonRepo = new JSONRepository();
			jsonRepo.SaveCatalog(catalog, "json_directory");
			var loadedCatalogFromJson = jsonRepo.LoadCatalog("json_directory");
			Console.WriteLine("Catalog from JSON is identical: " + (catalog.Equals(loadedCatalogFromJson) ? "Yes" : "No"));
		
		}
	}
}