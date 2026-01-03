// DeleteItemConfirmation.cs by Ben Ebadinia

using System;
using System.Windows.Forms;

namespace WhatsItWorth
{
    public partial class DeleteItemConfirmation : Form
    {
        public DeleteItemConfirmation()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("DeleteItemConfirmation -> ViewItem");
#endif

            // Signal to the caller that the delete action was confirmed.
            this.DialogResult = DialogResult.Yes;
        }
    }
}
