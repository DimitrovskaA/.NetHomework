using System.Text.Json;

namespace Homework_7
{
	public class JSONRepository : IRepository
	{
		public void Save(Catalog catalog, string filePath)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			var jsonString = JsonSerializer.Serialize(catalog.Books, options);
			File.WriteAllText(filePath, jsonString);
		}
	}
}
