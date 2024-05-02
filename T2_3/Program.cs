namespace Homework_2_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PracticalLesson practicalLesson1 = new PracticalLesson("Description for Practical Lesson1", "TaskLink1", "SolutionLink1");
			PracticalLesson practicalLesson2 = new PracticalLesson("Description for Practical Lesson2", "TaskLink2", "SolutionLink2");
			Lecture lecture1 = new Lecture("Description for Lecture1", "Topic1");
			Lecture lecture2 = new Lecture("Description for Lecture2", "Topic2");

			Training training = new Training("Training Description", 4);

			training.Add(lecture1);
			training.Add(lecture2);
			training.Add(practicalLesson1);
			training.Add(practicalLesson2);
			
            Console.WriteLine("ORIGINAL\n");
            training.Print();

            Console.WriteLine("\nCLONED\n");
            TrainingLesson clonedTraining = training.Clone();
			clonedTraining.Print();

			bool isPractical = training.IsPractical();
			Console.WriteLine($"\nIs the training practical? {isPractical}");
		}
	}
}