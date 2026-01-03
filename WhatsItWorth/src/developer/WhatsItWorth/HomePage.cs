// HomePage.cs by Ben Ebadinia

using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class HomePage : Form
    {
        // Shared SQLite connection used by this page.
        public SQLiteConnection DBConnection;

        // Current user ID used for filtering data and updates.
        public int userIdentification;

        public HomePage(int userID)
        {
            InitializeComponent();
            userIdentification = userID;

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            try
            {
                // Update number of items for this user.
                SQLiteCommand cmdUpdateCount = DBConnection.CreateCommand();
                cmdUpdateCount.CommandText = @"UPDATE [User]
                                               SET Num_of_Items = (SELECT COUNT(ItemID)
					                                           FROM Item
					                                           WHERE UserID = @ui)
                                               WHERE UserID = @ui";
                cmdUpdateCount.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
                cmdUpdateCount.ExecuteNonQuery();

                // Update total of current prices for this user's items.
                SQLiteCommand cmdUpdateSum = DBConnection.CreateCommand();
                cmdUpdateSum.CommandText = @"UPDATE [User]
                                             SET Total_Price =
                                             CASE
                                                 WHEN Num_of_Items > 0 THEN
                                                                   (SELECT SUM(Current_Price)
					                                               FROM Item
					                                               WHERE UserID = @ui)
                                                 ELSE 0.00
                                             END 
                                             WHERE UserID = @ui";
                cmdUpdateSum.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
                cmdUpdateSum.ExecuteNonQuery();

                // Load user summary info into text boxes.
                SQLiteCommand cmdLoadInfo = DBConnection.CreateCommand();
                cmdLoadInfo.CommandText = @"SELECT User_name, Total_Price, Num_of_Items
                                            FROM [User]
                                            WHERE userID = @ui";
                cmdLoadInfo.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));
                SQLiteDataReader rdr = cmdLoadInfo.ExecuteReader();
                if (rdr.Read())
                {
                    nameTextBox.Text = "Welcome, " + rdr[0].ToString();
                    totalValueTextBox.Text = String.Format("{0:C}", rdr[1]);
                    numItemsTextBox.Text = rdr[2].ToString();

                }
                rdr.Close();

#if DEBUG
                Console.WriteLine("HomePage.cs: User (ID: " + userIdentification + ") HomePage details successfully loaded.");
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                // Populate the grid of items for this user.
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling HomePageTable: " + ex.Message);
            }


            int columnIndex = 3;
            foreach (DataGridViewRow row in tableList.Rows)
            {
                double quantity;

                if (double.TryParse(row.Cells[columnIndex].Value.ToString(), out quantity))
                {
                    // Color growth (current - original) red/green/black.
                    if (quantity < 0)
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (quantity > 0)
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }

        }


        private void addItemButton_Click(object sender, EventArgs e)
        { 
            // Navigate to AddItemPage and then refresh HomePage when returning.
            this.Hide();
            
            AddItemPage addForm = new AddItemPage(userIdentification);
            addForm.DBConnection = DBConnection;
            addForm.ShowDialog();

#if DEBUG
            Console.WriteLine("HomePage -> AddItemPage");
#endif

            this.Close();
            HomePage homeForm = new HomePage(userIdentification);
            homeForm.DBConnection = DBConnection;
            homeForm.ShowDialog();
        }

        private void selectItemButton_Click(object sender, EventArgs e)
        {
            // Open selected item in ViewItem if a row is checked.
            incorrectLabel.Visible = false;
            var columnIndex = 0;

            foreach (DataGridViewRow row in tableList.Rows)
            {

                var isChecked = Convert.ToBoolean(row.Cells[columnIndex].Value);

                if (isChecked == true)
                {
                    incorrectLabel.Visible = false;
                    this.Hide();

                    ViewItem viewItemForm = new ViewItem(tableList.Rows[row.Index].Cells[4].Value.ToString());
                    viewItemForm.DBConnection = DBConnection;
                    viewItemForm.ShowDialog();

#if DEBUG
                    Console.WriteLine("HomePage -> ViewItem");
#endif

                    this.Close();
                    HomePage homeForm = new HomePage(userIdentification);
                    homeForm.DBConnection = DBConnection;
                    homeForm.ShowDialog();
                    
                    break;

                }
                else
                {
                    incorrectLabel.Visible = true;
                }
            }

        }

        private void yourProfileButton_Click(object sender, EventArgs e)
        {
            // Navigate to ViewAccount page and handle potential sign-out.
            this.Hide();
            
            ViewAccount userAccountForm = new ViewAccount(userIdentification);
            userAccountForm.DBConnection = DBConnection;
            userAccountForm.ShowDialog();

#if DEBUG
            Console.WriteLine("HomePage -> ViewAccount");
#endif

            if (userAccountForm.DialogResult == DialogResult.Yes)
            {
#if DEBUG
                Console.WriteLine("HomePage -> LogInPage");
#endif
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                // Refresh HomePage after returning from account view.
                this.Close();
                HomePage homeForm = new HomePage(userIdentification);
                homeForm.DBConnection = DBConnection;
                homeForm.ShowDialog();
            }
        }

        private void resourcesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create ProcessStartInfo with the URL
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://bebadinia.github.io",
                    UseShellExecute = true // Required for launching URLs in default browser
                };

                // Start the process
                Process.Start(psi);

