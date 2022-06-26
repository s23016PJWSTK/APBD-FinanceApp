namespace FinanceApp.Server.Models
{
    public class TicketerToDb
    {
        public int TicketerId { get; set; }
        public string Logo { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string Country { get; set; }
        public string CEO { get; set; }
        public virtual List<TicketerDataToDb> TicketerDatas { get; set; }
        public virtual List<WatchList_Ticketer> WatchList_Ticketers { get; set; }
    }
}
