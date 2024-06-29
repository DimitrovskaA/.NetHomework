namespace Homework_8
{
	public abstract class Book
	{
		public string Creator { get; set; }
		public string Format { get; set; }
		public string Identifier { get; set; }
		public string PublicDate { get; set; }
		public string Publisher { get; set; }
		public string RelatedExternalId { get; set; }
		public string Title { get; set; }

		public Book(string creator, string format, string identifier, string publicDate, string publisher, string relatedExternalId, string title)
		{
			Creator = creator;
			Format = format;
			Identifier = identifier;
			PublicDate = publicDate;
			Publisher = publisher;
			RelatedExternalId = relatedExternalId;
			Title = title;
		}
	}
}
