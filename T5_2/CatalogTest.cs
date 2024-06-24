using Homework_5_2;

namespace CatalogTests
{
	[TestClass]
	public class CatalogTest
	{
		private Catalog catalog;
		private Book book1;
		private Book book2;
		private Book book3;
		private Book book4;

		[TestInitialize]
		public void Setup()
		{
			book1 = new Book("Harry Potter and the Chamber of Secrets", new DateTime(1998, 7, 2), new[] { "J.K. Rowling" });
			book2 = new Book("Flash: The Haunting of Barry Allen", new DateTime(2016, 11, 29), new[] { "Clay Griffith" });
			book3 = new Book("Harry Potter and the Goblet of Fire", new DateTime(2000, 7, 8), new[] { "J.K. Rowling" });
			book4 = new Book("Arrow: A Generation of Vipers", new DateTime(2017, 3, 28), new[] { "Clay Griffith", "Susan Griffith" });

			catalog = new Catalog();
		}
		[TestMethod]
		public void AddBookTest()
		{
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);

			Assert.AreEqual(book1, catalog.GetBook("123-4-56-789012-9"));
			Assert.AreEqual(book2, catalog.GetBook("1234567890128"));
		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddBookWhenIsbnIsInvalid()
		{
			catalog.AddBook("123-6789-128124", book1);
		}

		[TestMethod]
		public void GetBookTitlesSortedAlphabeticallyTest()
		{
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);
			catalog.AddBook("123-4-56-789012-7", book3);

			var titles = catalog.GetBookTitles().ToList();

			CollectionAssert.AreEqual(new List<string> { "Flash: The Haunting of Barry Allen", "Harry Potter and the Chamber of Secrets", "Harry Potter and the Goblet of Fire" }, titles);
		}

		[TestMethod]
		public void GetBooksByAuthorSortedByPublicationDateTest()
		{
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);
			catalog.AddBook("123-4-56-789012-7", book3);
			catalog.AddBook("978-0-45-284232-6", book4);

			var booksByJkRowling = catalog.GetBooksByAuthor("J.K. Rowling").ToList();
			var booksByClayGriffith = catalog.GetBooksByAuthor("Clay Griffith").ToList();

			CollectionAssert.AreEqual(new List<Book> { book1, book3 }, booksByJkRowling);
			CollectionAssert.AreEqual(new List<Book> { book2, book4 }, booksByClayGriffith);
		}

		[TestMethod]
		public void GetAuthorBookCountsTest()
		{
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);
			catalog.AddBook("123-4-56-789012-7", book3);
			catalog.AddBook("978-0-45-284232-6", book4);

			var authorBookCounts = catalog.GetAuthorBookCounts().ToList();

			var expectedCounts = new List<(string Author, int BookCount)>
			{
				("Clay Griffith", 2),
				("J.K. Rowling", 2),
				("Susan Griffith", 1)
			};

			CollectionAssert.AreEqual(expectedCounts, authorBookCounts);
		}
	}
}