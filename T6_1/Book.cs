namespace Homewokr_6_1
{
	public class Book
	{
		public string Title { get; private set; }
		public DateTime? PublicationDate { get; private set; }
		public HashSet<Author>? Authors { get; set; }

		public Book(string title, DateTime? publicationDate, IEnumerable<Author> authors)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException("Title cannot be null or empty.");

			Title = title;
			PublicationDate = publicationDate;
			Authors = new HashSet<Author>(authors);
		}
	}
}
