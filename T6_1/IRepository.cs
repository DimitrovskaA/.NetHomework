namespace Homewokr_6_1
{
	public interface IRepository<T>
	{
		void SaveCatalog(T catalog, string filePath);
		T LoadCatalog(string filePath);
	}

}
