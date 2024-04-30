using Homework_2_3;
namespace TrainingTest
{
	[TestClass]
	public class TrainingTest
	{
		[TestMethod]
		public void IsPracticalTest1()
		{
			Training training = new Training("Training Description", 7, 2);
			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest2()
		{
			Training training = new Training("Training Description", 0, 10);
			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest3()
		{
			Training training2 = new Training("Training Description", 10, 0);
			Assert.IsTrue(training2.IsPractical());
		}
	}
}