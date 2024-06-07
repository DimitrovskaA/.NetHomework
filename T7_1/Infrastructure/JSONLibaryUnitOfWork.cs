using Homework_7_1.DAL;
using Homework_7_1.Interfaces;
using Homework_7_1.Repositories;
using System.Configuration;
using System.Text.Json;

namespace Homework_7_1.Infrastructure
{
	public class JSONLibaryUnitOfWork : IUnitOfWork<Library>
	{
		private JSONLibaryRepository _jsonLibraryRepository;
		public JSONLibaryRepository JSONLibraryRepository => _jsonLibraryRepository ??= new JSONLibaryRepository();
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

			var jsonFilePath = Path.Combine(filePath, "Library.json");

			using (var writer = new StreamWriter(jsonFilePath))
			{
				var jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
				writer.Write(jsonString);
			}
		}
	}
}
