namespace FinanceApp.Server.Models
{
    public class UserToDb
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<WatchList> WatchLists { get; set; }
    }
}
