// ViewAccount.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class ViewAccount : Form
    {
        // Shared SQLite connection used by this page.
        public SQLiteConnection DBConnection;

        // The current user ID for which the account details are displayed/edited.
        public int userIdentification;

        // Validation flags for name, email, and password fields.
        private bool nameValid, emailValid, passValid;

        public ViewAccount(int userID)
        {
            InitializeComponent();
            userIdentification = userID;
        }

        private void CreateAccountPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Load user account details for display.
                SQLiteCommand cmdLoadInfo = DBConnection.CreateCommand();

                cmdLoadInfo.CommandText = @"SELECT User_name, User_email, User_pass, Date_Created
                                            FROM [User]
                                            WHERE UserID = @ui";
                cmdLoadInfo.Parameters.AddWithValue("@ui", userIdentification);

                SQLiteDataReader rdr = cmdLoadInfo.ExecuteReader();

                if (rdr.Read())
                {
                    // Populate fields; decrypt password for editing display.
                    nameTextBox.Text = rdr[0].ToString().Trim();
                    emailTextBox.Text = rdr[1].ToString().Trim();

                    // NOTE: Storing passwords encrypted is reversible; prefer one-way hashing in production.
                    passwordTextBox.Text = Encrypt_Decrypt.DecryptString(rdr[2].ToString().Trim());
                    dateLabel.Text = String.Format("{0:D}", rdr[3]);
                }

                rdr.Close();

#if DEBUG
                Console.WriteLine("ViewAccount.cs: User (ID: " + userIdentification + ") information succesfully retrieved and displayed.");
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
            Console.WriteLine("(Go Back) ViewAccount -> HomePage");
#endif

            // Close dialog and return to previous page.
            this.DialogResult = DialogResult.OK;
        }

        private void editAccountButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("ViewAccount -> EditAccountConfirmation");
#endif
            // Ask the user to confirm identity (enter current password) before enabling edits.
            EditAccountConfirmation editAccountForm = new EditAccountConfirmation(userIdentification);
            editAccountForm.DBConnection = DBConnection;
            editAccountForm.ShowDialog();

            if (editAccountForm.DialogResult == DialogResult.Yes)
            {
                // Enable editing and show password format guidance.
                enableControls(true);
                formatLabel.Visible = true;

#if DEBUG
                Console.WriteLine("ViewAccount.cs: User (ID: " + userIdentification + ") information editing enabled.");
#endif
            }

        }

        private void enableControls(bool enable)
        {
            // Toggle editability and read-only state of fields and buttons.
            nameTextBox.ReadOnly = !enable;
            emailTextBox.ReadOnly = !enable;
            passwordTextBox.ReadOnly = !enable;

            nameTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            passwordTextBox.Enabled = enable;

            // Show/hide password characters based on edit mode.
            passwordTextBox.UseSystemPasswordChar = !enable;
            saveButton.Visible = enable;
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("ViewAccount -> DeleteAccountConfirmation");
#endif
            // Confirm deletion by re-authenticating the user.
            DeleteAccountConfirmation deleteForm = new DeleteAccountConfirmation(userIdentification);
            deleteForm.DBConnection = DBConnection;
            deleteForm.ShowDialog();

            if (deleteForm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    // Ensure foreign key constraints are active (e.g., cascading deletes).
                    using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", DBConnection))
                    {
                        pragmaCmd.ExecuteNonQuery();
                    }

                    // Remove the user account.
                    SQLiteCommand cmdDeleteUser = DBConnection.CreateCommand();
                    cmdDeleteUser.CommandText = @"DELETE FROM [User]
                                                  WHERE UserID = @id";
                    cmdDeleteUser.Parameters.AddWithValue("@id", userIdentification);
                    cmdDeleteUser.ExecuteNonQuery();

                    using (SQLiteCommand checkCmd = new SQLiteCommand("PRAGMA foreign_keys;", DBConnection))
                    {
                        var result = checkCmd.ExecuteScalar();
#if DEBUG
                        Console.WriteLine($"ViewAccount.cs: Foreign keys enabled: {result}");
#endif
                    }

#if DEBUG
                    Console.WriteLine("ViewAccount.cs: User (ID: " + userIdentification + ") succesfully deleted.");
                    Console.WriteLine("ViewAccount -> HomePage");
#endif

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.DialogResult = DialogResult.Yes;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Persist edits if all validations pass.
            if (nameValid && emailValid && passValid)
            {
                try
                {
                    // Update the account with edited fields; password is encrypted before storage.
                    SQLiteCommand cmdUpdateAccount = DBConnection.CreateCommand();
                    cmdUpdateAccount.CommandText =
                        @"UPDATE [User] SET User_name = @name, User_email = @email, User_pass = @pass
                          WHERE UserID = @ui";
                    cmdUpdateAccount.Parameters.AddWithValue("@name", nameTextBox.Text);
                    cmdUpdateAccount.Parameters.AddWithValue("@email", emailTextBox.Text);
                    cmdUpdateAccount.Parameters.AddWithValue("@pass", Encrypt_Decrypt.EncryptString(passwordTextBox.Text));
                    cmdUpdateAccount.Parameters.AddWithValue("@ui", userIdentification);

                    cmdUpdateAccount.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Return UI to read-only state.
                enableControls(false);
                formatLabel.Visible = false;

#if DEBUG
                Console.WriteLine("ViewAccount.cs: User (ID: " + userIdentification + ") information successfully updated.");
                Console.WriteLine("ViewAccount.cs: User (ID: " + userIdentification + ") information editing disabled.");
#endif

            }
            else
            {
                // Trigger validations to show error messages.
                CancelEventArgs ex = new CancelEventArgs();
                nameTextBox_Validating(sender, ex);
                emailTextBox_Validating(sender, ex);
                passwordTextBox_Validating(sender, ex);
            }

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

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Validate non-empty and format of email.
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
            // Enforce password presence and complexity requirements.
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
    }
}
