using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Shared
{
    public class Article
    {
		public Publisher publisher{ get; set; }
		public string title { get; set; }
		public DateTime published_utc { get; set; }
		public string article_url { get; set; }
	}
	public class Publisher
	{
		public string name { get; set; }
	}
}
