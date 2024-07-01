using System.Text.Json;

namespace Homework_8
{
	public class JSONRepository
	{
		public void Save(Catalog catalog, string filePath)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			var jsonString = JsonSerializer.Serialize(catalog.Books, options);
			File.WriteAllText(filePath, jsonString);
		}
	}
}
