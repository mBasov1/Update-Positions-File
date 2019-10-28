using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratePositionsFile
{
    public class PositionsFileLoader
    {
        public static PositionsFile LoadPositions(string filePath)
        {
            var text = System.IO.File.ReadAllText(filePath);
            var lines = text.Split(new char[] { '\n' }).ToList();
            if (lines.Count() > 1)
            {
                var positionsFile = new PositionsFile();
                positionsFile.header = ParsePositionsHeader(lines[0]);
                var parsedFile= ParsePositions(lines.Skip(1).ToList());
                positionsFile.positions = parsedFile.Item1;
                positionsFile.loadExceptions = parsedFile.Item2;
                return positionsFile;
            }
            else
            {
                throw new Exception("File is empty. Positions file requires a header and at least one row.");
            }
        }
        public static Header ParsePositionsHeader(string headerText)
        {
            var header = new Header();
            headerText = headerText.Trim();
            if (headerText.Length == 16)
            {
                header.TransId = parseTransId(headerText, "header");
                parseRecordId(headerText, true, "header");
                header.FirmNumber = parseFirmId(headerText, "header");
                header.Date = parseDate(headerText, "header");
            }
            else
            {
                throw new Exception("Header is incorrect. Headers are 16 characters. Please refer to documentation.");
            }
            return header;
        }
        public static Tuple<List<Position>,List<string>> ParsePositions(List<string> lines)
        {
            var positions = new List<Position>();
            var exceptions = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                try
                {
                    var rowString = String.Format("row {0}", (i + 1));
                    var line = lines[i];
                    if (String.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Length >= 71)
                    {

                        var position = new Position();
                        position.TransId = parseTransId(line, rowString);
                        parseRecordId(line, false, rowString);
                        position.FirmNumber = parseFirmId(line, rowString);
                        position.Account = line.Substring(8, 10);
                        position.PositionType = parsePositionType(line, rowString);
                        position.TradeSymbol = line.Substring(19, 6);
                        position.Expiration = parseExpirationDate(line, rowString);
                        position.Strike = parseStrike(line, rowString);
                        position.MarketPosition = parseMarketPosition(line, rowString);
                        position.SecurityType = parseSecurityType(line, rowString);
                        position.Price = parsePrice(line, rowString);
                        position.Quantity = parseQuantity(line, rowString);
                        position.MMIndicator = parseMMIndicator(line, rowString);
                        position.BasketId = line.Substring(66, 5);
                        position.Filler = line.Substring(71).Trim();
                        positions.Add(position);
                    }
                    else
                    {
                        exceptions.Add(String.Format("Error on {0}. Lines must be at least 71 chracters long.", rowString));
                    }
                }
                catch (Exception e)
                {
                    exceptions.Add(e.Message);
                }
            }
            return new Tuple<List<Position>,List<string>> (positions, exceptions);
        }
        private static double? parseStrike(string text, string row)
        {
            if (text.Substring(33, 9).TrimStart('0') == "")
            {
                return null;
            }
            else
            {
                double strikeValue;
                var dollarString = text.Substring(33, 5).TrimStart('0');
                var fractionString = text.Substring(38, 4).TrimStart('0');
                var strikeString = String.Format("{0}.{1}", dollarString, fractionString);
                if (Double.TryParse(strikeString, out strikeValue))
                {
                    return strikeValue;
                }
                else
                {
                    throw new Exception("Could not parse Strike Value in " + row + ".");
                }
            }
        }
        private static DateTime? parseExpirationDate(string text, string row)
        {
            var dateString = text.Substring(25, 8);
            if (dateString.TrimStart('0') == "")
            {
                return null;
            }
            else
            {
                DateTime date;
                if (DateTime.TryParseExact(dateString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    throw new Exception("Could not parse Date in " + row + ". This should be in YYYYMMDD format.'");
                }
            }
        }
        private static MMIndicator parseMMIndicator(string text, string row)
        {
            try
            {
                return (MMIndicator)text.Substring(65, 1).ToCharArray()[0];
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse MM Indicator in " + row + ". M for market maker, F for firm");
            }
        }
        private static SecurityType parseSecurityType(string text, string row)
        {
            try
            {
                return (SecurityType)text.Substring(43, 1).ToCharArray()[0];
            }
            catch (Exception)
            {
                throw new Exception("Could not parse SecurityType in " + row + ". S for Stock, F for future, I for option on future, O for other options and X for currency cash Underlyer.");
            }
        }
        private static int parseQuantity(string text, string row)
        {
            try
            {
                return int.Parse(text.Substring(56, 9));
            }
            catch(Exception e)
            {
                throw new Exception("Could not parse Quantity in " + row + ". This is an integer with leading zeroes.");
            }
        }
            private static double parsePrice(string text, string row)
        {
            try
            {
                var priceString = text.Substring(44, 12);
                priceString= priceString.Insert(6, ".");
                return Double.Parse(priceString);
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse Price in " + row + ".");
            }
        }
        private static MarketPosition parseMarketPosition(string text, string row)
        {
            try
            {
                return (MarketPosition)text.Substring(42, 1).ToCharArray()[0];
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse Put/Call in " + row + ". L = Long position, S = Short");
            }
        }
        private static PositionType parsePositionType(string text, string row)
        {
            try
            {
                return (PositionType)text.Substring(18, 1).ToCharArray()[0];
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse Put/Call in " + row + ". P=Put, C=Call, blank=underlyer");
            }
        }
        private static int parseTransId(string text, string row)
        {
            int transId;
            if (int.TryParse(text.Substring(0, 3), out transId))
            {
                if (transId != 346)
                {
                    throw new Exception("TransID is not correct in " + row + ". It should always be set to '346'");
                }
                return transId;
            }
            else
            {
                throw new Exception("Could not parse TransID in " + row + ". This should always be set to '346'");
            }
        }
        private static void parseRecordId(string text, bool isHeader, string row)
        {
            var recordId = text.Substring(3, 1);
            if ((recordId.ToUpper() == "H") && isHeader || (recordId == " " && !isHeader))
                return;
            throw new Exception("Could not parse RecordId in " + row + ". This should be 'H' for the header or blank otherwise.");
        }
        private static int parseFirmId(string text, string row)
        {
            int FirmId;
            if (int.TryParse(text.Substring(4, 4), out FirmId))
            {
                return FirmId;
            }
            else
            {
                throw new Exception("Could not parse FirmId in " + row + ". This is an interger with leading zeroes.'");
            }
        }
        private static DateTime parseDate(string text, string row)
        {
            DateTime date;
            if (DateTime.TryParseExact(text.Substring(8, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                throw new Exception("Could not parse Date in " + row + ". This should be in YYYYMMDD format.'");
            }
        }
    }
}
