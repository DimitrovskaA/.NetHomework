namespace Homewokr_6_1
{
	public interface IRepository<T>
	{
		public void  Save(T catalog, string filePath);
		T Load(string filePath);
	}

}
