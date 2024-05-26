using System.Text.RegularExpressions;

namespace Homework_5_2
{
	public class Catalog 
	{
		private Dictionary<string, Book> books = new Dictionary<string, Book>();
		private static Regex isbnPattern = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$");

		public void AddBook(string isbn, Book book)
		{
			if (!isbnPattern.IsMatch(isbn) && !IsValidUnformattedIsbn(isbn))
			{
				Console.WriteLine($"Invalid ISBN format: {isbn}");
				throw new ArgumentException("Invalid ISBN format.");
			}

			string normalizedIsbn = NormalizeIsbn(isbn);
			if (!books.ContainsKey(normalizedIsbn))
			{
				books[normalizedIsbn] = book;
				Console.WriteLine($"Added book: {book.Title} with ISBN: {isbn}");
			}
			else
			{
				Console.WriteLine($"Book with ISBN: {isbn} is already in the catalog.");
			}

			Console.WriteLine($"Current books count: {books.Count}");
		}

		public Book GetBook(string isbn)
		{
			string normalizedIsbn = NormalizeIsbn(isbn);
			books.TryGetValue(normalizedIsbn, out Book book);
			return book;
		}

		private string NormalizeIsbn(string isbn)
		{
			return isbn.Replace("-", "");
		}

		private bool IsValidUnformattedIsbn(string isbn)
		{
			return isbn.Length == 13 && isbn.All(char.IsDigit);
		}

		public IEnumerable<string> GetBookTitles()
		{
			var titles = books.Values.Select(b => b.Title).Distinct().OrderBy(title => title);
			Console.WriteLine("\nBook Titles Sorted Alphabetically:");
			foreach (var title in titles)
			{
				Console.WriteLine(title);
			}
			return titles;
		}

		public IEnumerable<Book> GetBooksByAuthor(string author)
		{
			var booksByAuthor = books.Values
				.Where(b => b.Authors.Contains(author))
				.OrderBy(b => b.PublicationDate);

			Console.WriteLine($"\nBook(s) By: {author}: sorted by the Publication Date");
			foreach (var book in booksByAuthor)
			{
				Console.WriteLine(book.Title);
			}
			return booksByAuthor;
		}

		public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
		{
			var authorBookCounts = books.Values
				.SelectMany(b => b.Authors)
				.GroupBy(author => author)
				.Select(g => (Author: g.Key, BookCount: g.Count()))
				.OrderBy(a => a.Author);

			Console.WriteLine("\nAuthor’s name – the number of his/hers books in the catalog:");
			foreach (var authorBookCount in authorBookCounts)
			{
				Console.WriteLine($"{authorBookCount.Author}: {authorBookCount.BookCount}");
			}
			return authorBookCounts;
		}
	}
}
