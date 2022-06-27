namespace FinanceApp.Server.Models
{
    public class ArticleToDb
    {
        public int TicketerId { get; set; }
		public string name { get; set; }
		public string title { get; set; }
		public DateTime published_utc { get; set; }
		public string article_url { get; set; }
		public virtual TicketerToDb Ticketer { get; set; }
	}
}
