// ComparePage.cs by Ben Ebadinia

using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class ComparePage : Form
    {
        // SQLite connection provided by the caller; must be open/valid when using this page.
        public SQLiteConnection DBConnection;
        // Current user ID used to filter items.
        public int userIdentification;

        public ComparePage(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }

        private void ComparePage_Load(object sender, EventArgs e)
        {

            // Prepare UI for fresh load.
            // Clear existing comboBoxes
            itemComboBox1.Items.Clear();
            itemComboBox2.Items.Clear();

            // Fill comboBoxes with data from the database
            SQLiteCommand cmdComboBoxes = DBConnection.CreateCommand();

            cmdComboBoxes.CommandText = @"SELECT ItemID
                                         FROM Item
                                         WHERE UserID = @ui";
            cmdComboBoxes.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));

            SQLiteDataReader rdr = cmdComboBoxes.ExecuteReader();

            while (rdr.Read())
            {
                itemComboBox1.Items.Add(rdr[0].ToString());
                itemComboBox2.Items.Add(rdr[0].ToString());
            }

#if DEBUG
            Console.WriteLine("ComparePage.cs: User (ID: " + userIdentification + ") items loaded in combo-box successfully.");
#endif

            rdr.Close();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) ComparePage -> HomePage");
#endif

            this.DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmdLoadInfo = DBConnection.CreateCommand();

                cmdLoadInfo.CommandText = @"SELECT Metal_Type, Metal_Purity, Total_Weight, Description, Date_Added, Original_Price, Current_Price, Price_of_Diamonds, Photo_Link
                                             FROM Item
                                             WHERE ItemID = @ii";
                cmdLoadInfo.Parameters.AddWithValue("@ii", itemComboBox1.Text);

                SQLiteDataReader rdr = cmdLoadInfo.ExecuteReader();

                if (rdr.Read())
                {
                    // Determine metal type and toggle purity fields visibility for gold only.
                    int metalType = Convert.ToInt32(rdr[0]);
                    if (metalType == 1)
                    {
                        metalTextBox1.Text = "Gold";
                        purityLabel1.Visible = true;
                        purityTextBox1.Visible = true;
                        purityTextBox1.Text = rdr[1].ToString();
                    }
                    else if (metalType == 2)
                    {
                        metalTextBox1.Text = "Silver";
                        purityLabel1.Visible = false;
                        purityTextBox1.Visible = false;
                    }
                    else if (metalType == 3)
                    {
                        metalTextBox1.Text = "Platinum";
                        purityLabel1.Visible = false;
                        purityTextBox1.Visible = false;
                    }

                    totalTextBox1.Text = rdr[2].ToString();
                    descriptionTextBox1.Text = rdr[3].ToString().Trim();

                    dateTextBox1.Text = String.Format("{0:d}", rdr[4]);
                    originalPriceTextBox1.Text = String.Format("{0:C}", rdr[5]);
                    currentPriceTextBox1.Text = String.Format("{0:C}", rdr[6]);

                    // Compute price change ratio (current-original)/original
                    double originalPrice = double.Parse(rdr[5].ToString());
                    double currentPrice = double.Parse(rdr[6].ToString());
                    double changeRatio = (originalPrice != 0) ? ((currentPrice - originalPrice) / originalPrice) : 0.0;

                    if (currentPrice > originalPrice)
                    {
                        changeTextBox1.ForeColor = Color.LawnGreen;
                    }
                    else if (currentPrice < originalPrice)
                    {
                        changeTextBox1.ForeColor = Color.Red;
                    }
                    else
                    {
                        changeTextBox1.ForeColor = Color.Black;
                    }

                    // Display as percentage with one decimal place.
                    changeTextBox1.Text = changeRatio.ToString("P1");

                    if (rdr[7].ToString() != "")
                    {
                        viewList1.Visible = true;
                    }
                    else
                    {
                        viewList1.Visible = false;
                        viewList1.Refresh();
                    }

                    if (rdr[8].ToString() != "")
                    {
                        try
                        {
                            itemImageBox1.Image = new Bitmap(rdr[8].ToString().Trim());
                            itemImageBox1.Visible = true;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                    }
                    else
                    {
                        itemImageBox1.Visible = false;
                        itemImageBox1.Refresh();
                    }

                }

#if DEBUG
                Console.WriteLine("ComparePage.cs: Items details retrieved and displayed successfully (Left combo-box item).");
#endif

                LoadDiamondView(1);


                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmdLoadInfo = DBConnection.CreateCommand();

                cmdLoadInfo.CommandText = @"SELECT Metal_Type, Metal_Purity, Total_Weight, Description, Date_Added, Original_Price, Current_Price, Price_of_Diamonds, Photo_Link
                                             FROM Item
                                             WHERE ItemID = @ii";
                cmdLoadInfo.Parameters.AddWithValue("@ii", itemComboBox2.Text);

                SQLiteDataReader rdr = cmdLoadInfo.ExecuteReader();

                if (rdr.Read())
                {
                    // Determine metal type and toggle purity fields visibility for gold only.
                    int metalType = Convert.ToInt32(rdr[0]);
                    if (metalType == 1)
                    {
                        metalTextBox2.Text = "Gold";
                        purityLabel2.Visible = true;
                        purityTextBox2.Visible = true;
                        purityTextBox2.Text = rdr[1].ToString();
                    }
                    else if (metalType == 2)
                    {
                        metalTextBox2.Text = "Silver";
                        purityLabel2.Visible = false;
                        purityTextBox2.Visible = false;
                    }
                    else if (metalType == 3)
                    {
                        metalTextBox2.Text = "Platinum";
                        purityLabel2.Visible = false;
                        purityTextBox2.Visible = false;
                    }

                    totalTextBox2.Text = rdr[2].ToString();
                    descriptionTextBox2.Text = rdr[3].ToString().Trim();

                    dateTextBox2.Text = String.Format("{0:d}", rdr[4]);
                    originalPriceTextBox2.Text = String.Format("{0:C}", rdr[5]);
                    currentPriceTextBox2.Text = String.Format("{0:C}", rdr[6]);

                    // Compute price change ratio (current-original)/original
                    double originalPrice = double.Parse(rdr[5].ToString());
                    double currentPrice = double.Parse(rdr[6].ToString());
                    double changeRatio = (originalPrice != 0) ? ((currentPrice - originalPrice) / originalPrice) : 0.0;

                    if (currentPrice > originalPrice)
                    {
                        changeTextBox2.ForeColor = Color.LawnGreen;
                    }
                    else if (currentPrice < originalPrice)
                    {
                        changeTextBox2.ForeColor = Color.Red;
                    }
                    else
                    {
                        changeTextBox2.ForeColor = Color.Black;
                    }

                    // Display as percentage with one decimal place.
                    changeTextBox2.Text = changeRatio.ToString("P1");

                    if (rdr[7].ToString() != "")
                    {
                        viewList2.Visible = true;
                    }
                    else
                    {
                        viewList2.Visible = false;
                        viewList2.Refresh();
                    }

                    if (rdr[8].ToString() != "")
                    {
                        try
                        {
                            itemImageBox2.Image = new Bitmap(rdr[8].ToString().Trim());
                            itemImageBox2.Visible = true;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                    }
                    else
                    {
                        itemImageBox2.Visible = false;
                        itemImageBox2.Refresh();
                    }

                }

#if DEBUG
                Console.WriteLine("ComparePage.cs: Items details retrieved and displayed successfully (Right combo-box item).");
#endif

                LoadDiamondView(2);

                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDiamondView(int x)
        {
            // Populate the diamonds grid for left (1) or right (2) item panel.
            if (x == 1)
            {
                // Clear existing rows
                viewList1.Rows.Clear();

                SQLiteCommand cmdLoadTable = DBConnection.CreateCommand();

                cmdLoadTable.CommandText = @"SELECT Diamond_Cut, Diamond_Clarity, Diamond_Color, Diamond_Carat, Price_of_Diamond
                                             FROM Diamond
                                             WHERE ItemID = @ii";
                cmdLoadTable.Parameters.AddWithValue("@ii", itemComboBox1.Text);

                SQLiteDataReader rdr = cmdLoadTable.ExecuteReader();

                while (rdr.Read())
                {
                    viewList1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }

                rdr.Close();
            }
            else if (x == 2)
            {
                // Clear existing rows
                viewList2.Rows.Clear();

                SQLiteCommand cmdLoadTable = DBConnection.CreateCommand();
                cmdLoadTable.CommandText = @"SELECT Diamond_Cut, Diamond_Clarity, Diamond_Color, Diamond_Carat, Price_of_Diamond
                                             FROM Diamond
                                             WHERE ItemID = @ii";
                cmdLoadTable.Parameters.AddWithValue("@ii", itemComboBox2.Text);

                SQLiteDataReader rdr = cmdLoadTable.ExecuteReader();

                while (rdr.Read())
                {
                    viewList2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                rdr.Close();
            }

#if DEBUG
            Console.WriteLine("ComparePage.cs: Diamond Table for item retrieved and displayed successfully.");
#endif
        }
    }
}
