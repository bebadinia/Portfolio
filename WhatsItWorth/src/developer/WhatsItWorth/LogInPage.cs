// LogInPage.cs by Ben Ebadinia

// Debug bypass: uncomment to skip authentication during development.
//#define BYPASS

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    // Provides the login UI and workflow for connecting to the SQLite database,
    // authenticating a user, and navigating to other pages in the application.
    public partial class LogInPage : Form
    {
        

        // Validation flags for the email (id) and password inputs.
        private bool idValid, passValid;

        // Shared SQLite connection used by this page and passed to other forms.
        private SQLiteConnection connection;


        // Path to the SQLite database. Uses a relative path to the project database during DEBUG builds and a path next to the executable for non-DEBUG (Release) builds.
        private static string dbPath =
#if DEBUG
            @"..\..\Database\testDatabase.db";      // project folder during dev
#else
            @"Database\testDatabase.db";            // next to the exe for your final zip
#endif

        // Initializes the form and its controls.
        public LogInPage()
        {
            InitializeComponent();

        }
        
        /// On load, establish a connection to the SQLite database and run the updater check.
        private void LogInPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize and open a connection to the SQLite database.
                connection = new SQLiteConnection($@"Data Source={dbPath};Version=3;");
                connection.Open();

#if DEBUG
                // Show a quick confirmation during development that the DB is reachable.
                MessageBox.Show(
                    "DB Connected: " + connection.FileName,
                    "What's It Worth?"
                );

                Console.WriteLine("Test Email: test@gmail.com");
                Console.WriteLine("Test Password: Pass1234$");
#endif

                // Perform application-specific update checks (e.g., data refresh).
                completeUpdater Updater = new completeUpdater();
                Updater.DBConnection = connection;
                Updater.checkDateFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // Handle login button click: validate credentials against the database, then navigate to the home page if successful.
        private void loginButton_Click(object sender, EventArgs e)
        {
            incorrectLabel.Visible = false;

            
            if (idValid && passValid)
            {
                try
                {
                    // Build a query to retrieve the user's hashed/encrypted password and ID by email.
                    // To Encrypt Password Manually: Console.WriteLine(Encrypt_Decrypt.EncryptString("pass5678"));

#if DEBUG && BYPASS
                    /* <-- Open
#endif
                    SQLiteCommand cmdCheckLogin = connection.CreateCommand();

                    cmdCheckLogin.CommandText = @"SELECT User_pass, UserID
                                                  FROM [User]
                                                  WHERE User_email = @email";

                    cmdCheckLogin.Parameters.AddWithValue("@email", emailTextBox.Text);

                    SQLiteDataReader rdr = cmdCheckLogin.ExecuteReader();

                    if (rdr.Read())
                    {
                        int userID = Convert.ToInt32(rdr[1]);

                        // To view/compare password manually during debugging:
                        // Console.WriteLine(passwordTextBox.Text.Equals(Encrypt_Decrypt.DecryptString(rdr[0].ToString().Trim())));

                        // Compare plaintext input to decrypted stored password.
                        if (passwordTextBox.Text.Equals(Encrypt_Decrypt.DecryptString(rdr[0].ToString().Trim())))
                        {
                            rdr.Close();
#if DEBUG && BYPASS
                            */ //<-- Close

                            //For testing purposes only: bypass login authentication
                            int userID = 1;
#endif
                            // Refresh time-sensitive data on successful login.
                            ItemPricing itemRefresh = new ItemPricing();
                            itemRefresh.DBConnection = connection;
                            itemRefresh.userIdentification = userID; 
                            itemRefresh.checkDate();

                            // Hide login form while the home page is open.
                            this.Hide();

#if DEBUG
                            Console.WriteLine("LogInPage.cs: User (ID: " + userID + ") is logging in successfully.");
                            Console.WriteLine("LogInPage -> HomePage");
#endif

                            // Launch the home page, passing the user ID and open DB connection.
                            HomePage homeForm = new HomePage(userID); 
                            homeForm.DBConnection = connection; // Pass the connection object
                            homeForm.ShowDialog();

                            // Clear fields after returning from the home page.
                            emailTextBox.Clear();
                            passwordTextBox.Clear();

                            // Re-open the login form after the home page closes, then close this instance.
                            LogInPage loginForm = new LogInPage();
                            loginForm.ShowDialog();
                            this.Close();

#if DEBUG && BYPASS
                            /* <-- Open
#endif

                        }
                        else
                        {
                            rdr.Close();

                            // Password mismatch: inform the user.
                            incorrectLabel.Text = "Incorrect password. Please try again!";
                            incorrectLabel.Visible = true;
                        }

                    }
                    else
                    {
                        rdr.Close();

                        // Email not found: inform the user.
                        incorrectLabel.Text = "Incorrect email. Please try again!";
                        incorrectLabel.Visible = true;
                    }
#if DEBUG && BYPASS
                    */ //<-- Close
#endif

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Inputs failed validation; prompt user and re-run validation to show errors.
                incorrectLabel.Text = "Please fix errors before trying again!";
                incorrectLabel.Visible = true;

                CancelEventArgs ex = new CancelEventArgs();
                emailTextBox_Validating(sender, ex);
                passwordTextBox_Validating(sender, ex);
            }
            
        }

        // Navigate to the account creation page, keeping the same DB connection.
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            // Reset any previous error messages.
            errorProvider.SetError(emailTextBox, "");
            errorProvider.SetError(passwordTextBox, "");
            incorrectLabel.Visible = false;
            this.Hide();

#if DEBUG
            Console.WriteLine("LogInPage -> CreateAccountPage");
#endif

            CreateAccountPage createForm = new CreateAccountPage();
            createForm.DBConnection = connection;
            createForm.ShowDialog();
            

            emailTextBox.Clear();
            passwordTextBox.Clear();

            // Return to the login form after account creation closes.
            this.Show();
        }

        // Show the password characters.
        private void visibleButton_Click(object sender, EventArgs e)
        {
            visibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = false;
            unvisibleButton.Visible = true;
        }

        // Hide the password characters.
        private void unvisibleButton_Click(object sender, EventArgs e)
        {
            unvisibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = true;
            visibleButton.Visible = true;
        }

        // Validate password input to ensure it is not empty.
        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            
            if (passwordTextBox.Text == string.Empty)
            {
                errorProvider.SetError(passwordTextBox, "Please Enter Password");
                passValid = false;
            }
            else
            {
                errorProvider.SetError(passwordTextBox, "");
                passValid = true;
            }
            
        }

        // Validate email input to ensure it has a value and matches email format.
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            
            if (emailTextBox.Text == string.Empty)
            {
                errorProvider.SetError(emailTextBox, "Please Enter User Email");
                idValid = false;
            }
            else if (InputFormats.EmailValidation(emailTextBox.Text) != true)
            {
                errorProvider.SetError(emailTextBox, "Email format is not valid");
                idValid = false;
            }
            else
            {
                errorProvider.SetError(emailTextBox, "");
                idValid = true;
            }
            
        } 
        
    }
}
