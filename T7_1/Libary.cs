namespace Homework_7
{
	public class Libary
	{
		public Catalog Catalog { get; set; }
		public PressReleaseItem PressReleaseItems { get; set; }

		public Libary(Catalog catalog, PressReleaseItem pressReleaseItems)
		{
			Catalog = catalog;
			PressReleaseItems = pressReleaseItems;
		}
	}
}
