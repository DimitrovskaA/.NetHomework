namespace Homework_2_3
{
	public class Training : TrainingLesson
	{
		public string Description { get; set; }
		TrainingLesson[] trainingLessons;
		int trainingLessonsCount=0;
		public Training(string description, int numTrainingLessons) : base (description)
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
			foreach (TrainingLesson lesson in trainingLessons)
			{
				if (lesson is Lecture)
					return false;
			}
			return true;
		}

		public override TrainingLesson Clone()
		{
			Training clonedTraining = new Training(this.Description, this.trainingLessonsCount);

			for (int i = 0; i < this.trainingLessonsCount; i++)
			{
				clonedTraining.trainingLessons[i] = this.trainingLessons[i].Clone();

			}
			
			return clonedTraining;
		}
		public override void Print()
		{
			Console.WriteLine("Training Lessons: ");
			for (int i = 0; i < trainingLessons.Length; i++)
			{
				trainingLessons[i].Print();
			}
		}

	}
}
