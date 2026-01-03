// GenerateReportPage.cs by Ben Ebadinia

using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class GenerateReportPage : Form
    {
        // Shared SQLite connection used by this page.
        public SQLiteConnection DBConnection;

        // Current user ID for filtering report data.
        public int userIdentification;

        public GenerateReportPage(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }

        private void GenerateReportPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Retrieve report data for the current user by joining User and Item tables.
                SQLiteCommand cmdLoadReport = DBConnection.CreateCommand();

                cmdLoadReport.CommandText = @"SELECT [User].UserID, [User].User_name, [User].Date_Created, [User].Num_of_Items, [User].Total_Price, Item.ItemID, Item.Description, Item.Original_Price, Item.Current_Price, Item.Current_Price - Item.Original_Price AS Growth
                                              FROM [User] INNER JOIN Item ON [User].UserID = Item.UserID
                                              WHERE [User].UserID = @ui";
                cmdLoadReport.Parameters.AddWithValue("@ui", userIdentification);

                // Load data into a DataTable for the report viewer.
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdLoadReport);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                // Bind the data to the ReportViewer control.
                ReportDataSource source = new ReportDataSource("ReportDataSet", dt);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();

#if DEBUG
                Console.WriteLine("GenerateReportPage.cs: User (ID: " + userIdentification + ") report succesfully loaded in.");
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) GenerateReportPage -> HomePage");
#endif

            // Close and return to previous page.
            this.DialogResult = DialogResult.OK;
        }

    }
}
