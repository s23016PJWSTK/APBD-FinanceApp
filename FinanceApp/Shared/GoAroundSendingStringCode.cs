using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Shared
{
    public static class GoAroundSendingStringCode
    {
        public static List<KeyValuePair<int, string>> List { get; } = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string> (1, "LUMN"),
            new KeyValuePair<int, string> (2, "WMB"),
            new KeyValuePair<int, string> (3, "SUZ"),
            new KeyValuePair<int, string> (4, "INTU"),
            new KeyValuePair<int, string> (5, "TGNA"),
            new KeyValuePair<int, string> (6, "TMST"),
            new KeyValuePair<int, string> (7, "TSLA"),
            new KeyValuePair<int, string> (8, "TGA"),
            new KeyValuePair<int, string> (9, "MOGO"),
            new KeyValuePair<int, string> (10, "ESGRO")
        };
    }
}
