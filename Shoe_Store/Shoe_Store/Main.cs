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
    public partial class Main : Form
    {
        private Login login;
        public Main(Login login)
        {
            InitializeComponent();
            this.login = login;
        }
        private Product productControl;
        private Category categoryControl;
        private Provider providerControl;
        private CustomerActivities customerActivitiesControl;   
        private void tsbProduct_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(productControl))
            {
                productControl = new Product();
                productControl.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(productControl);
            }
            productControl.BringToFront();
        }

        private void tsbCategory_Click(object sender, EventArgs e)
        {
            if (categoryControl == null)
            {
                categoryControl = new Category();
                categoryControl.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(categoryControl);
            }
            else
            {
                categoryControl.BringToFront();
            }
        }

        private void tsbProvider_Click(object sender, EventArgs e)
        {
			if (!mainPanel.Controls.Contains(providerControl))
			{
				providerControl = new Provider();
				providerControl.Dock = DockStyle.Fill;
				mainPanel.Controls.Add(providerControl);
			}
			else
			{
				providerControl.BringToFront();
			}
		}

        private void tsbCustomer_Click(object sender, EventArgs e)
        {
			if (!mainPanel.Controls.Contains(customerActivitiesControl))
			{
				customerActivitiesControl = new CustomerActivities();
				customerActivitiesControl.Dock = DockStyle.Fill;
				mainPanel.Controls.Add(customerActivitiesControl);
			}
			else
			{
				customerActivitiesControl.BringToFront();
			}
		}
        private void Main_Shown(object sender, EventArgs e)
        {
            tsbProduct.PerformClick();
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
    }
}
