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
        }

        private void CustomerActivities_Load(object sender, EventArgs e)
        {
            LoadAllCustomer();
            txtCustomerID.Enabled = false;
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
                        product.ProductName
                    })
                .ToList();

            dataGridView.DataSource = lcustomer;
            cbxProduct.DataSource = dbContext.Products.ToList();
            cbxProduct.ValueMember = "ProductId";
            cbxProduct.DisplayMember = "ProductName";
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
                string productInfo = Convert.ToString(selectedRow.Cells["ProductName"].Value);

                var selectCategory = cbxProduct.Items.Cast<Models.Product>().FirstOrDefault(c => c.ProductName.Equals(productInfo));
                if (selectCategory != null)
                {
                    cbxProduct.SelectedItem = selectCategory;
                }

                txtCustomerID.Text = customerId.ToString();
                txtCustomerName.Text = customerName.ToString();
                txtPurchaseDate.Text = purchaseDate.ToString("MM-dd-yyyy");
                txtQuantity.Text = quantity.ToString();
                cbxProduct.SelectedItem = productInfo;
            }
        }
        private void ClearInputFields()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtQuantity.Clear();
            txtPurchaseDate.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllCustomer();
            ClearInputFields();
            txtCustomerID.Enabled = false;
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
                /*int customerId;*/
                string customerName = txtCustomerName.Text.Trim();
                int productId = int.Parse(cbxProduct.SelectedValue.ToString()); ;
                int quantity;
                DateTime purchaseDate;
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!DateTime.TryParse(txtPurchaseDate.Text, out purchaseDate))
                {
                    MessageBox.Show("Please enter a valid purchase date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (quantity > 0)
                {
                    /*int totalQuantity = CalculateTotalQuantity(productId);
                    if (totalQuantity < 0)
                    {
                        MessageBox.Show($"Out of stock, in stock have: {Convert.ToString(totalQuantity + quantity)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {*/
                    var newCustomer = new Shoe_Store.Models.Customer
                    {
                        /*CustomerId = customerId,*/
                        CustomerName = customerName,
                        ProductId = productId,
                        PurchaseDate = purchaseDate,
                        Quantity = quantity
                    };

                    dbContext.Customers.Add(newCustomer);
                    dbContext.SaveChanges();

                    int totalQuantity = CalculateTotalQuantity(productId);
                    UpdateInStock(productId, totalQuantity);
                    MessageBox.Show("Customer added successfully!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    LoadAllCustomer();
                    /*}*/
                }
                else
                {
                    MessageBox.Show("Please enter Quantity > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the Customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text != "")
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int selectedCustomerID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["customerid"].Value);
                    var customer = dbContext.Customers.Find(selectedCustomerID);

                    string customerName = txtCustomerName.Text.Trim();
                    int quantity;
                    int productid = int.Parse(cbxProduct.SelectedValue.ToString());
                    DateTime purchaseDates; // Declare providerDates here

                    if (!int.TryParse(txtQuantity.Text, out quantity))
                    {
                        MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string providerDate = txtPurchaseDate.Text.Trim();
                    if (DateTime.TryParse(providerDate, out purchaseDates))
                    {
                        if (customer != null)
                        {
                            if (DateTime.TryParse(providerDate, out purchaseDates))
                            {
                                if (purchaseDates <= DateTime.Now)

                                {
                                    // Update the properties of the product with the values from the input fields
                                    customer.CustomerName = customerName;
                                    customer.Quantity = quantity;
                                    customer.PurchaseDate = purchaseDates;
                                    customer.ProductId = int.Parse(cbxProduct.SelectedValue.ToString());

                                    dbContext.SaveChanges();

                                    MessageBox.Show("Provider updated successfully!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearInputFields();
                                    LoadAllCustomer();

                                    int totalQuantity = CalculateTotalQuantity(productid);
                                    UpdateInStock(productid, totalQuantity);
                                }
                                else
                                {
                                    MessageBox.Show("Please input date less than current.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please choose a product id.", "Choose Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private int CalculateTotalQuantity(int productId)
        {
            var totalQuantity = dbContext.Providers
                .Where(p => p.ProductId == productId)
                .Sum(p => p.Quantity);
            var totalPurchase = dbContext.Customers
                .Where(p => p.ProductId == productId)
                .Sum(p => p.Quantity);

            return (int)totalQuantity - (int)totalPurchase;
        }

        private void UpdateInStock(int productID, int quantity)
        {
            var product = dbContext.Products.Find(productID);
            if (product != null)
            {
                product.InStock = quantity;
                dbContext.SaveChanges();
            }
        }

        /*private void btnDelete_Click(object sender, EventArgs e)
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
		}*/

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
