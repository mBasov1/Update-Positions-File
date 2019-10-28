using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePositionsFile
{
    public class PositionsFileGenerator
    {
        public static PositionsFile UpdatePositionsFile(PositionsFile originalFile, UpdatesFile updatesFile)
        {
            var updatedFile = originalFile.Clone();
            updatedFile.loadExceptions = new List<string>();
            updatedFile.header.Date = DateTime.Today;

            var updatedOptions = updatesFile.updates.Where(u => u.SEC_TYPE == "Option").ToList();

            foreach (var update in updatedOptions)
            {
                try
                {
                    var matchingPositions = updatedFile.positions.Where(p => p.TradeSymbol.Trim() == update.getShortTicker() && p.PositionType == update.getPositionType() && p.Price == update.MKT_PRICE).ToList();

                    if (matchingPositions.Count > 0)
                    {
                        foreach(var matchingPosition in matchingPositions)
                        {
                            matchingPosition.Price = update.MKT_PRICE_NEW;
                        }
                    }
                    else
                    {
                        throw new Exception("Couldn't find corresponing position for Ticker: " + update.TICKER);
                    }
                }
                catch(Exception e)
                {
                    updatedFile.loadExceptions.Add(e.Message);
                }
            }
            return updatedFile;
        }

        public static string GeneratePositionsFile(PositionsFile updatedFile)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(updatedFile.header.TransId);
            stringBuilder.Append("H");
            stringBuilder.Append(updatedFile.header.FirmNumber.ToString("D4"));
            stringBuilder.Append(updatedFile.header.Date.ToString("yyyyMMdd"));
            stringBuilder.Append("\n");

            foreach(var position in updatedFile.positions)
            {
                stringBuilder.Append(position.TransId);
                stringBuilder.Append(" ");
                stringBuilder.Append(position.FirmNumber.ToString("D4"));
                stringBuilder.Append(position.Account);
                stringBuilder.Append((char)position.PositionType);
                stringBuilder.Append(position.TradeSymbol);
                stringBuilder.Append(getDate(position.Expiration));
                stringBuilder.Append(getStrike(position.Strike));
                stringBuilder.Append((char)position.MarketPosition);
                stringBuilder.Append((char)position.SecurityType);
                stringBuilder.Append(getPrice(position.Price));
                stringBuilder.Append(position.Quantity.ToString("D9"));
                stringBuilder.Append((char)position.MMIndicator);
                stringBuilder.Append(position.BasketId);
                stringBuilder.Append(position.Filler);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
        private static string getDate(DateTime? expiration)
        {
            if (expiration == null)
                return "00000000";
            return expiration?.ToString("yyyyMMdd");
        }
        private static string getPrice(double price)
        {
            var priceString = price.ToString();
            if (priceString.Contains("."))
            {
                var wholeNumbers = priceString.Split('.')[0].PadLeft(6, '0');
                var fractions = priceString.Split('.')[1].PadRight(6, '0');
                return wholeNumbers + fractions;
            }
            else
            {
                return priceString.PadLeft(12, '0');
            }
        }
        private static string getStrike(double? strike)
        {
            if (strike == null)
                return "000000000";
            var strikeDollar = ((int)Math.Truncate((decimal)strike)).ToString("D5");
            var strikeFraction = Math.Truncate((((decimal)strike - (Math.Truncate((decimal)strike)))*10000)).ToString();
            return strikeDollar+ strikeFraction;
        }
    }
}
