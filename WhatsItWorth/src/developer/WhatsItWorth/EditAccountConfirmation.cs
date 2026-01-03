// EditAccountConfirmation.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class EditAccountConfirmation : Form
    {
        // SQLite connection and user ID to validate credentials.
        public SQLiteConnection DBConnection;
        public int userIdentification;
        private bool passValid;

        public EditAccountConfirmation(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }
        private void verifyButton_Click(object sender, EventArgs e)
        {
            // Verify the user entered password matches the stored one before allowing edits.
            if (passValid)
            {
                SQLiteCommand cmdLoadPass = DBConnection.CreateCommand();

                cmdLoadPass.CommandText = @"SELECT User_pass
                                            FROM [User]
                                            WHERE UserID = @ui";
                cmdLoadPass.Parameters.AddWithValue("@ui", userIdentification);

                SQLiteDataReader rdr = cmdLoadPass.ExecuteReader();

                if (rdr.Read())
                {
                    // Compare decrypted stored password with the user input.
                    if (String.Equals(Encrypt_Decrypt.DecryptString(rdr[0].ToString().Trim()), passwordTextBox.Text))
                    {
#if DEBUG
                        Console.WriteLine("EditAccountConfirmation.cs: User (ID: " + userIdentification + ") has verified credentials.");
                        Console.WriteLine("EditAccountConfirmation -> ViewAccount");
#endif
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        incorrectLabel.Text = "Incorrect password. Please try again!";
                        incorrectLabel.Visible = true;
                    }
                }

                rdr.Close();
            }
            else
            {
                // Show validation messages and block verify.
                incorrectLabel.Text = "Please fix errors before trying again!";
                incorrectLabel.Visible = true;

                CancelEventArgs ex = new CancelEventArgs();
                passwordTextBox_Validating(sender, ex);
            }
        }

        private void visibleButton_Click(object sender, EventArgs e)
        {
            // Toggle password visibility on.
            visibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = false;
            unvisibleButton.Visible = true;
        }

        private void unvisibleButton_Click(object sender, EventArgs e)
        {
            // Toggle password visibility off.
            unvisibleButton.Visible = false;
            passwordTextBox.UseSystemPasswordChar = true;
            visibleButton.Visible = true;
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Require a password entry.
            if (passwordTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(passwordTextBox, "Please Enter Password");
                passValid = false;
            }
            else
            {
                errorProvider1.SetError(passwordTextBox, "");
                passValid = true;
            }
        }
    }
}
