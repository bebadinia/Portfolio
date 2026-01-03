// CompleteUpdater.cs by Ben Ebadinia

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Linq;

namespace WhatsItWorth
{
    class completeUpdater
    {
        // Shared SQLite connection used to read/update metal prices.
        public SQLiteConnection DBConnection;


        public void checkDateFunction()
        {
            try
            {
                // Read last update date and metal type for all entries.
                SQLiteCommand cmdGetDate = DBConnection.CreateCommand();

                cmdGetDate.CommandText = @"SELECT Data_Updated, Metal_Type
                                           FROM MetalPrice";

                SQLiteDataReader rdr = cmdGetDate.ExecuteReader();

                // Track metal types that require an update.
                var metalUpdateInts = new List<int>();

                while (rdr.Read())
                {
                    DateTime dt = DateTime.Parse(rdr[0].ToString());

                    if (DateTime.UtcNow.Date != dt.Date)
                    {
#if DEBUG
                        Console.WriteLine("Update: " + rdr[1].ToString());
#endif
                        metalUpdateInts.Add(Convert.ToInt32(rdr[1]));
                    }
                    else
                    {
#if DEBUG
                        Console.WriteLine("Do Nothing: " + rdr[1].ToString());
#endif
                    }
                }

                rdr.Close();

                if (metalUpdateInts.Count > 0)
                {
                    updateDateFunction(metalUpdateInts);
                }
                else
                {
#if DEBUG
                    Console.WriteLine("Everything Remains Same");
#endif
                }

                metalUpdateInts.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateDateFunction(List<int> metalType)
        {
            foreach (int metalTypeInt in metalType)
            {

                try
                {
                    // Update the stored date to today and then refresh price for that metal.
                    SQLiteCommand cmdUpdateDate = DBConnection.CreateCommand();
                    cmdUpdateDate.CommandText = @"UPDATE MetalPrice
                                                  SET Data_Updated = @NewDate
                                                  WHERE Metal_Type = @mt";
                    cmdUpdateDate.Parameters.AddWithValue("@NewDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
                    cmdUpdateDate.Parameters.AddWithValue("@mt", Convert.ToInt32(metalTypeInt));

                    cmdUpdateDate.ExecuteNonQuery();

                    if (metalTypeInt == 1)
                    {
                        updateGoldPrice();
                    }
                    else if (metalTypeInt == 2)
                    {
                        updateSilverPrice();
                    }
                    else if (metalTypeInt == 3)
                    {
                        updatePlatinumPrice();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void updateGoldPrice()
        {
            try
            {
                // Initialize the HtmlAgilityPack client.
                var web = new HtmlWeb();

                // Load the target page and scrape current price and metal name.
                var kitcoPath = web.Load("https://www.kitco.com/price/precious-metals");
                var goldName = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[2]/div/ul/li[1]/div/span[1]/a").First().InnerText;
                var goldPrice = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[3]/div/div[3]/ul/li[1]/div/span[4]").First().InnerText;
                SQLiteCommand cmdUpdateGold = DBConnection.CreateCommand();
                cmdUpdateGold.CommandText = @"UPDATE MetalPrice
                                              SET Price_per_Ounce = @NewPrice
                                                  WHERE Metal_Type = 1";
                cmdUpdateGold.Parameters.AddWithValue("@NewPrice", Double.Parse(goldPrice));
                cmdUpdateGold.ExecuteNonQuery();

#if DEBUG
                Console.WriteLine("Updated: ");
                Console.WriteLine("{");
                Console.WriteLine("\t" + goldName + ": " + String.Format("{0:C}", Double.Parse(goldPrice)));
                Console.WriteLine("\tPrice per gram: " + String.Format("{0:C}", Double.Parse(goldPrice) / 31.1));
                Console.WriteLine("}");
                Console.WriteLine();
#endif

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updateSilverPrice()
        {
            try
            {
                // Initialize the HtmlAgilityPack client.
                var web = new HtmlWeb();

                // Load the target page and scrape current price and metal name.
                var kitcoPath = web.Load("https://www.kitco.com/price/precious-metals");
                var silverName = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[2]/div/ul/li[2]/div/span[1]/a").First().InnerText;
                var silverPrice = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[2]/div/ul/li[2]/div/span[2]").First().InnerText;

                SQLiteCommand cmdUpdateSilver = DBConnection.CreateCommand();
                cmdUpdateSilver.CommandText = @"UPDATE MetalPrice
                                              SET Price_per_Ounce = @NewPrice
                                              WHERE Metal_Type = 2";
                cmdUpdateSilver.Parameters.AddWithValue("@NewPrice", Double.Parse(silverPrice));
                cmdUpdateSilver.ExecuteNonQuery();

#if DEBUG
                Console.WriteLine("Updated: ");
                Console.WriteLine("{");
                Console.WriteLine("\t" + silverName + ": " + String.Format("{0:C}", Double.Parse(silverPrice)));
                Console.WriteLine("\tPrice per gram: " + String.Format("{0:C}", Double.Parse(silverPrice) / 31.1));
                Console.WriteLine("}");
                Console.WriteLine();
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updatePlatinumPrice()
        {
            try
            {
                // Initialize the HtmlAgilityPack client.
                var web = new HtmlWeb();

                // Load the target page and scrape current price and metal name.
                var kitcoPath = web.Load("https://www.kitco.com/price/precious-metals");
                var platinumName = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[2]/div/ul/li[3]/div/span[1]/a").First().InnerText;
                var platinumPrice = kitcoPath.DocumentNode.SelectNodes("//*[@id=\"__next\"]/main/div[1]/div[2]/div[2]/div/ul/li[3]/div/span[2]").First().InnerText;

                SQLiteCommand cmdUpdatePlatinum = DBConnection.CreateCommand();
                cmdUpdatePlatinum.CommandText = @"UPDATE MetalPrice
                                                  SET Price_per_Ounce = @NewPrice
                                                  WHERE Metal_Type = 3";
                cmdUpdatePlatinum.Parameters.AddWithValue("@NewPrice", Double.Parse(platinumPrice));
                cmdUpdatePlatinum.ExecuteNonQuery();

#if DEBUG
                Console.WriteLine("Updated: ");
                Console.WriteLine("{");
                Console.WriteLine("\t" + platinumName + ": " + String.Format("{0:C}", Double.Parse(platinumPrice)));
                Console.WriteLine("\tPrice per gram: " + String.Format("{0:C}", Double.Parse(platinumPrice) / 31.1));
                Console.WriteLine("}");
                Console.WriteLine();
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
