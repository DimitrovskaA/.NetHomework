namespace Homework_5_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var book1 = new Book("Harry Potter and the Chamber of Secrets", new DateTime(1998, 7, 2), new[] { "J.K. Rowling" });
			var book2 = new Book("Flash: The Haunting of Barry Allen", new DateTime(2016, 11, 29), new[] { "Clay Griffith" });
			var book3 = new Book("Harry Potter and the Goblet of Fire", new DateTime(2000, 7, 8), new[] { "J.K. Rowling" });
			var book4 = new Book("Arrow: A Generation of Vipers", new DateTime(2017, 3, 28), new[] { "Clay Griffith" ,"Susan Griffith" });

			var catalog = new Catalog();
			catalog.AddBook("123-4-56-789012-9", book1);
			catalog.AddBook("1234567890128", book2);
			catalog.AddBook("123-4-56-789012-7", book3);
			catalog.AddBook("978-0-45-284232-6", book4); 

			catalog.GetAuthorBookCounts();
			
			catalog.GetBookTitles();
			catalog.GetBooksByAuthor("J.K. Rowling");
			
			catalog.GetBooksByAuthor("Clay Griffith");
			catalog.GetBooksByAuthor("Susan Griffith");
		}
	}
}