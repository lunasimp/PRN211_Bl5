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
    public partial class CustomerActivities : UserControl
    {
        StoreContext dbContext;
        public CustomerActivities()
        {
            InitializeComponent();
            dbContext = new StoreContext();
            LoadAllCustomer();
        }

        private void CustomerActivities_Load(object sender, EventArgs e)
        {
            LoadAllCustomer();
        }

        private void LoadAllCustomer()
        {
            var lcustomer = dbContext.Customers
                .Join(dbContext.Products,
                    customer => customer.ProductId,
                    product => product.ProductId,
                    (customer, product) => new
                    {
                        customer.CustomerId,
                        customer.CustomerName,
                        customer.PurchaseDate,
                        customer.Quantity,
                        ProductId = $"{product.ProductName} (ID = {product.ProductId})"
                    })
                .ToList();

            dataGridView.DataSource = lcustomer;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
                string customerName = Convert.ToString(selectedRow.Cells["CustomerName"].Value);
                DateTime purchaseDate = Convert.ToDateTime(selectedRow.Cells["PurchaseDate"].Value); // Corrected column name
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                string productInfo = Convert.ToString(selectedRow.Cells["ProductId"].Value);

                txtCustomerID.Text = customerId.ToString();
                txtCustomerName.Text = customerName.ToString();
                txtPurchaseDate.Text = purchaseDate.ToString("dd-MM-yyyy");
                txtQuantity.Text = quantity.ToString();
                txtProductId.Text = productInfo.ToString();
            }
        }
        private void ClearInputFields()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtQuantity.Clear();
            txtPurchaseDate.Clear();
            txtProductId.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllCustomer();
            ClearInputFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                //load toan bo du lieu
                LoadAllCustomer();
            }
            else
            {
                var searchResults = dbContext.Customers
                .Join(dbContext.Products,
                    customer => customer.ProductId,
                    product => product.ProductId,
                    (customer, product) => new
                    {
                        customer.CustomerId,
                        customer.CustomerName,
                        customer.PurchaseDate,
                        customer.Quantity,
                        ProductId = $"{product.ProductName} (ID = {product.ProductId})"
                    })
                .Where(c => c.ProductId.Contains(searchValue))
                .ToList();

                dataGridView.DataSource = searchResults;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
