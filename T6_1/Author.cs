namespace Homewokr_6_1
{
	public class Author
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Author(string firstName, string lastName, DateTime dateOfBirth)
		{
			if(firstName.Length>200 || lastName.Length > 200)
			{
				throw new ArgumentException("The names couldn't be less than 200 symbols!");
			}
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
		}
	}
}
