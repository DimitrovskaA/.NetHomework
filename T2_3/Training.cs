namespace Homework_2_3
{
	public class Training 
	{
		TrainingLesson[] trainingLessons;
		int trainingLessonsCount = 0;
		public string Description { get; set; }

		public Training(string description, int numTrainingLessons) 
		{
			Description = description;
			trainingLessons = new TrainingLesson[numTrainingLessons];
		}
		public TrainingLesson[] GetLessons()
		{
			return trainingLessons;
		}
		public void Add(TrainingLesson lectureAndLesson)
		{
			if (trainingLessonsCount < trainingLessons.Length)
			{
				trainingLessons[trainingLessonsCount] = lectureAndLesson;
				trainingLessonsCount++;
			}
		}

		public bool IsPractical()
		{
			foreach (var lesson in trainingLessons)
			{
				if (lesson is Lecture)
					return false;
			}
			return true;
		}

		public Training Clone()
		{
			Training clonedTraining = new Training(this.Description, this.trainingLessonsCount);

			for (int i = 0; i < this.trainingLessonsCount; i++)
			{
				clonedTraining.Add(this.trainingLessons[i].Clone());
			}
			
			return clonedTraining;
		}
		public void Print()
		{
			Console.WriteLine("Training Lessons: ");
			for (int i = 0; i < trainingLessonsCount; i++)
			{
				trainingLessons[i].Print();
			}
		}
	}
}
