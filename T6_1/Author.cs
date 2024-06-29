namespace Homewokr_6_1
{ 
	public class Author
	{
		const int LENGHT_AGE = 200;
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public Author(string firstName, string lastName, DateTime? dateOfBirth)
		{
			if(firstName.Length> LENGHT_AGE || lastName.Length > LENGHT_AGE)
			{
				throw new ArgumentException("The names must be less than 200 characters!");
			}
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
		}
	}
}
