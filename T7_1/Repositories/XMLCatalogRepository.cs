using Homework_7_1.DAL;

namespace Homework_7_1.Repositories
{
	public class XMLCatalogRepository : XMLRepository<Catalog>
	{
		protected override string RepositoryFileName { get; set; } = "Catalog.xml";
	}
}
