using Homework_7_1.DAL;

namespace Homework_7_1.Repositories
{
	public class XMLLibaryRepository : JSONRepository<Library>
	{
		protected override string RepositoryFileName { get; set; } = "Library.xml";
	}
}