#if DEBUG
                Console.WriteLine("HomePage -> Default Browser");
#endif
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Could not find a web browser to open the resources page. Please check your default browser settings.",
                    "Browser Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to open the resources page: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void compareItemsButton_Click(object sender, EventArgs e)
        {
            // Navigate to ComparePage and refresh HomePage when returning.
            this.Hide();

            ComparePage compareForm = new ComparePage(userIdentification); 
            compareForm.DBConnection = DBConnection;
            compareForm.ShowDialog();

#if DEBUG
            Console.WriteLine("HomePage -> ComparePage");
#endif

            this.Close();
            HomePage homeForm = new HomePage(userIdentification);
            homeForm.DBConnection = DBConnection;
            homeForm.ShowDialog();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) HomePage -> LogInPage");
#endif

            // Signal to caller to return to login page.
            this.DialogResult = DialogResult.OK;
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            // Navigate to GenerateReportPage and refresh HomePage when returning.
            this.Hide();

            GenerateReportPage reportForm = new GenerateReportPage(userIdentification);
            reportForm.DBConnection = DBConnection;
            reportForm.ShowDialog();

#if DEBUG
            Console.WriteLine("HomePage -> GenerateReportPage");
#endif

            this.Close();
            HomePage homeForm = new HomePage(userIdentification);
            homeForm.DBConnection = DBConnection;
            homeForm.ShowDialog();

        }

        private void tableList_ValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = 0;
            if (e.ColumnIndex == columnIndex)
            {
                // If the user checked this box, then uncheck all the other rows
                var isChecked = true; //(bool)tableList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (isChecked)
                {
                    foreach (DataGridViewRow row in tableList.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }

        private void tableList_Sorted(object sender, EventArgs e)
        {
            int columnIndex = 3;
            foreach (DataGridViewRow row in tableList.Rows)
            {
                double quantity;

                if (double.TryParse(row.Cells[columnIndex].Value.ToString(), out quantity))
                {
                    // Re-apply coloring after sort.
                    if (quantity < 0)
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (quantity > 0)
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        row.Cells[columnIndex].Style.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        private void LoadDataGridView()
        {
            // Clear existing rows
            tableList.Rows.Clear();

            SQLiteCommand cmdLoadTable = DBConnection.CreateCommand();

            cmdLoadTable.CommandText = @"SELECT Description, Current_Price, Current_Price - Original_Price, ItemID
                                         FROM Item
                                         WHERE UserID = @ui";
            cmdLoadTable.Parameters.AddWithValue("@ui", Convert.ToInt32(userIdentification));

            SQLiteDataReader rdr = cmdLoadTable.ExecuteReader();

            while (rdr.Read())
            {
                tableList.Rows.Add(false, rdr[0], rdr[1], rdr[2], rdr[3]);
            }

            rdr.Close();


        }
    }
}
