namespace Homework_7_1.Entities
{
	public class Book
	{
		public string Title { get; private set; }
		public DateTime? PublicationDate { get; private set; }
		public List<Author>? Authors { get; set; }

		public Book(string title, DateTime? publicationDate, IEnumerable<Author> authors)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException("Title cannot be null or empty.");

			Title = title;
			PublicationDate = publicationDate;
			Authors = new List<Author>(authors);
		}
	}
}
