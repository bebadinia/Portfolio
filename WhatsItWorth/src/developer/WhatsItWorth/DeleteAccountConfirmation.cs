// DeleteAccountConfirmation.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class DeleteAccountConfirmation : Form
    {
        // SQLite connection and user ID required for credential verification.
        public SQLiteConnection DBConnection;
        public int userIdentification;
        private bool passValid;

        public DeleteAccountConfirmation(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Verify credentials before confirming account deletion.
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
                        Console.WriteLine("DeleteAccountConfirmation.cs: User (ID: " + userIdentification + ") has verified credentials.");
                        Console.WriteLine("DeleteAccountConfirmation -> ViewAccount");
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
                // Show validation messages and block delete.
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
                errorProvider.SetError(passwordTextBox, "Please Enter Password");
                passValid = false;
            }
            else
            {
                errorProvider.SetError(passwordTextBox, "");
                passValid = true;
            }
        }
    }
}
