using FinanceApp.Shared;

namespace FinanceApp.Client.Models
{
    public class GetFromPolygonIONews
    {
        public int count { get; set; }
        public string status { get; set; }
        public List<Article> results { get; set; }
    }
}
