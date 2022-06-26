namespace FinanceApp.Server.Models
{
    public class WatchList_Ticketer
    {
        public int TicketerId { get; set; }
        public int WatchListId { get; set; }
        public virtual TicketerToDb Ticketer { get; set; }
        public virtual WatchList WatchList { get; set; }
    }
}
