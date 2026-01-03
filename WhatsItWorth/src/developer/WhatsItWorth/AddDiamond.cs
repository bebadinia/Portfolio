// AddDiamond.cs by Ben Ebadinia

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class AddDiamond : Form
    {
        // Semi-colon string representation of diamond data: Cut;Color;Clarity;CaratWeight
        public String DiamondString;

        // Validation flags for user selections.
        private bool cutValid, colorValid, clarityValid;

        // Helper to retrieve pricing; provided by the caller.
        public ItemPricing newItem;

        public AddDiamond()
        {
            InitializeComponent();
        }

        private void addDiamondButton_Click(object sender, EventArgs e)
        {
            // Ensure selections are valid before attempting price lookup.
            if (cutValid && colorValid && clarityValid)
            {

                try
                {
                    // Validate that the diamond combination exists and has a price.
                    if (newItem.getDiamondPrice(cutComboBox.Text, colorComboBox.Text, clarityComboBox.Text, weightSpinner.Text) == true)
                    {
                        // Build the data string to pass back to the parent form.
                        DiamondString = cutComboBox.Text + ";" + colorComboBox.Text + ";" + clarityComboBox.Text + ";" + weightSpinner.Text;

#if DEBUG
                        Console.WriteLine("AddDiamond.cs: Diamond was succesfully found.");
                        Console.WriteLine("AddDiamond -> AddItemPage");
#endif

                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        // Show error when price lookup fails.
                        incorrectLabel.Visible = true;
                    }
                }
                catch
                {
                    // Generic error on price lookup.
                    incorrectLabel.Visible = true;
                }

            }
            else
            {
                // Trigger validations to show error messages.
                CancelEventArgs ex = new CancelEventArgs();
                cutComboBox_Validating(sender, ex);
                colorComboBox_Validating(sender, ex);
                clarityComboBox_Validating(sender, ex);

            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("(Go Back) AddDiamond -> AddItemPage");
#endif

            // Close dialog without adding a diamond.
            this.DialogResult = DialogResult.OK;
        }

        private void cutComboBox_Validating(object sender, CancelEventArgs e)
        {
            // Require a cut selection.
            if (cutComboBox.Text == string.Empty)
            {
                errorProvider.SetError(cutComboBox, "Please Select Cut");
                cutValid = false;
            }
            else
            {
                errorProvider.SetError(cutComboBox, "");
                cutValid = true;
            }
        }

        private void colorComboBox_Validating(object sender, CancelEventArgs e)
        {
            // Require a color selection.
            if (colorComboBox.Text == string.Empty)
            {
                errorProvider.SetError(colorComboBox, "Please Select Color");
                colorValid = false;
            }
            else
            {
                errorProvider.SetError(colorComboBox, "");
                colorValid = true;
            }
        }

        private void clarityComboBox_Validating(object sender, CancelEventArgs e)
        {
            // Require a clarity selection.
            if (clarityComboBox.Text == string.Empty)
            {
                errorProvider.SetError(clarityComboBox, "Please Select Clarity");
                clarityValid = false;
            }
            else
            {
                errorProvider.SetError(clarityComboBox, "");
                clarityValid = true;
            }
        }

    }
}
