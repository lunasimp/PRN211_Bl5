//using Shoe_Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoe_Store
{
    public partial class ResetPassword : Form
    {
        //StoreContext dbContext;
        public ResetPassword()
        {
            InitializeComponent();
            //dbContext = new StoreContext();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ////string email = txtMail.Text;

            ////// Check if the provided email exists in the database
            ////var user = dbContext.Accounts.FirstOrDefault(a => a.Email == email);

            //if (user != null)
            //{
            //    // Unlock the necessary fields and buttons
            //   txtNewPass.Enabled = true;
            //   txtConfirmPass.Enabled = true;
            //   btnSave.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid email. Please try again.", "Email Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var pass1 = txtNewPass.Text;
            //var pass2 = txtConfirmPass.Text;
            //string email = txtMail.Text;
            //if (pass1 == pass2)
            //{
            //    var user = dbContext.Accounts.FirstOrDefault(a => a.Email == email);
            //        user.Password = pass1;
            //        dbContext.SaveChanges(); // Save the changes to the database
            //        MessageBox.Show("Password changed successfully!", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close(); // Close the ResetPassword form
            //}
            //else { MessageBox.Show("Password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBack_Click(object sender, EventArgs e) => Close();
    }
}
