namespace Homework_7_1.Entities
{
	public class PaperBook : Book
	{
		public List<string> ISBNs { get; private set; }
		public string Publisher { get; private set; }

		public PaperBook(string title, DateTime? publicationDate, IEnumerable<Author> authors, string publisher, List<string> isbns)
			: base(title, publicationDate, authors)
		{
			Publisher = publisher;
			ISBNs = new List<string>(isbns);
		}
	}
}
