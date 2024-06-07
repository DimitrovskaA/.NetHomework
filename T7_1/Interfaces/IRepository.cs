namespace Homework_7_1.Interfaces
{
	public interface IRepository <T>
	{
		IEnumerable<T> GetAll();
		bool SaveAll(IEnumerable<T> items);
	}
}
