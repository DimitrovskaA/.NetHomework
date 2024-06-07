using Homework_7_1.DAL;

namespace Homework_7_1.Interfaces
{
	public interface IUnitOfWork<T>
	{
		IEnumerable<T> GetAll();
		void SaveAll(IEnumerable<T> items);
	}
}
