using Homework_7_1.Entities;
using System.Collections;
namespace Homework_7_1.DAL
{
	public class Catalog :IEnumerable<Book>
	{
		private Dictionary<string, Book> books = new Dictionary<string, Book>();

		public string AddBook(string key, Book book)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

			if (!books.ContainsKey(key))
			{
				books[key] = book;
				return $"Added book: {book.Title} with key: {key}";
			}
			else
			{
				return $"Book with key: {key} is already in the catalog.";
			}
		}

		public Book this[string key]
		{
			get
			{
				books.TryGetValue(key, out Book book);
				return book;
			}
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
