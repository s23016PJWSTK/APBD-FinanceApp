namespace FinanceApp.Client.Models
{
    public class GetFromPolygonIO
    {
        public string ticker { get; set; }
        public bool adjusted { get; set; }
        public int queryCount { get; set; }
        public string request_id { get; set; }
        public int resultsCount { get; set; }
        public int count { get; set; }
        public string status { get; set; }
        public List<TicketerDataFromJson> results { get; set; }
    }
}
