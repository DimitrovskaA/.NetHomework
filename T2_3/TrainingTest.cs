using Homework_2_3;
namespace TrainingTest
{
	[TestClass]
	public class TrainingTest
	{
		[TestMethod]
		public void IsPracticalTest1()
		{
			var practicalLesson1 = new PracticalLesson("", "", "");
			var lecture1 = new Lecture("", "");

			Training training = new Training("", 2);

			training.Add(practicalLesson1 );
			training.Add(lecture1);

			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest2()
		{
			var lecture1 = new Lecture("", "");
			var lecture2 = new Lecture("", "");

			Training training = new Training("", 2);

			training.Add(lecture1);
			training.Add(lecture2);

			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest3()
		{
			var practicalLesson1 = new PracticalLesson("", "", "");
			var practicalLesson2 = new PracticalLesson("", "", "");

			Training training = new Training("", 2);

			training.Add(practicalLesson1);
			training.Add(practicalLesson2);

			Assert.IsTrue(training.IsPractical());
		}


	}
}