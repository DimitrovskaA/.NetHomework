namespace Homework_7_1.DAL
{
	public class BookEntity
	{
		public string Title { get; set; }
		public DateTime? PublicationDate { get; set; }
		public List<AuthorEntity> Authors { get; set; }
		public string ISBN { get; set; }
		public BookEntity() { }

		public BookEntity(string title, DateTime? publicationDate, IEnumerable<AuthorEntity> authors, string isbn)
		{
			Title = title;
			PublicationDate = publicationDate;
			Authors = new List<AuthorEntity>(authors ?? new List<AuthorEntity>());
			ISBN = isbn;
		}
	}
}
