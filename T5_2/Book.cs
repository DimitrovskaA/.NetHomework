namespace Homework_5_2
{
	public class Book
	{
		public string Title { get; private set; }
		public DateTime? PublicationDate { get; private set; }
		public HashSet<string> Authors { get; set; }

		public Book(string title, DateTime? publicationDate, IEnumerable<string> authors)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException("Title cannot be null or empty.");

			Title = title;
			PublicationDate = publicationDate;
			Authors = new HashSet<string>(authors);
		}
	}
}
