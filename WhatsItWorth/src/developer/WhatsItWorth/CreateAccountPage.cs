// CreateAccountPage.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class CreateAccountPage : Form
    {
        // Shared SQLite connection used by this page.
        public SQLiteConnection DBConnection;
        private bool nameValid, emailValid, passValid, confirmValid;

        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private void CreateAccountPage_Load(object sender, EventArgs e)
        {
            // Hide the error label on initial load.
            incorrectLabel.Visible = false;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            // Only proceed if all fields have passed validation.
            if (nameValid && emailValid && passValid && confirmValid)
            {
                try
                {
                    // Prepare a parameterized INSERT to avoid SQL injection.
                    SQLiteCommand cmdAddUser = DBConnection.CreateCommand();
                    cmdAddUser.CommandText = @"INSERT INTO [User](User_email, User_name, User_pass, Num_of_Items, Total_Price, Date_Created)
                                               VALUES (@uemail, @uname, @upass, 0, 0.00, @date)";
                    cmdAddUser.Parameters.AddWithValue("@uemail", emailTextBox.Text);
                    cmdAddUser.Parameters.AddWithValue("@uname", nameTextBox.Text);

                    // Store encrypted password.
                    cmdAddUser.Parameters.AddWithValue("@upass", Encrypt_Decrypt.EncryptString(passwordTextBox.Text));

                    // Use UTC date for consistency across time zones.
                    cmdAddUser.Parameters.AddWithValue("@date", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));

                    incorrectLabel.Visible = false;

                    cmdAddUser.ExecuteNonQuery();

#if DEBUG
                    Console.WriteLine("CreateAccountPage.cs: User was created successfully.");
                    Console.WriteLine("CreateAccountPage -> LogInPage");
#endif

                    // Close this dialog with OK to indicate success to the caller.
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    incorrectLabel.Visible = true;
                }

            }
        }

        private void visibleButton_Click(object sender, EventArgs e)
        {
            // Show password characters.
            visibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = false;
            unvisibleButton.Visible = true;
        }

        private void unvisibleButton_Click(object sender, EventArgs e)
        {
            // Hide password characters.
            unvisibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = true;
            visibleButton.Visible = true;
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Require non-empty name.
            if (nameTextBox.Text == string.Empty)
            {
                errorProvider.SetError(nameTextBox, "Please Enter Name");
                nameValid = false;
            }
            else
            {
                errorProvider.SetError(nameTextBox, "");
                nameValid = true;
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            // Close the dialog (acts as a back action for the caller).
#if DEBUG
            Console.WriteLine("(Go Back) CreateAccountPage -> LogInPage");
#endif
            this.DialogResult = DialogResult.OK;
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Validate email is present and in correct format.
            if (emailTextBox.Text == string.Empty)
            {
                errorProvider.SetError(emailTextBox, "Please Enter User Email");
                emailValid = false;
            }
            else if (InputFormats.EmailValidation(emailTextBox.Text) != true)
            {
                errorProvider.SetError(emailTextBox, "Email format is not valid");
                emailValid = false;
            }
            else
            {
                errorProvider.SetError(emailTextBox, "");
                emailValid = true;
            }
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Enforce password complexity and minimum length.
            if (passwordTextBox.Text == string.Empty)
            {
                errorProvider.SetError(passwordTextBox, "Please Enter Password");
                passValid = false;
            }
            else if (InputFormats.PassValidation(passwordTextBox.Text) == 1)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain 1 upper case letter");
                passValid = false;
            }
            else if (InputFormats.PassValidation(passwordTextBox.Text) == 2)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain 1 lower case letter");
                passValid = false;
            }
            else if (InputFormats.PassValidation(passwordTextBox.Text) == 3)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain 1 special character");
                passValid = false;
            }
            else if (InputFormats.PassValidation(passwordTextBox.Text) == 4)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain 1 number");
                passValid = false;
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                errorProvider.SetError(passwordTextBox, "Password must have at least 8 characters");
                passValid = false;
            }
            else
            {
                errorProvider.SetError(passwordTextBox, "");
                passValid = true;
            }
        }

        private void confirmTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Confirm password matches exactly.
            if (confirmTextBox.Text == string.Empty)
            {
                errorProvider.SetError(confirmTextBox, "Please Confirm Password");
                confirmValid = false;
            }
            else if (!String.Equals(passwordTextBox.Text, confirmTextBox.Text))
            {
                errorProvider.SetError(confirmTextBox, "Password does not match");
                confirmValid = false;
            }
            else
            {
                errorProvider.SetError(confirmTextBox, "");
                confirmValid = true;
            }
        }

    }
}
