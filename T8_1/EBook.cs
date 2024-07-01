namespace Homework_8
{
	public class EBook : Book
	{
		public int Pages { get; set; }

		public EBook(string creator, string format, string identifier, string publicDate, string publisher, string relatedExternalId, string title)
			: base(creator, format, identifier, publicDate, publisher, relatedExternalId, title)
		{
		}
	}
}
