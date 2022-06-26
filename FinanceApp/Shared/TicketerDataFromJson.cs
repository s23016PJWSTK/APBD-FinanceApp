namespace FinanceApp.Client.Models
{
    public class TicketerDataFromJson
    {
        public double c { get; set; }
        public double h { get; set; }
        public double l { get; set; }
        public double n { get; set; }
        public double o { get; set; }
        public bool otc { get; set; } = false;
        public long t { get; set; }
        public double v { get; set; }
        public double vw { get; set; }
    }
}