using System.Xml.Serialization;

namespace Homework_7
{
	public class XMLRepository : IRepository
	{
		public void Save(Catalog catalog, string filePath)
		{
			var xmlSerializer = new XmlSerializer(typeof(List<Book>));
			using (var writer = new StreamWriter(filePath))
			{
				xmlSerializer.Serialize(writer, catalog.Books);
			}
		}
	}
}
