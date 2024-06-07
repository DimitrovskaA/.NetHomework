using Homework_7_1.Interfaces;
using System.Configuration;
using System.Text.Json;

namespace Homework_7_1.Repositories
{
	public abstract class JSONRepository<T> : IRepository<T>
	{
		protected virtual string RepositoryFileName { get; set; }

		public string FullFileName => Path.Combine(ConfigurationManager.AppSettings["Repositories"] ?? "", RepositoryFileName);

		public IEnumerable<T> GetAll()
		{
			if (!File.Exists(FullFileName))
			{
				SaveAll(new List<T>());
			}
			using StreamReader reader = new StreamReader(FullFileName);
			return JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());
		}

		public bool SaveAll(IEnumerable<T> items)
		{
			using StreamWriter writer = new StreamWriter(FullFileName);
			var jsonString = JsonSerializer.Serialize(items);
			writer.Write(jsonString);
			return true;
		}
	}

}
