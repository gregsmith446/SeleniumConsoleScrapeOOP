using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace seleniumConsoleOOP
{
    class Database
    {
        private const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = SeleniumDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void InsertStockHistory(Stock stock)
        {
            InsertIntoScrapeHistory(stock);
        }

        public static void InsertCurrentStock(Stock stock)
        {
            InsertIntoLatestScrape(stock);
        }

        public static void Clear_Reset()
        {
            DeleteTableData();
            ResetAutoIncrementer();
        }

        public static void InsertIntoLatestScrape(Stock stock)
        {
            string latestScrape = @"IF EXISTS(SELECT* FROM Stocks WHERE Symbol = @Symbol)
                                        UPDATE Stocks
                                        SET LastPrice = @LastPrice, ChangePercent = @ChangePercent,
                                            Volume = @Volume, AvgVol = @AvgVol, MarketCap = @MarketCap 
                                        WHERE Symbol = @Symbol 
                                    ELSE
                                        INSERT INTO Stocks VALUES(@Symbol, @LastPrice, @ChangePercent, @Volume, @AvgVol, @MarketCap);";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand command = new SqlCommand(latestScrape, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("@LastPrice", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("@ChangePercent", stock.ChangePercent));
                        command.Parameters.Add(new SqlParameter("@Volume", stock.Volume));
                        command.Parameters.Add(new SqlParameter("@AvgVol", stock.AvgVol));
                        command.Parameters.Add(new SqlParameter("@MarketCap", stock.MarketCap));

                        command.ExecuteNonQuery();
                        Console.WriteLine("{0} added to Stocks table...", stock.Symbol);
                    }
                }
            }
        }

        private static void InsertIntoScrapeHistory(Stock stock)
        {
            string scrapeHistory = "INSERT INTO StockHistory VALUES (@Symbol, @LastPrice, @ChangePercent, @Volume, @AvgVol, @MarketCap);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand command = new SqlCommand(scrapeHistory, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("@LastPrice", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("@ChangePercent", stock.ChangePercent));
                        command.Parameters.Add(new SqlParameter("@Volume", stock.Volume));
                        command.Parameters.Add(new SqlParameter("@AvgVol", stock.AvgVol));
                        command.Parameters.Add(new SqlParameter("@MarketCap", stock.MarketCap));

                        command.ExecuteNonQuery();
                        Console.WriteLine("{0} added to StockHistory table...", stock.Symbol);
                    }
                }
                else
                {
                    Console.WriteLine("No connection...");
                }
                connection.Close();
            }
        }


        public static void DeleteTableData()
        {
            string deleteTableData = "DELETE FROM StockHistory;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(deleteTableData, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public static void ResetAutoIncrementer()
        {
            string reseed = "DBCC CHECKIDENT ('StockHistory', RESEED, 0);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(reseed, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }
    }
}
