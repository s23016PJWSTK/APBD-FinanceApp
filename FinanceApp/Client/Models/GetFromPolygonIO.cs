namespace FinanceApp.Client.Models
{
    public class GetFromPolygonIO
    {
        public string Code { get; set; }
        public bool Adjusted { get; set; }
        public int QueryCount { get; set; }
        public string RequestId { get; set; }
        public int ResultCount { get; set; }
        public string Status { get; set; }
        public List<TicketerData> TicketersData { get; set; }
    }
}
