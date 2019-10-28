using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneratePositionsFile
{
    public class UpdatesFile
    {
        public List<Update> updates { get; set; }
        public string header { get; set; }
        public List<string> loadExceptions { get; set; }
    }
    public class Update
    {
        public static Regex shortTickerRegex = new Regex("^[A-Z]{3,4}");
        public int OFFICE { get; set; }
        public string TICKER { get; set; }
        public string REAL_CUSIP { get; set; }
        public string DESC_1 { get; set; }
        public int POSITION { get; set; }
        public double? MKT_PRICE { get; set; }
        public double MKT_VAL { get; set; }
        public DateTime POS_DT { get; set; }
        public string SEC_TYPE { get; set; }
        public double MKT_PRICE_NEW { get; set; }
        public string getShortTicker()
        {
            return shortTickerRegex.Match(TICKER).Value;
        }
        public PositionType getPositionType()
        {
            if (TICKER.Length <= 3)
                return PositionType.Underlyer;
            var extraTickerData = TICKER.Substring(4);
            if (extraTickerData.Contains("P"))
                return PositionType.Put;
            else if (extraTickerData.Contains("C"))
                return PositionType.Call;
            return PositionType.Underlyer;
        }
    }
}
