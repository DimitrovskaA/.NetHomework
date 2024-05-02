namespace Homework_2_3
{
	public class PracticalLesson : TrainingLesson
	{
		public string TaskLink { get; set; }
		public string SolutionLink { get; set; }

		public PracticalLesson(string description, string taskLink, string solutionLink) : base(description)
		{
			TaskLink = taskLink;
			SolutionLink = solutionLink;
		}
		public override TrainingLesson Clone()
		{
			return new PracticalLesson(this.Description, this.TaskLink, this.SolutionLink);
		}
		public override void Print()
		{
			Console.WriteLine($"{Description}, {TaskLink}, {SolutionLink}");
		}
	}
}