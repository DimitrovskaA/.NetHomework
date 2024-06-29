namespace Homework_8
{
	public class PaperBookFactory
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
