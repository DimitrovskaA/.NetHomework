using System.Xml.Serialization;

namespace Homework_8
{
	public class XMLRepository
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
