namespace FinanceApp.Server.Models
{
    public class TicketerDataToDb
    {
        public int TicketerId { get; set; }
        public DateTime Date { get; set; }
        public double Close { get; set; }
        public double Highest { get; set; }
        public double Lowest { get; set; }
        public double NumberOfTransactons { get; set; }
        public double Open { get; set; }
        public bool OTC { get; set; } = false;
        public int Timestamp { get; set; }
        public double Volume { get; set; }
        public double VolumeWeighted { get; set; }
        public virtual TicketerToDb Ticketer { get; set; }
    }
}
