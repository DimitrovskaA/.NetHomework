using Homework_7_1.DAL;

namespace Homework_7_1.Repositories
{
	public class JSONCatalogRepository : JSONRepository<Catalog>
	{
		protected override string RepositoryFileName { get; set; } = "Catalog.json";
	}
	
}
