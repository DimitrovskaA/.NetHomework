using Homework_2_3;
namespace TrainingTest
{
	[TestClass]
	public class TrainingTest
	{
		[TestMethod]
		public void IsPracticalTest1()
		{
			PracticalLesson practicalLesson1 = new PracticalLesson("", "", "");
			Lecture lecture1 = new Lecture("", "");

			Training training = new Training("", 2);

			training.Add(practicalLesson1 );
			training.Add(lecture1);

			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest2()
		{
			Lecture lecture1 = new Lecture("", "");
			Lecture lecture2 = new Lecture("", "");

			Training training = new Training("", 2);

			training.Add(lecture1);
			training.Add(lecture2);

			Assert.IsFalse(training.IsPractical());
		}
		[TestMethod]
		public void IsPracticalTest3()
		{
			PracticalLesson practicalLesson1 = new PracticalLesson("", "", "");
			PracticalLesson practicalLesson2 = new PracticalLesson("", "", "");

			Training training = new Training("", 2);

			training.Add(practicalLesson1);
			training.Add(practicalLesson2);

			Assert.IsTrue(training.IsPractical());
		}


	}
}