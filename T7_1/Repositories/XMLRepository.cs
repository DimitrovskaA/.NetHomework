using Homework_7_1.Interfaces;
using System.Configuration;
using System.Xml.Serialization;

namespace Homework_7_1.Repositories
{
	public abstract class XMLRepository<T> : IRepository<T>
	{
		protected virtual string RepositoryFileName { get; set; }

		protected string FullFileName => Path.Combine(ConfigurationManager.AppSettings["Repositories"] ?? "", RepositoryFileName);

		public IEnumerable<T> GetAll()
		{
			if (!File.Exists(FullFileName))
			{
				SaveAll(new List<T>());
			}
			using StreamReader reader = new StreamReader(FullFileName);
			XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
			return (List<T>)serializer.Deserialize(reader);
		}

		public bool SaveAll(IEnumerable<T> items)
		{
			using StreamWriter writer = new StreamWriter(FullFileName);
			XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
			serializer.Serialize(writer, items);
			return true;
		}
	}
}
