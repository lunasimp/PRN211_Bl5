using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class CustomerActivities : UserControl
    {
        StoreContext dbContext;
        public CustomerActivities()
        {
            InitializeComponent();
            dbContext = new StoreContext();
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
                        ProductInfo = $"{product.ProductName} (ID = {product.ProductId})"
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
                string productInfo = Convert.ToString(selectedRow.Cells["ProductInfo"].Value);

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
                        cutomer => cutomer.ProductId,
                        product => product.ProductId,
                        (cutomer, product) => new
                        {
                            cutomer.CustomerId,
                            cutomer.CustomerName,
                            cutomer.Quantity,
                            cutomer.PurchaseDate,
                            ProductInfo = $"{product.ProductName} (ID = {product.ProductId})"
                        })
                    .Where(p => p.CustomerName.Contains(searchValue))
                    .ToList();

                dataGridView.DataSource = searchResults;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId;
                string customerName = txtCustomerName.Text.Trim();
                int productId;
                int quantity;
                DateTime purchaseDate;

                if (!int.TryParse(txtCustomerID.Text, out customerId))
                {
                    MessageBox.Show("Please enter a valid CustomerID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtProductId.Text, out productId))
                {
                    MessageBox.Show("Please enter a valid ProductId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!DateTime.TryParse(txtPurchaseDate.Text, out purchaseDate))
                {
                    MessageBox.Show("Please enter a valid purchase date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newCustomer = new Project.Models.Customer
                {
                    CustomerId = customerId,
                    CustomerName = customerName,
                    ProductId = productId,
                    PurchaseDate = purchaseDate,
                    Quantity = quantity
                };

                // add
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();

                MessageBox.Show("Customer added successfully!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFields();
                LoadAllCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the Customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerid = Convert.ToInt32(txtCustomerID.Text);
            string customerName = txtCustomerName.Text;
            DateTime purchasedate = Convert.ToDateTime(txtPurchaseDate.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            string productInfo = txtProductId.Text;

            var customerToUpdate = dbContext.Customers.FirstOrDefault(customer => customer.CustomerId == customerid);

            if (customerToUpdate != null)
            {
                customerToUpdate.CustomerId = customerid;
                customerToUpdate.CustomerName = customerName;
                customerToUpdate.Quantity = (int?)quantity;
                customerToUpdate.PurchaseDate = purchasedate;

                dbContext.SaveChanges();
                MessageBox.Show("Update successfully!");
                LoadAllCustomer();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Lay du lieu cua dong da dc chon
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // tim theo ProductID
                int selectedCustomerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);

                var customer = dbContext.Customers.Find(selectedCustomerId);

                if (customer != null)
                {
                    //Xoa
                    dbContext.Customers.Remove(customer);
                    dbContext.SaveChanges();
                    MessageBox.Show("Customer deleted successfully!", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllCustomer();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // bo loc tep tin
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportToFile(filePath);
            }
        }
        private void ExportToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("CustomerId\t,\tCustomerName\t,\tProductId\t,\tQuantity\t,\tPurchaseDate");
                    foreach (var cus in dbContext.Customers)
                    {
                        writer.WriteLine($"{cus.CustomerId}\t,\t{cus.CustomerName}\t,\t{cus.ProductId}\t,\t{cus.Quantity}\t,\t{cus.PurchaseDate}");
                    }
                }

                MessageBox.Show("Data saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the data: {ex.Message}");
            }
        }
    }
}
