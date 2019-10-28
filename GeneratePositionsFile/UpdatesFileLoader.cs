using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace GeneratePositionsFile
{
    public class UpdatesFileLoader
    {
        public static UpdatesFile GenerateUpdatesFile(string filePath)
        {
            var updatesFile = new UpdatesFile();
            updatesFile.updates = new List<Update>();
            updatesFile.loadExceptions = new List<string>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var workbook = result.Tables[0];
                    var i = 0;
                    foreach(DataRow row in workbook.Rows)
                    {
                        i++;
                        try
                        {
                            var cells = row.ItemArray.Select(c => c.ToString()).Take(10).ToList();
                            if (!String.IsNullOrEmpty(cells[0]) && cells[0] != "OFFICE" && !String.IsNullOrEmpty(cells[9]))
                            {
                                var update = new Update();
                                update.OFFICE = parseInt(cells[0], "OFFICE");
                                update.TICKER = parseNotNullString(cells[1], "TICKER");
                                update.REAL_CUSIP = cells[2].Trim();
                                update.DESC_1 = cells[3].Trim();
                                update.POSITION = parseInt(cells[4], "POSITION");
                                update.MKT_PRICE = parseDouble(cells[5], "NMKT_PRICE",true);
                                update.MKT_VAL = (double)parseDouble(cells[6], "MKT_VAL",false);
                                update.POS_DT = parseDate(cells[7], "POS_DT");
                                update.SEC_TYPE = cells[8].Trim();
                                update.MKT_PRICE_NEW = (double)parseDouble(cells[9], "NMKT_PRICE(2)", false);
                                updatesFile.updates.Add(update);
                            }
                        }
                        catch (Exception e)
                        {
                            updatesFile.loadExceptions.Add(String.Format("Error on row {0} : {1}",i, e.Message));
                        }
                    }
                }
            }

            return updatesFile;
            }

        private static string parseNotNullString(string text, string column)
        {
            if (!String.IsNullOrWhiteSpace(text))
                return text.Trim();
            throw new Exception("Could not parse " + column + ". This value cannot be null.");
        }
        private static int parseInt(string text, string column)
        {
            int returnValue;
            var modifiedText = text.Replace("(","").Replace(",", "").Replace(")", "").Trim();
            if (int.TryParse(modifiedText, out returnValue))
            {
                return returnValue;
            }
            else
            {
                throw new Exception("Could not parse "+ column + ". This should be an integer.");
            }
        }
        private static double? parseDouble (string text, string column,bool nullable)
        {
            double returnValue;
            var modifiedText = text.Replace("(", "").Replace(",", "").Replace(")", "").Trim();
            if (modifiedText == "-" && nullable)
                return null;

            if (double.TryParse(modifiedText, out returnValue))
            {
                return returnValue;
            }
            else
            {
                throw new Exception("Could not parse " + column + ". This should be a decimal value.");
            }
        }
        private static DateTime parseDate(string text, string column)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                throw new Exception("Could not parse " + column + ". This should be in MM/DD/YYYY format.'");
            }
        }
    }
}
