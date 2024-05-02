namespace Homework_2_3
{
	public class Lecture : TrainingLesson
	{
		public string Topic { get; set; }
		public Lecture(string description, string topic) : base(description)
		{ 
			Topic = topic;
			Topic = topic;
		}
		public override TrainingLesson Clone()
		{
			return new Lecture(this.Description, this.Topic);
		}
		public override void Print()
		{
            Console.WriteLine($"{Description}, {Topic}");
        }
	}
}
