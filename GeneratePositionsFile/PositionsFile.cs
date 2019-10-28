using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePositionsFile
{
    public class PositionsFile
    {
        public Header header { get; set; }
        public List<Position> positions {get;set;}
        public List<string> loadExceptions { get; set; }
        public PositionsFile()
        {
            positions = new List<Position>();
        }
    }
    public class Header
    {
        public int TransId { get; set; }
        public int FirmNumber { get; set; }
        public DateTime Date { get; set; }
    }
    public class Position
    {
        public int TransId { get; set; }
        public int FirmNumber { get; set; }
        public string Account { get; set; }
        public PositionType PositionType { get; set; }
        public string TradeSymbol { get; set; }
        public DateTime? Expiration { get; set; }
        public double? Strike { get; set; }
        public MarketPosition MarketPosition { get; set; }
        public SecurityType SecurityType { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public MMIndicator MMIndicator { get; set; }
        public string BasketId { get; set; }
        public string Filler { get; set; }

    }
    public enum PositionType
    {
        Put = 'P',
        Call = 'C',
        Underlyer = ' '
    }
    public enum MarketPosition
    {
        Long = 'L',
        Short = 'S'
    }
    public enum SecurityType
    {
        Stock = 'S',
        Future = 'F',
        FutureOption = 'I',
        OtherOption = 'O',
        CurrencyCash = 'X',
    }
    public enum MMIndicator
    {
        MarketMakter ='M',
        Firm = 'F'
    }
}
