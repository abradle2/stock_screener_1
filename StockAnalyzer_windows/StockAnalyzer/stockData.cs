using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;



namespace StockAnalyzer
{
    class stockData
    {

        DateTime today = DateTime.Today;
        DateTime beginningDate = DateTime.Now.AddYears(-5);
        DataTable companyInfo = new DataTable(); 
        public DataTable getData(string symbol)
        {
            DataTable stockdata = new DataTable();
                       
            
            //Download csv file for last 5 years, up to last month and save it
            System.Net.WebClient csvDownloader = new System.Net.WebClient();
            string stockUrl = "http://ichart.finance.yahoo.com/table.csv?s="+
                symbol+
                "&a="+
                beginningDate.ToString("MM")+
                "&b="+
                beginningDate.ToString("dd")+
                "&c="+
                beginningDate.ToString("yyyy")+
                "&d="+
                today.ToString("MM")+
                "&e="+
                today.ToString("dd")+
                "&f="+
                today.ToString("yyyy")+
                "&g=d&ignore=.csv";
           
            //Download 5 years worth of EOD data
            try
            {
                csvDownloader.DownloadFile(stockUrl, "./" + symbol + ".csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception Caught.", e);
            }
            
            //DataTable stockData = new DataTable("prices");
            stockdata.Columns.Add("date");
            stockdata.Columns.Add("open");
            stockdata.Columns.Add("high");
            stockdata.Columns.Add("low");
            stockdata.Columns.Add("close");
            stockdata.Columns.Add("volume");
            stockdata.Columns.Add("adjVolume");

            stockdata.Rows.Clear();
            using (StreamReader csvReader = new StreamReader("./" + symbol + ".csv"))
            {
                    string line;
                    string[] vals;
                    while ((line = csvReader.ReadLine()) != null)
                    {
                        vals = line.Split(',');
                        stockdata.Rows.Add(vals);
                    }
            }
            
            
            stockdata.Rows[0].Delete();
            
            //stockdata.DefaultView.Sort = "date" + " " + "ASC";
            //stockdata = stockdata.DefaultView.ToTable();


            //Open database connection
            string connectionStringLaptop = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\crommie\Dropbox\stock_analyzer\StockAnalyzer_windows\StockAnalyzer\prices.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaron\documents\visual studio 2012\Projects\StockAnalyzer\StockAnalyzer\prices.mdf;Integrated Security=True";
            SqlConnection db2Connection = new SqlConnection(connectionStringLaptop);
            db2Connection.Open();

            using (SqlCommand cmd = db2Connection.CreateCommand())
            {
                cmd.CommandText =
                    @"
                       IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + symbol + @"')
                        BEGIN
                        DROP TABLE " + symbol + @";
                       IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + symbol + @"')
                        CREATE TABLE " + symbol + @" (
                          ID     integer PRIMARY KEY NOT NULL IDENTITY,
                          datetime     varchar(20), 
                          openVal     varchar(10),
                          closeVal     varchar(10),
                          highVal     varchar(10),
                          lowVal     varchar(10),
                          volume     varchar(20)
                            ); END";
                MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //try { cmd.ExecuteNonQuery(); }
                //catch (SqlException) { MessageBox.Show("SQL Exception creating table for company info"); }
            }

            //Delete contents of table - may want to rethink this step??
            SqlCommand delCmd = new SqlCommand(@"DELETE FROM " + symbol + ";", db2Connection);
            delCmd.ExecuteNonQuery();

            using (SqlBulkCopy copy = new SqlBulkCopy(connectionStringLaptop))
            {
                copy.ColumnMappings.Add("date", "datetime");
                copy.ColumnMappings.Add("open", "openVal");
                copy.ColumnMappings.Add("close", "closeVal");
                copy.ColumnMappings.Add("high", "highVal");
                copy.ColumnMappings.Add("low", "lowVal");
                copy.ColumnMappings.Add("volume", "volume");

                copy.DestinationTableName = symbol;
                copy.WriteToServer(stockdata);
                
            }



            //Download Company information

            companyInfo.Columns.Add("symbol");
            companyInfo.Columns.Add("openVal");
            companyInfo.Columns.Add("ask");
            companyInfo.Columns.Add("bid");
            companyInfo.Columns.Add("avgDailyVol");
            companyInfo.Columns.Add("change");
            companyInfo.Columns.Add("eps");
            companyInfo.Columns.Add("epsEst");
            companyInfo.Columns.Add("dailyLow");
            companyInfo.Columns.Add("dailyHigh");
            companyInfo.Columns.Add("fiftytwoWeekLow");
            companyInfo.Columns.Add("fiftytwoWeekHigh");
            companyInfo.Columns.Add("mktCap");
            companyInfo.Columns.Add("ps");
            companyInfo.Columns.Add("pb");
            companyInfo.Columns.Add("pe");
            companyInfo.Columns.Add("targetOneYear");
            companyInfo.Columns.Add("exchange");
            companyInfo.Columns.Add("price");
            companyInfo.Columns.Add("tradeTime");
            companyInfo.Columns.Add("tradeDate");
            companyInfo.Columns.Add("prevClose");
            companyInfo.Columns.Add("div");
            companyInfo.Columns.Add("divYield");
            companyInfo.Columns.Add("name");

            //Download csv file with company info and save it
            System.Net.WebClient csvInfoDownloader = new System.Net.WebClient();
            string companyUrl = @"http://finance.yahoo.com/d/quotes.csv?s=" +
                symbol +
                @"&f=sob2b3a2c6ee8ghjkj1p5p6rt8xk1t1d1pdy";
            try
            {
                csvInfoDownloader.DownloadFile(companyUrl, "./" + symbol + "Info" + ".csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception Caught.", e);
            }


            companyInfo.Rows.Clear();

            using (StreamReader csvCompanyReader = new StreamReader("./" + symbol + "Info" + ".csv"))
            {
                string line;
                string[] vals;
                while ((line = csvCompanyReader.ReadLine()) != null)
                {
                    vals = line.Split(',');
                    try
                    {
                        companyInfo.Rows.Add(vals);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }

            //Download company name and save it
            System.Net.WebClient csvNameDownloader = new System.Net.WebClient();
            string nameUrl = @"http://finance.yahoo.com/d/quotes.csv?s=" +
                symbol +
                @"&f=n";
            try
            {
                csvNameDownloader.DownloadFile(nameUrl, "./" + symbol + "Name" + ".csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception Caught.", e);
            }
            
            using (StreamReader csvNameReader = new StreamReader("./" + symbol + "Name" + ".csv"))
            {
                string line;
                while ((line = csvNameReader.ReadLine()) != null)
                {
                    companyInfo.Rows[0]["name"] = line.Split('"', '"')[1];
                    
                }
            }

            //Rename Symbol in Table to not have quotes
            companyInfo.Rows[0]["symbol"] = companyInfo.Rows[0]["symbol"].ToString().Split('"', '"')[1];
            
            using (SqlCommand cmd2 = db2Connection.CreateCommand())
            {
                cmd2.CommandText =
                    @" 
                       IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'companyData')
                        BEGIN
                        CREATE TABLE companyData (
                          ID     integer PRIMARY KEY NOT NULL IDENTITY,
                          symbol     varchar(10),
                          openVal     varchar(20),
                          ask     varchar(20),
                          bid     varchar(20),
                          avgDailyVol     varchar(20),
                          change     varchar(20),
                          eps     varchar(20),
                          epsEst     varchar(20),
                          dailyLow     varchar(20),
                          dailyHigh     varchar(20),
                          fiftytwoWeekLow     varchar(20),
                          fiftytwoWeekHigh     varchar(20),
                          mktCap     varchar(20),
                          ps     varchar(20),
                          pb     varchar(20),
                          pe     varchar(20),
                          targetOneYear     varchar(20),
                          exchange     varchar(20),
                          price     varchar(30),
                          tradeTime     varchar(20),
                          tradeDate     varchar(20),
                          prevClose     varchar(20), 
                          div     varchar(20),
                          divYield     varchar(20),
                          name     varchar(30),
                          ); END";

                cmd2.ExecuteNonQuery();
            }
            

            //Delete contents of table - may want to rethink this step??
            MessageBox.Show("About to delete company data");            
            SqlCommand delCompanyCmd = new SqlCommand(@"DELETE FROM companyData where symbol = '" + symbol + "';", db2Connection);
            delCompanyCmd.ExecuteNonQuery();
            MessageBox.Show("Just deleted company data");            
            using (SqlBulkCopy copyCompany = new SqlBulkCopy(connectionStringLaptop))
            {
                copyCompany.ColumnMappings.Add("symbol", "symbol");
                copyCompany.ColumnMappings.Add("openVal", "openVal");
                copyCompany.ColumnMappings.Add("ask", "ask");
                copyCompany.ColumnMappings.Add("bid", "bid");
                copyCompany.ColumnMappings.Add("avgDailyVol", "avgDailyVol");
                copyCompany.ColumnMappings.Add("change", "change");
                copyCompany.ColumnMappings.Add("eps", "eps");
                copyCompany.ColumnMappings.Add("epsEst", "epsEst");
                copyCompany.ColumnMappings.Add("dailyLow", "dailyLow");
                copyCompany.ColumnMappings.Add("dailyHigh", "dailyHigh");
                copyCompany.ColumnMappings.Add("fiftytwoWeekLow", "fiftytwoWeekLow");
                copyCompany.ColumnMappings.Add("fiftytwoWeekHigh", "fiftytwoWeekHigh");
                copyCompany.ColumnMappings.Add("mktCap", "mktCap");
                copyCompany.ColumnMappings.Add("ps", "ps");
                copyCompany.ColumnMappings.Add("pb", "pb");
                copyCompany.ColumnMappings.Add("pe", "pe");
                copyCompany.ColumnMappings.Add("targetOneYear", "targetOneYear");
                copyCompany.ColumnMappings.Add("exchange", "exchange");
                copyCompany.ColumnMappings.Add("price", "price");
                copyCompany.ColumnMappings.Add("tradeTime", "tradeTime");
                copyCompany.ColumnMappings.Add("tradeDate", "tradeDate");
                copyCompany.ColumnMappings.Add("prevClose", "prevClose");
                copyCompany.ColumnMappings.Add("div", "div");
                copyCompany.ColumnMappings.Add("divYield", "divYield");
                copyCompany.ColumnMappings.Add("name", "name");
                
                copyCompany.DestinationTableName = "companyData";
                copyCompany.WriteToServer(companyInfo);
            }
            
            db2Connection.Close();
            return companyInfo;

        }

    }
}
