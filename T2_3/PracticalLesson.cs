namespace Homework_2_3
{
	public class PracticalLesson
	{
		public string Description { get; set; }
		public string TaskLink { get; set; }
		public string SolutionLink { get; set; }

		public PracticalLesson(string description, string taskLink, string solutionLink)
		{
			Description = description;
			TaskLink = taskLink;
			SolutionLink = solutionLink;
		}
		public PracticalLesson Clone()
		{
			return new PracticalLesson(this.Description, this.TaskLink, this.SolutionLink);
		}
	}
}