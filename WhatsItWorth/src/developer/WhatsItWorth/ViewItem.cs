// ViewItems.cs by Ben Ebadinia

using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class ViewItem : Form
    {
        // Shared SQLite connection used by this page.
        public SQLiteConnection DBConnection;

        // The ItemID for the item being viewed/edited.
        public string itemIdentification;

        public ViewItem(string intID)
        {
            InitializeComponent();
            itemIdentification = intID;
        }

        private void ViewItemPage_Load(object sender, EventArgs e)
        {
            try
            {
#if DEBUG
                Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") succesfully selected.");
#endif


                // Load the item details for display.
                SQLiteCommand cmdLoadInfo = DBConnection.CreateCommand();

                cmdLoadInfo.CommandText = @"SELECT Metal_Type, Metal_Purity, Total_Weight, Description, Date_Added, Original_Price, Current_Price, Price_of_Diamonds, Photo_Link
                                            FROM Item
                                            WHERE ItemID = @ii";
                cmdLoadInfo.Parameters.AddWithValue("@ii", itemIdentification);

                SQLiteDataReader rdr = cmdLoadInfo.ExecuteReader();

                if (rdr.Read())
                {
                    // Translate stored metal type code to display text and toggle purity visibility for gold.
                    if (Convert.ToInt32(rdr[0]) == 1)
                    {
                        metalTextBox.Text = "Gold";
                        purityLabel.Visible = true;
                        purityTextBox.Visible = true;
                        purityTextBox.Text = rdr[1].ToString();
                    }
                    else if (Convert.ToInt32(rdr[0]) == 2)
                    {
                        metalTextBox.Text = "Silver";
                    }
                    else if (Convert.ToInt32(rdr[0]) == 3)
                    {
                        metalTextBox.Text = "Platinum";
                    }

                    // Populate basic fields.
                    totalTextBox.Text = rdr[2].ToString();
                    descriptionTextBox.Text = rdr[3].ToString().Trim();

                    // Format date and currency.
                    dateTextBox.Text = String.Format("{0:d}", rdr[4]);
                    originalTextBox.Text = String.Format("{0:C}", rdr[5]);
                    currentTextBox.Text = String.Format("{0:C}", rdr[6]);

                    // Calculate price change and set color based on gain/loss.
                    double originalPrice = double.Parse(rdr[5].ToString());
                    double currentPrice = double.Parse(rdr[6].ToString());
                    double change = ((currentPrice - originalPrice) / originalPrice) * 100;

                    if (currentPrice > originalPrice)
                    {
                        changeTextBox.ForeColor = Color.LawnGreen;
                    }
                    else if (currentPrice < originalPrice)
                    {
                        changeTextBox.ForeColor = Color.Red;
                    }
                    else
                    {
                        changeTextBox.ForeColor = Color.Black;
                    }

                    // Display as percentage with one decimal place.
                    changeTextBox.Text = (change / 100).ToString("P1");

                    // Show diamond list if there is diamond pricing.
                    if (rdr[7].ToString() != "")
                    {
                        viewList.Visible = true;
                    }

                    // Attempt to load item photo from stored path.
                    if (rdr[8].ToString() != "")
                    {
                        try
                        {
                            itemImageBox.Image = new Bitmap(rdr[8].ToString().Trim());
                            itemImageBox.Visible = true;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                    }

                }

                // Populate diamonds grid for this item.
                LoadDiamondView();


                // Close data reader after use.
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) ViewItem -> HomePage");
#endif

            // Close dialog and return to previous page.
            this.DialogResult = DialogResult.OK;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Ask for delete confirmation.
            DeleteItemConfirmation deleteItemForm = new DeleteItemConfirmation();
            deleteItemForm.ShowDialog();

#if DEBUG
            Console.WriteLine("ViewItem -> DeleteItemConfirmation");
#endif

            if (deleteItemForm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    // Ensure foreign key constraints are enforced for cascading deletes.
                    using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", DBConnection))
                    {
                        pragmaCmd.ExecuteNonQuery();
                    }

                    // Delete the item.
                    SQLiteCommand cmdDeleteItem = DBConnection.CreateCommand();
                    cmdDeleteItem.CommandText = @"DELETE FROM Item
                                                  WHERE ItemID = @ii";
                    cmdDeleteItem.Parameters.AddWithValue("@ii", itemIdentification);
                    cmdDeleteItem.ExecuteNonQuery();

#if DEBUG
                    Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") succesfully deleted.");
                    
#endif

                    // Verify foreign key setting (diagnostic logging).
                    using (SQLiteCommand checkCmd = new SQLiteCommand("PRAGMA foreign_keys;", DBConnection))
                    {
                        var result = checkCmd.ExecuteScalar();
                        Console.WriteLine($"Foreign keys enabled: {result}");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Notify caller that delete was confirmed and completed.
                Console.WriteLine("ViewItem -> HomePage");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            // Allow user to pick a photo file and save the path.
            Image File;

            OpenFileDialog dialog = new OpenFileDialog();

            // Restrict to common image formats.
            dialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Preview the selected image.
                File = Image.FromFile(dialog.FileName);
                itemImageBox.Image = File;
                itemImageBox.Visible = true;

                try
                {
                    // Persist the file path in the database for the item.
                    SQLiteCommand cmdUpdateDate = DBConnection.CreateCommand();
                    cmdUpdateDate.CommandText = @"UPDATE Item
                                                  SET Photo_Link = @pl
                                                  WHERE ItemID = @ii";
                    cmdUpdateDate.Parameters.AddWithValue("@pl", dialog.FileName);
                    cmdUpdateDate.Parameters.AddWithValue("@ii", itemIdentification);

                    cmdUpdateDate.ExecuteNonQuery();

#if DEBUG
                    Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") picture successfully updated.");
#endif

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // Toggle UI to enable description editing.
            editButton.Visible = false;
            saveButton.Visible = true;

            descriptionTextBox.Enabled = true;
            descriptionTextBox.ReadOnly = false;

#if DEBUG
            Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") description editing enabled.");
#endif
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save provided description, or generate a default if empty.
            if (!String.Equals(descriptionTextBox.Text.Trim(), ""))
            {
                try
                {

                    SQLiteCommand cmdUpdateDescription = DBConnection.CreateCommand();
                    cmdUpdateDescription.CommandText = @"UPDATE Item
                                                         SET Description = @d
                                                         WHERE ItemID = @ii";
                    cmdUpdateDescription.Parameters.AddWithValue("@d", descriptionTextBox.Text.Trim());
                    cmdUpdateDescription.Parameters.AddWithValue("@ii", itemIdentification);

                    cmdUpdateDescription.ExecuteNonQuery();

#if DEBUG
                    Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") custom description successfully updated.");
#endif

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Build a simple default description from known fields.
                string tempDescription;

                if (String.Equals(metalTextBox.Text.Trim(), "Gold"))
                {
                    if (viewList.Visible)
                    {
                        tempDescription = purityTextBox.Text.Trim() + "K Gold; " + totalTextBox.Text.Trim() + "G with Diamonds";
                    }
                    else
                    {
                        tempDescription = purityTextBox.Text.Trim() + "K Gold; " + totalTextBox.Text.Trim() + "G";
                    }
                }
                else
                {
                    if (viewList.Visible)
                    {
                        tempDescription = metalTextBox.Text.Trim() + "; " + totalTextBox.Text.Trim() + "G with Diamonds";
                    }
                    else
                    {
                        tempDescription = metalTextBox.Text.Trim() + "; " + totalTextBox.Text.Trim() + "G";
                    }
                }


                try
                {

                    SQLiteCommand cmdUpdateDescription = DBConnection.CreateCommand();
                    cmdUpdateDescription.CommandText = @"UPDATE Item
                                                         SET Description = @td
                                                         WHERE ItemID = @ii";
                    cmdUpdateDescription.Parameters.AddWithValue("@td", tempDescription.Trim());
                    cmdUpdateDescription.Parameters.AddWithValue("@ii", itemIdentification);

                    cmdUpdateDescription.ExecuteNonQuery();

#if DEBUG
                    Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") auto description successfully updated.");
#endif

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Toggle UI back to read-only.
            editButton.Visible = true;
            saveButton.Visible = false;

            descriptionTextBox.Enabled = false;
            descriptionTextBox.ReadOnly = true;

#if DEBUG
            Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") description editing disabled.");
#endif

        }

        private void LoadDiamondView()
        {
            // Clear existing rows
            viewList.Rows.Clear();

            // Load diamond attributes associated with the item.
            SQLiteCommand cmdLoadTable = DBConnection.CreateCommand();

            cmdLoadTable.CommandText = @"SELECT Diamond_Cut, Diamond_Clarity, Diamond_Color, Diamond_Carat, Price_of_Diamond
                                         FROM Diamond
                                         WHERE ItemID = @ii";
            cmdLoadTable.Parameters.AddWithValue("@ii", itemIdentification);

            SQLiteDataReader rdr = cmdLoadTable.ExecuteReader();

            while (rdr.Read())
            {
                // Add each diamond row to the grid.
                viewList.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
            }

            // Close reader after populating grid.
            rdr.Close();

#if DEBUG
            Console.WriteLine("ViewItem.cs: Item (ID: " + itemIdentification + ") diamond table successfully loaded.");
#endif

        }
    }
}
