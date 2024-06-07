namespace Homework_7_1.Entities
{
	public class EBook : Book 
	{
		public string ResourceIdentifier { get; private set; }
		public List<string> AvailableElectronicFormats { get; private set; }

		public EBook(string title, DateTime? publicationDate, IEnumerable<Author> authors, string resourceIdentifier, List<string> availableFormats)
			: base(title, publicationDate, authors)
		{
			ResourceIdentifier = resourceIdentifier;
			AvailableElectronicFormats = new List<string>(availableFormats);
		}
	}
}
