namespace FinanceApp.Server.Models
{
	public class User
	{
		public string Email { get; }
		public User(string email)
		{
			Email = email;
		}
	}
}
