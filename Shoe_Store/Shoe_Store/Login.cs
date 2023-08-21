using Microsoft.EntityFrameworkCore;
using Shoe_Store.Models;
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
    public partial class Login : Form
    {
        StoreContext dbContext;
        public Login()
        {
            InitializeComponent();
            dbContext = new StoreContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //Check if the provided credentials exist in the database
            var user = dbContext.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);

            if (user != null)
            {
                txtUsername.Clear();
                txtPassword.Clear();
                Main mainForm = new Main(this); // Pass the reference to the login form
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
