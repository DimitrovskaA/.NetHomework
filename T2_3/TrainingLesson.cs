namespace Homework_2_3
{
	public abstract class TrainingLesson
	{
		public string Description { get; set; }
		public TrainingLesson(string description) 
		{
			Description=description;
		}
		public abstract TrainingLesson Clone();
		public abstract void Print();
	}
}
