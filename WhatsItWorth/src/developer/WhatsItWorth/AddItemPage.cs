// AddItemPage.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class AddItemPage : Form
    {
        // SQLite connection provided by the caller. Must be open/valid before using this form.
        public SQLiteConnection DBConnection;

        // The current user's ID to associate new items with.
        public int userIdentification;

        // Validation flags for metal type and purity.
        private bool typeValid, purityValid;

        // Tracks the next Diamond ID to assign as entries are added.
        private string newestID = "";

        // Temporary ItemID built during creation (with suffix A/B based on diamonds).
        private string tempItemID = "";

        // Path to selected photo for the item.
        private string photoPath = "";

        // Helper object that encapsulates item and diamond creation/pricing logic.
        ItemPricing newItem = new ItemPricing();

        public AddItemPage(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }

        private void AddItemPage_Load(object sender, EventArgs e)
        {
            // Initialize the next IDs and bind connection/context to pricing helper.
            getNewItemID();
            getMaxDiamondID();

            newItem.DBConnection = DBConnection;
            newItem.userIdentification = userIdentification;
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            // Ensure required fields are valid before proceeding.
            if (typeValid && purityValid)
            {
                addItemInfo();
            }
            else
            {
                // Trigger validations to show errors.
                CancelEventArgs ex = new CancelEventArgs();
                typeComboBox_Validating(sender, ex);
                purityComboBox_Validating(sender, ex);
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) AddItemPage -> HomePage");
#endif

            // Close and return to the previous page.
            this.DialogResult = DialogResult.OK;

        }

        private void addDiamondButton_Click(object sender, EventArgs e)
        {
            // Open diamond entry dialog and add the result to the grid if confirmed.
            AddDiamond addDiamondForm = new AddDiamond();
            addDiamondForm.newItem = newItem;
            addDiamondForm.ShowDialog();

#if DEBUG
            Console.WriteLine("AddItemPage -> AddDiamond");
#endif

            if (addDiamondForm.DialogResult == DialogResult.Yes)
            {
                diamondLabel.Visible = true;
                viewList.Visible = true;

                string[] rowData = addDiamondForm.DiamondString.Split(';');
                viewList.Rows.Add(rowData);
            }

#if DEBUG
            Console.WriteLine("AddItemPage.cs: Diamond added to table succesfully.");
#endif
        }


        private void typeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // Purity selection only applies to Gold.
            if (String.Equals(typeComboBox.Text, "Gold"))
            {
                purityLabel.Visible = true;
                purityComboBox.Visible = true;
            }
            else
            {
                purityLabel.Visible = false;
                purityComboBox.Visible = false;
            }
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            // Allow user to select an image file for the item and preview it.
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var selectedImage = Image.FromFile(dialog.FileName);
                    pictureBox.Image = selectedImage;
                    pictureBox.Visible = true;

                    photoPath = dialog.FileName.Trim();
                }
            }

        }

        private void viewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = 4;

            if (e.ColumnIndex == columnIndex)
            {
                // If the user presses this button, then delete row
                viewList.Rows.RemoveAt(e.RowIndex);
            }

#if DEBUG
            Console.WriteLine("AddItemPage.cs: Diamond removed from table successfully.");
