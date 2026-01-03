// ItemPricing.cs by Ben Ebadinia

using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WhatsItWorth
{
    [XmlRoot(ElementName = "pr")]

    // Function for decrypting XML and price
    public class DecryptPrice
    {

        [XmlElement(ElementName = "min")]
        public int Min { get; set; }

    }

    public class ItemPricing
    {
        // Shared SQLite connection and current user ID for queries/updates.
        public SQLiteConnection DBConnection;
        public int userIdentification;

        // Cached market prices (per ounce) for each metal, loaded from MetalPrice table.
        private double currentGold, currentSilver, currentPlatinum;

        // Reusable buffer for item/diamond price updates.
        Dictionary<string, double> itemList = new Dictionary<string, double>();

        // Entry point to check whether item prices need refreshing based on Date_Updated.
        public void checkDate() // Public call which checks the date
        {
            bool updateItemsOption = false;
            try
            {

                // Get each item's last update date for the current user.
                SQLiteCommand cmdGetItemDate = DBConnection.CreateCommand();  // Getting the item update date

                cmdGetItemDate.CommandText = @"SELECT Date_Updated
                                               FROM Item
                                               WHERE UserID = @ui";
                cmdGetItemDate.Parameters.AddWithValue("@ui", userIdentification); ;

                SQLiteDataReader rdr = cmdGetItemDate.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr[0].ToString() != "")
                    {
                        DateTime dt = DateTime.Parse(rdr[0].ToString());
                        if ((DateTime.UtcNow.Date != dt.Date))
                        {
#if DEBUG
                            Console.WriteLine("Update Items");
#endif
                            updateItemsOption = true;
                        }
                        else
                        {
#if DEBUG
                            Console.WriteLine("Do Nothing");
#endif
                        }

                    }
                    else
                    {
#if DEBUG
                        Console.WriteLine("Update Items");
#endif
                        updateItemsOption = true;
                    }


                }

                rdr.Close();

                if (updateItemsOption)
                {
                    updateItems(true);
                }
                else
                {
#if DEBUG
                    Console.WriteLine("Everything Remains Same");
#endif
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Loads current metal prices and optionally triggers per-item price recomputation.
        private void updateItems(bool x) // Public call which updates rest of pricing for item
        {
            try
            {
                // Load the latest market price per ounce for each metal.
                SQLiteCommand cmdGetMetalInfo = DBConnection.CreateCommand();  // Getting the metal type and the market price from database to store in local variables

                cmdGetMetalInfo.CommandText = @"SELECT Metal_Type, Price_per_Ounce
                                                FROM MetalPrice";

                SQLiteDataReader rdr = cmdGetMetalInfo.ExecuteReader();

                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr[0]) == 1)
                    {
                        currentGold = Double.Parse(rdr[1].ToString());
                    }
                    else if (Convert.ToInt32(rdr[0]) == 2)
                    {
                        currentSilver = Double.Parse(rdr[1].ToString());
                    }
                    else if (Convert.ToInt32(rdr[0]) == 3)
                    {
                        currentPlatinum = Double.Parse(rdr[1].ToString());
                    }
                }

                rdr.Close();

                if (x)
                {
                    // Recompute component and total prices for all items.
                    updateMetalPrice(); // Call to update gold/silver/platinum price per item
                    updateDiamondPrice(); // Call to update diamond price per diamond and per item
                    updateTotalPrice(); // Call to update total price
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Updating Metal Pricing
        private void updateMetalPrice() // Getting and Updating the metal prices for each user item
        {
            try
            {
                // Select all items for this user to compute metal component based on metal type/purity/weight.
                SQLiteCommand cmdGetItemlInfo = DBConnection.CreateCommand(); // Selecting all users items and finding the metal type

                cmdGetItemlInfo.CommandText = @"SELECT ItemID, Metal_Type, Metal_Purity, Total_Weight, Price_of_Diamonds
                                                FROM Item
                                                WHERE UserID = @ui";
                cmdGetItemlInfo.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));

                SQLiteDataReader rdr = cmdGetItemlInfo.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(String.Format("{0:C}", calculateMetalPrice((int)rdr[1], rdr[2].ToString(), Double.Parse(rdr[3].ToString()))));
                    itemList.Add(rdr[0].ToString().Trim(), calculateMetalPrice(Convert.ToInt32(rdr[1]), rdr[2].ToString().Trim(), Double.Parse(rdr[3].ToString())));
                }

                rdr.Close();


                foreach (KeyValuePair<string, double> s in itemList)
                {
#if DEBUG
                    Console.WriteLine("Metal ID = {0} Metal Value = {1}", s.Key, s.Value);
                    Console.WriteLine();
#endif

                    // Update the metal-only price for this item.
                    SQLiteCommand cmdUpdateMetalPrice = DBConnection.CreateCommand(); // Updating metal price for item in Item database based on price calculation from calculateMetalPrice

                    cmdUpdateMetalPrice.CommandText = @"UPDATE Item
                                                        SET Price_of_Metal = @NewPrice
                                                        WHERE ItemID = @ii";
                    cmdUpdateMetalPrice.Parameters.AddWithValue("@NewPrice", s.Value);
                    cmdUpdateMetalPrice.Parameters.AddWithValue("@ii", s.Key);
                    cmdUpdateMetalPrice.ExecuteNonQuery();
                }

                itemList.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Calculates the metal component price for an item (per gram conversion and purity adjustment where applicable).
        private double calculateMetalPrice(int type, string purity, double weight) // Calculating and returning the metal price for each item
        {
            double metalPrice = 0;

            if (type == 1)
            {
                metalPrice = (((currentGold / 31.1) / 24) * Int32.Parse(purity)) * weight;
            }
            else if (type == 2)
            {
                metalPrice = (currentSilver / 31.1) * weight;
            }
            else if (type == 3)
            {
                metalPrice = (currentPlatinum / 31.1) * weight;
            }


            return Math.Round(metalPrice, 2);
        }

        //Updating Diamond Pricing
        // Computes and updates diamond prices per diamond, and aggregates per item.
        private void updateDiamondPrice() // Getting and Updating the diamond prices for each user item
        {
            try
            {
                // Select all diamonds belonging to the current user's items.
                SQLiteCommand cmdGetDiamondlInfo = DBConnection.CreateCommand(); // Selecting all item diamonds information depending on user

                cmdGetDiamondlInfo.CommandText = @"SELECT D.Diamond_ID, Diamond_Carat, Diamond_Color, Diamond_Clarity, Diamond_Cut 
                                                   FROM Diamond AS D INNER JOIN Item AS I ON D.ItemID = I.ItemID
                                                   WHERE UserID = @ui";
                cmdGetDiamondlInfo.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));

                SQLiteDataReader rdr = cmdGetDiamondlInfo.ExecuteReader();

                while (rdr.Read())
                {
                    itemList.Add(rdr[0].ToString().Trim(), calculateDiamondPrice(rdr[1].ToString().Trim(), rdr[2].ToString().Trim(), rdr[3].ToString().Trim(), rdr[4].ToString().Trim()));
                }

                rdr.Close();

                foreach (KeyValuePair<string, double> s in itemList)
                {
#if DEBUG
                    Console.WriteLine("Diamond ID = {0} Diamond Value = {1}", s.Key, s.Value);
                    Console.WriteLine();
#endif
                    
                    if (s.Value != 0.0)
                    {
                        // Update price for individual diamond.
                        SQLiteCommand cmdUpdateDiamondPrice = DBConnection.CreateCommand(); // Updating individual diamond price for each diamond in Diamond database

                        cmdUpdateDiamondPrice.CommandText = @"UPDATE Diamond
                                                              SET Price_of_Diamond = @NewPrice
                                                              WHERE Diamond_ID = @di";
                        cmdUpdateDiamondPrice.Parameters.AddWithValue("@NewPrice", s.Value);
                        cmdUpdateDiamondPrice.Parameters.AddWithValue("@di", s.Key);
                        cmdUpdateDiamondPrice.ExecuteNonQuery();
                    }
                    else
                    {
#if DEBUG
                        Console.WriteLine("Damond ID {0} did not update value", s.Key);
#endif
                    }
                }
;
                itemList.Clear();

                // Update per-item total diamond value across all diamonds.
                SQLiteCommand cmdUpdateDiamondTotal = DBConnection.CreateCommand(); // Updating total diamond prices for all diamonds in Item database

                cmdUpdateDiamondTotal.CommandText = @"UPDATE Item
                                                      SET Price_of_Diamonds = (SELECT SUM(Price_of_Diamond)
							                                                   FROM Diamond
							                                                   WHERE Diamond.ItemID = Item.ItemID)
                                                      WHERE UserID = @ui";
                cmdUpdateDiamondTotal.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
                cmdUpdateDiamondTotal.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Calls the IDEX online service to retrieve diamond price and parses XML to extract the minimum price.
        private double calculateDiamondPrice(string carat, string color, string clarity, string cut) // Using API to calculate and return individual diamond price
        {
            try
            {
                var options = new RestClientOptions($"http://www.idexonline.com/DPService.asp?SID=4wp7go123jqtkdyd5f2e&cut={cut}&carat={carat}&color={color}&clarity={clarity}");
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest("", Method.Get);
                RestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);

                XmlSerializer serializer = new XmlSerializer(typeof(DecryptPrice));
                using (StringReader reader = new StringReader(response.Content))
                {
                    var test = (DecryptPrice)serializer.Deserialize(reader);
                    return test.Min;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0;
            }
        }



        //Updating Total Pricing
        // Updates each item's total price (metal + diamonds) and refreshes the user's aggregate total.
        private void updateTotalPrice() // Getting and Updating the total price for item using the updated metal price and diamond price for each user item
        {
            // Select component prices for all items owned by the current user.
            SQLiteCommand cmdCalculateItemPrices = DBConnection.CreateCommand(); // Selecting both prices

            cmdCalculateItemPrices.CommandText = @"SELECT ItemID, Price_of_Metal, Price_of_Diamonds
                                                   FROM Item
                                                   WHERE UserID = @ui";
            cmdCalculateItemPrices.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));

            SQLiteDataReader rdr = cmdCalculateItemPrices.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr[2].ToString() != "")
                {
                    itemList.Add(rdr[0].ToString().Trim(), (Double.Parse(rdr[1].ToString()) + Double.Parse(rdr[2].ToString()))); // Adding both prices if item has diamonds
                }
                else
                {
                    itemList.Add(rdr[0].ToString().Trim(), Double.Parse(rdr[1].ToString())); // Adding only metal price if item has no diamonds
                }

            }

            rdr.Close();


            foreach (KeyValuePair<string, double> s in itemList)
            {
#if DEBUG
                Console.WriteLine("Item ID = {0} Total Price = {1}", s.Key, s.Value);
                Console.WriteLine();
#endif

                SQLiteCommand cmdUpdateTotalPrice = DBConnection.CreateCommand(); // Updating item databases total price

                cmdUpdateTotalPrice.CommandText = @"UPDATE Item
                                                    SET Current_Price = @NewPrice, Date_Updated = @NewDate
                                                    WHERE ItemID = @ii";
                cmdUpdateTotalPrice.Parameters.AddWithValue("@NewPrice", s.Value);
                cmdUpdateTotalPrice.Parameters.AddWithValue("@NewDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
                cmdUpdateTotalPrice.Parameters.AddWithValue("@ii", s.Key);
                cmdUpdateTotalPrice.ExecuteNonQuery();

            }

            itemList.Clear();

            SQLiteCommand cmdUpdateUserTotal = DBConnection.CreateCommand(); // Updating total item prices for a user in User database

            cmdUpdateUserTotal.CommandText = @"UPDATE [User]
                                               SET Total_Price = (SELECT SUM(Current_Price)
				                                                  FROM Item
				                                                  WHERE UserID = @ui)
                                               WHERE UserID = @ui";
            cmdUpdateUserTotal.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
            cmdUpdateUserTotal.ExecuteNonQuery();

        }


        // Inserts a new item with calculated initial metal price and optional description/photo.
        public void createItem(string tempItemID, int itemMetal, int goldPurity, double totalWeight, string description, string photoPath, bool hasDiamonds)
        {
            updateItems(false);

            try
            {
                SQLiteCommand cmdAddItem = DBConnection.CreateCommand();
                cmdAddItem.CommandText = @"INSERT INTO Item (ItemID, UserID, Metal_Type, Metal_Purity, Total_Weight, Price_of_Metal, Description, Current_Price, Date_Added, Original_Price, Photo_Link)
                                           VALUES (@itemID, @userID, @metalType, @metalPurity, @totalWeight, @priceMetal, @description, @currentPrice, @date, @originalPrice, @photo)";

                cmdAddItem.Parameters.AddWithValue("@itemID", tempItemID);
                cmdAddItem.Parameters.AddWithValue("@userID", Convert.ToInt32(userIdentification));
                cmdAddItem.Parameters.AddWithValue("@metalType", itemMetal);

                if (itemMetal == 1)
                {
                    cmdAddItem.Parameters.AddWithValue("@metalPurity", goldPurity);
                }
                else
                {
                    cmdAddItem.Parameters.AddWithValue("@metalPurity", DBNull.Value);
                }

                cmdAddItem.Parameters.AddWithValue("@totalWeight", totalWeight);
                cmdAddItem.Parameters.AddWithValue("@priceMetal", calculateMetalPrice(itemMetal, goldPurity.ToString(), totalWeight));

                if (!String.Equals(description, ""))
                {
                    cmdAddItem.Parameters.AddWithValue("@description", description);
                }
                else
                {
                    string tempDescription;

                    if (itemMetal == 1)
                    {
                        if (hasDiamonds)
                        {
                            tempDescription = goldPurity.ToString() + "K Gold; " + totalWeight.ToString() + "G with Diamonds";
                        }
                        else
                        {
                            tempDescription = goldPurity.ToString() + "K Gold; " + totalWeight.ToString() + "G";
                        }
                    }
                    else if (itemMetal == 2)
                    {
                        if (hasDiamonds)
                        {
                            tempDescription = "Silver; " + totalWeight.ToString() + "G with Diamonds";
                        }
                        else
                        {
                            tempDescription = "Silver; " + totalWeight.ToString() + "G";
                        }
                    }
                    else
                    {
                        if (hasDiamonds)
                        {
                            tempDescription = "Platinum; " + totalWeight.ToString() + "G with Diamonds";
                        }
                        else
                        {
                            tempDescription = "Platinum; " + totalWeight.ToString() + "G";
                        }
                    }

                    cmdAddItem.Parameters.AddWithValue("@description", tempDescription);
                }

                double tempPrice = calculateMetalPrice(itemMetal, goldPurity.ToString(), totalWeight);

                cmdAddItem.Parameters.AddWithValue("@currentPrice", tempPrice);
                cmdAddItem.Parameters.AddWithValue("@date", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
                cmdAddItem.Parameters.AddWithValue("@originalPrice", tempPrice);

                if (!String.Equals(photoPath, ""))
                {
                    cmdAddItem.Parameters.AddWithValue("@photo", photoPath);
                }
                else
                {
                    cmdAddItem.Parameters.AddWithValue("@photo", DBNull.Value);
                }


                cmdAddItem.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Inserts a new diamond for an item and records its calculated price.
        public void createDiamond(string tempDiamondID, string tempItemID, string cut, string color, string clarity, double carat)
        {
            try
            {
                SQLiteCommand cmdAddDiamonds = DBConnection.CreateCommand();
                cmdAddDiamonds.CommandText = @"INSERT INTO Diamond (Diamond_ID, ItemID, Diamond_Carat, Diamond_Color, Diamond_Clarity, Diamond_Cut, Price_of_Diamond)
                                                   VALUES (@ndid, @niid, @carat, @color, @clarity, @cut, @dprice)";
                cmdAddDiamonds.Parameters.AddWithValue("@ndid", tempDiamondID);
                cmdAddDiamonds.Parameters.AddWithValue("@niid", tempItemID);
                cmdAddDiamonds.Parameters.AddWithValue("@carat", carat);
                cmdAddDiamonds.Parameters.AddWithValue("@color", color);
                cmdAddDiamonds.Parameters.AddWithValue("@clarity", clarity);
                cmdAddDiamonds.Parameters.AddWithValue("@cut", cut);
                cmdAddDiamonds.Parameters.AddWithValue("@dprice", calculateDiamondPrice(carat.ToString(), color.ToString(), clarity, cut));

                cmdAddDiamonds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Looks up a diamond price and returns true if available (non-zero), otherwise false.
        public bool getDiamondPrice(string cut, string color, string clarity, string carat)
        {
            var price = calculateDiamondPrice(carat, color, clarity, cut);

#if DEBUG
            Console.WriteLine("Diamond Price: $" + price);
#endif

            return price != 0.0;
        }

        //Updating New Item
        // Updates aggregated diamond price for a new item, sets current/original price and updates user's total.
        public void updateNewItem(string itemID) // Getting and Updating the total price for item using the updated metal price and diamond price for each user item
        {
            double tempPrice = 0;

            try
            {
                SQLiteCommand cmdUpdateDiamondTotal = DBConnection.CreateCommand(); // Updating diamond price for all diamond in Item database

                cmdUpdateDiamondTotal.CommandText = @"UPDATE Item
                                                      SET Price_of_Diamonds = (SELECT SUM(Price_of_Diamond)
							                                                   FROM Diamond
							                                                   WHERE Diamond.ItemID = Item.ItemID)
                                                      WHERE ItemID = @ii";
                cmdUpdateDiamondTotal.Parameters.AddWithValue("@ii", itemID);
                cmdUpdateDiamondTotal.ExecuteNonQuery();


                SQLiteCommand cmdNewItemPrices = DBConnection.CreateCommand(); // Selecting both prices

                cmdNewItemPrices.CommandText = @"SELECT Price_of_Metal, Price_of_Diamonds
                                                 FROM Item
                                                 WHERE ItemID = @ii";
                cmdNewItemPrices.Parameters.AddWithValue("@ii", itemID);

                SQLiteDataReader rdr = cmdNewItemPrices.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr[1].ToString() != "")
                    {
                        tempPrice = Double.Parse(rdr[0].ToString()) +
                                    Double.Parse(rdr[1].ToString()); // Adding both prices if item has diamonds
                    }
                    else
                    {
                        tempPrice = Double.Parse(rdr[0].ToString()); // Adding only metal price if item has no diamonds
                    }

                }

                rdr.Close();


                SQLiteCommand cmdUpdateItemPrice = DBConnection.CreateCommand(); // Updating item databases total price

                cmdUpdateItemPrice.CommandText = @"UPDATE Item
                                                   SET Current_Price = @NewPrice, Original_Price = @NewPrice, Date_Updated = @NewDate
                                                   WHERE ItemID = @ii";
                cmdUpdateItemPrice.Parameters.AddWithValue("@NewPrice", tempPrice);
                cmdUpdateItemPrice.Parameters.AddWithValue("@NewDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
                cmdUpdateItemPrice.Parameters.AddWithValue("@ii", itemID);
                cmdUpdateItemPrice.ExecuteNonQuery();


                SQLiteCommand cmdUpdateUserTotal = DBConnection.CreateCommand(); // Updating total item prices for a user in User database

                cmdUpdateUserTotal.CommandText = @"UPDATE [User]
                                               SET Total_Price = (SELECT SUM(Current_Price)
				                                                  FROM Item
				                                                  WHERE UserID = @ui)
                                               WHERE UserID = @ui";
                cmdUpdateUserTotal.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
                cmdUpdateUserTotal.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }



}
