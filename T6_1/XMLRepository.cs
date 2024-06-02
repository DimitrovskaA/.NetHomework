using System.Xml.Serialization;

namespace Homewokr_6_1
{
	public class XMLRepository : IRepository<Catalog>
	{
		public void SaveCatalog(Catalog catalog, string filePath)
		{
			var serializer = new XmlSerializer(typeof(Catalog));
			using (var writer = new StreamWriter(filePath))
			{
				serializer.Serialize(writer, catalog);
			}
		}

		public Catalog LoadCatalog(string filePath)
		{
			var serializer = new XmlSerializer(typeof(Catalog));
			using (var reader = new StreamReader(filePath))
			{
				return (Catalog)serializer.Deserialize(reader);
			}
		}
	}
}