#endif

            if (!(viewList.Rows.Count > 0))
            {
                diamondLabel.Visible = false;
                viewList.Visible = false;
            }
        }

        private void getMaxDiamondID()
        {
            try
            {
                int maxNum = 0;

                SQLiteCommand cmdGetMaxDiamondID = DBConnection.CreateCommand();

                cmdGetMaxDiamondID.CommandText = @"SELECT Diamond_ID
                                                   FROM Diamond";

                SQLiteDataReader rdr = cmdGetMaxDiamondID.ExecuteReader();


                while (rdr.Read())
                {
                    String maxString = rdr[0].ToString();
                    maxString = maxString.Remove(maxString.Length - 1);

                    if (int.Parse(maxString) > maxNum)
                    {
                        maxNum = int.Parse(maxString);
                    }
                }

                rdr.Close();

                String newString = (maxNum + 1).ToString() + 'D';

                newestID = newString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getNewItemID()
        {
            try
            {
                int maxNum = 0;

                SQLiteCommand getNewItemID = DBConnection.CreateCommand();

                getNewItemID.CommandText = @"SELECT ItemID
                                             FROM Item";

                SQLiteDataReader rdr = getNewItemID.ExecuteReader();

                // Iterate all rows and determine the maximum numeric portion of ItemID.
                while (rdr.Read())
                {
                    String maxString = rdr[0].ToString();
                    if (!string.IsNullOrEmpty(maxString))
                    {
                        maxString = maxString.Remove(maxString.Length - 1);
                        if (int.TryParse(maxString, out var idVal) && idVal > maxNum)
                        {
                            maxNum = idVal;
                        }
                    }
                }

                rdr.Close();

                tempItemID = (maxNum + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addItemInfo()
        {
            // Compose item attributes and persist via ItemPricing helper.
            int itemMetal;
            int goldPurity = 0;

            if (viewList.Rows.Count > 0)
            {
                tempItemID = tempItemID + 'B';
            }
            else
            {
                tempItemID = tempItemID + 'A';
            }

            // Map metal type selection to stored code.
            if (String.Equals(typeComboBox.Text, "Gold"))
            {
                itemMetal = 1;
                string purityString = purityComboBox.Text;
                purityString = purityString.Remove(purityString.Length - 1);
                goldPurity = Int32.Parse(purityString);
            }
            else if (String.Equals(typeComboBox.Text, "Silver"))
            {
                itemMetal = 2;
            }
            else
            {
                itemMetal = 3; // Platinum or other.
            }

            if (String.Equals(descriptionTextBox.Text, "Enter Item Description"))
            {
                descriptionTextBox.Text = "";
            }

            if (viewList.Rows.Count > 0)
            {
                newItem.createItem(tempItemID, itemMetal, goldPurity, Decimal.ToDouble(weightSpinner.Value), descriptionTextBox.Text.Trim(), photoPath, true);
            }
            else
            {
                newItem.createItem(tempItemID, itemMetal, goldPurity, Decimal.ToDouble(weightSpinner.Value), descriptionTextBox.Text.Trim(), photoPath, false);
            }
#if DEBUG
            Console.WriteLine("AddItemPage.cs: Item (ID: " + tempItemID + ") successfully created.");
#endif

            // Add Each Diamond
            if (viewList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in viewList.Rows)
                {
                    // Persist diamond attributes for each row in the grid.
                    newItem.createDiamond(newestID, tempItemID, row.Cells[0].Value.ToString().Trim(), row.Cells[1].Value.ToString().Trim(), row.Cells[2].Value.ToString().Trim(), double.Parse(row.Cells[3].Value.ToString()));

#if DEBUG
                    Console.WriteLine("AddItemPage.cs: Diamond (ID: " + newestID + ") successfully created.");
#endif

                    incrementID();
                }

            }
            else
            {
                diamondLabel.Visible = false;
                viewList.Visible = false;
            }

        //Updating Item and User
        newItem.updateNewItem(tempItemID);

#if DEBUG
            Console.WriteLine("AddItemPage.cs: Item (ID: " + tempItemID + ") and User (ID: " + userIdentification + ") successfully updated.");
            Console.WriteLine("AddItemPage -> HomePage");
#endif

            this.DialogResult = DialogResult.OK;
        }

        private void incrementID()
        {
            // Increment the diamond ID numeric portion and re-append the 'D' suffix.
            int maxNum = 0;
            string maxString = newestID.Remove(newestID.Length - 1);
            maxNum = int.Parse(maxString);
            newestID = (maxNum + 1).ToString() + 'D';
        }

        private void purityComboBox_Validating(object sender, CancelEventArgs e)
        {
            // Validate that purity is selected when applicable (Gold only).
            if (purityLabel.Visible == true)
            {
                if (purityComboBox.Text == string.Empty)
                {
                    errorProvider.SetError(purityComboBox, "Please Select Metal Purity");
                    purityValid = false;
                }
                else
                {
                    errorProvider.SetError(purityComboBox, "");
                    purityValid = true;
                }
            }
        }

        private void typeComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (typeComboBox.Text == string.Empty)
            {
                errorProvider.SetError(typeComboBox, "Please Select Metal Type");
                typeValid = false;
            }
            else
            {
                errorProvider.SetError(typeComboBox, "");
                typeValid = true;

                if (String.Equals(typeComboBox.Text, "Silver") || String.Equals(typeComboBox.Text, "Platinum"))
                {
                    purityValid = true;
                }
            }
        }
    }
}
