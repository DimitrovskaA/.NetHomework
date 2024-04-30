namespace Homework_2_3
{
	public class Lecture
	{
		public string Description { get; set; }
		public string Topic { get; set; }
		public Lecture(string description, string topic) 
		{ 
			Description = description;
			Topic = topic;
		}
		public Lecture Clone()
		{
			return new Lecture(this.Description, this.Topic);
		}
	}
}
