using Homework_7_1.DAL;

namespace Homework_7_1.Repositories
{
	public class JSONLibaryRepository : JSONRepository<Library>
	{
		protected override string RepositoryFileName { get; set; } = "Library.json";
	}
}
