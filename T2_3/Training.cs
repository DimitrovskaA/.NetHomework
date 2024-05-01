namespace Homework_2_3
{
	public class Training
	{
		public string Description { get; set; }
		PracticalLesson[] practicalLessons;
		Lecture[] lectures;
		int practicalLessonsCount = 0;
		int lecturesCount = 0;
		public Training(string description, int numPracticalLessons, int numLectures) 
		{
			Description = description;
			practicalLessons = new PracticalLesson[numPracticalLessons];
			lectures = new Lecture[numLectures];
			//practicalLessonsCount = 0;
			//lecturesCount = 0;
		}
		public void Add(Lecture lecture)
		{
			if (lecturesCount<lectures.Length)
			{
				lectures[lecturesCount] = lecture;
				lecturesCount++;
			}
		}
		public void Add(PracticalLesson practicalLesson)
		{
			if (practicalLessonsCount < practicalLessons.Length)
			{
				practicalLessons[practicalLessonsCount] = practicalLesson;
				practicalLessonsCount++;
			}
		}

	
		public bool IsPractical()
		{ 
			return lectures.Length==0 && practicalLessons.Length > 0;
		}

		public Training Clone()
		{
			Training clonedTraining = new Training(this.Description, this.practicalLessons.Length, this.lectures.Length);

			for (int i = 0; i < this.lecturesCount; i++)
			{
				clonedTraining.lectures[i] = this.lectures[i].Clone();

			}
			for (int i = 0; i < this.practicalLessonsCount; i++)
			{
				clonedTraining.practicalLessons[i] = this.practicalLessons[i].Clone();
			}

			return clonedTraining;
		}
		public void Print()
		{
			Console.WriteLine("Lectures: ");
			for (int i = 0; i < lectures.Length; i++)
			{
				Console.WriteLine($"{lectures[i].Description}, {lectures[i].Topic}");
			}
			Console.WriteLine("Practical Lessons: ");
			for (int i = 0; i < practicalLessons.Length; i++)
			{
				Console.WriteLine($"{practicalLessons[i].Description}, {practicalLessons[i].SolutionLink}, {practicalLessons[i].TaskLink}");
			}
		}

	}
}
