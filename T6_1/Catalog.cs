using System.Collections;
using System.Text.RegularExpressions;

namespace Homewokr_6_1
{
	public class Catalog : IEnumerable<Book>
	{
		private Dictionary<string, Book> books = new Dictionary<string, Book>();
		private static Regex isbnPattern = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$");

		public string AddBook(string isbn, Book book) 
		{
			if (!isbnPattern.IsMatch(isbn))
			{
				return $"Invalid ISBN format: {isbn}";
				throw new ArgumentException("Invalid ISBN format.");
			}

			string normalizedIsbn = NormalizeIsbn(isbn);
			if (!books.ContainsKey(normalizedIsbn))
			{
				books[normalizedIsbn] = book;
				return $"Added book: {book.Title} with ISBN: {isbn}";
			}
			else
			{
				return $"Book with ISBN: {isbn} is already in the catalog.";
			}
		}

		public Book this[string isbn]
		{
			get
			{
				string normalizedIsbn = NormalizeIsbn(isbn);
				books.TryGetValue(normalizedIsbn, out Book book);
				return book;
			}
		}

		private string NormalizeIsbn(string isbn)  
		{
			return isbn.Replace("-", "");
		}

		public IEnumerable<string> GetBookTitles()
		{
			return books.Values.Select(b => b.Title).Distinct().OrderBy(title => title);
		}

		public IEnumerable<Book> GetBooksByAuthor(string authorFullName)
		{
			return books.Values.Where(b => b.Authors.Any(a => $"{a.FirstName} {a.LastName}" == authorFullName))
				.OrderBy(b => b.PublicationDate);
		}

		public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
		{
			return books.Values.SelectMany(b => b.Authors)
				.GroupBy(author => author.FirstName + " " + author.LastName)
				.Select(g => (Author: g.Key, BookCount: g.Count()))
				.OrderBy(a => a.Author);

		}
		private Dictionary<Book, string> bookToIsbn = new Dictionary<Book, string>();
		public string GetIsbnByBook(Book book)
		{
			if (bookToIsbn.TryGetValue(book, out string isbn))
			{
				return isbn;
			}

			return null;
		}

		public IEnumerator<Book> GetEnumerator()
		{
			return books.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
