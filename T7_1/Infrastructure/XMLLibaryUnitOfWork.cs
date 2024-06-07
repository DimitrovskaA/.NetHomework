using Homework_7_1.DAL;
using Homework_7_1.Interfaces;
using Homework_7_1.Repositories;
using System.Configuration;
using System.Xml.Serialization;

namespace Homework_7_1.Infrastructure
{
	public class XMLLibaryUnitOfWork : IUnitOfWork<Library>
	{
		private XMLLibaryRepository _xmlLibraryRepository;
		public XMLLibaryRepository XMLLibraryRepository => _xmlLibraryRepository ??= new XMLLibaryRepository();

		public IEnumerable<Library> GetAll()
		{
			throw new NotImplementedException();
		}

		public void SaveAll(IEnumerable<Library> items)
		{
			var filePath = ConfigurationManager.AppSettings["Repositories"];
			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}

			var xmlFilePath = Path.Combine(filePath, "Library.xml");

			using (var writer = new StreamWriter(xmlFilePath))
			{
				var serializer = new XmlSerializer(typeof(List<Library>));
				serializer.Serialize(writer, items);
			}
		}
	}
}
