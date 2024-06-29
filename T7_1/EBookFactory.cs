namespace Homework_7
{
	public class EBookFactory
	{
		public Catalog CreateCatalog()
		{
			return new Catalog();
		}

		public PressReleaseItem CreatePressReleaseItems()
		{
			return new PressReleaseItem();
		}
	}
}
