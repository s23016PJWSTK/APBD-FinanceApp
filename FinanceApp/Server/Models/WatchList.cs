namespace FinanceApp.Server.Models
{
    public class WatchList
    {
        public int WatchListId { get; set; }
        public string UserEmail { get; set; }
        public virtual UserToDb User { get; set; }
        public virtual List<WatchList_Ticketer> WatchList_Ticketers { get; set; }
    }
}
