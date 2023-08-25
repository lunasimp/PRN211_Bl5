using Shoe_Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Provider;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoe_Store
{
    public partial class Provider : UserControl
    {
        StoreContext dbContext;
        public Provider()
        {
            InitializeComponent();
            dbContext = new StoreContext();
            LoadAllProvider();
        }

        private void Provider_Load(object sender, EventArgs e)
        {
            LoadAllProvider();
            txtProviderID.Enabled = false;
        }

        private void LoadAllProvider()
        {
            var lprovider = dbContext.Providers
                .Join(dbContext.Products,
                    provider => provider.ProductId,
                    product => product.ProductId,
                    (provider, product) => new
                    {
                        provider.ProviderId,
                        provider.ProviderName,
                        provider.ProvideDate,
                        provider.Quantity,
                        product.ProductName
                    })
                .ToList();

            dataGridView.DataSource = lprovider;
            cbxProduct.DataSource = dbContext.Products.ToList();
            cbxProduct.ValueMember = "ProductId";
            cbxProduct.DisplayMember = "ProductName";
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                int providerid = Convert.ToInt32(selectedRow.Cells["ProviderId"].Value);
                string providerName = Convert.ToString(selectedRow.Cells["ProviderName"].Value);
                DateTime providerDate = Convert.ToDateTime(selectedRow.Cells["ProvideDate"].Value); // Corrected column name
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                string providerInfo = Convert.ToString(selectedRow.Cells["ProductName"].Value);

                var selectCategory = cbxProduct.Items.Cast<Models.Product>().FirstOrDefault(c => c.ProductName.Equals(providerInfo));
                if (selectCategory != null)
                {
                    cbxProduct.SelectedItem = selectCategory;
                }

                txtProviderID.Text = providerid.ToString();
                txtProviderName.Text = providerName.ToString();
                txtQuantity.Text = quantity.ToString();
                cbxProduct.SelectedItem = providerInfo;
                txtProviderDate.Text = providerDate.ToString("MM-dd-yyyy");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllProvider();
            ClearInputFields();
            txtProviderID.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                /*int providerid;*/
                string providerName = txtProviderName.Text.Trim();
                int quantity;
                int productid = int.Parse(cbxProduct.SelectedValue.ToString());
                DateTime providerDates; // Declare providerDates here

                /*if (!int.TryParse(txtProviderID.Text, out providerid))
                {
                    MessageBox.Show("Please enter a valid ProviderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (quantity > 0)
                {
                    string providerDate = txtProviderDate.Text.Trim();

                    if (DateTime.TryParse(providerDate, out providerDates))
                    {
                        if (providerDates <= DateTime.Now)

                        {
                            var newProvider = new Shoe_Store.Models.Provider
                            {
                                /*ProviderId = providerid,*/
                                ProviderName = providerName,
                                Quantity = quantity,
                                ProvideDate = providerDates,
                                ProductId = productid,
                            };
                            // add
                            dbContext.Providers.Add(newProvider);
                            dbContext.SaveChanges();
                            MessageBox.Show("Product added successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputFields();
                            LoadAllProvider();

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
                else
                {
                    MessageBox.Show("Please enter Quantity > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*if (!int.TryParse(txtProductId.Text, out productid))
                {
                    MessageBox.Show("Please enter a valid ProductId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the Provider: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int CalculateTotalQuantity(int productId)
        {
            var totalQuantity = dbContext.Providers
                .Where(p => p.ProductId == productId)
                .Sum(p => p.Quantity);
            var minusQuantity = dbContext.Customers
                .Where(p => p.ProductId == productId)
                .Sum(p => p.Quantity);
            return (int)totalQuantity - (int)minusQuantity;
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
        private void ClearInputFields()
        {
            txtProviderID.Clear();
            txtProviderName.Clear();
            txtQuantity.Clear();
            txtProviderDate.Clear();
            /*txtProductId.Clear();*/
        }

        private void Provider_Load_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProviderID.Text != "")
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int selectedProviderID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["providerid"].Value);
                    var provider = dbContext.Providers.Find(selectedProviderID);

                    string providerName = txtProviderName.Text.Trim();
                    int quantity;
                    int productid = int.Parse(cbxProduct.SelectedValue.ToString());
                    DateTime providerDates; // Declare providerDates here

                    if (!int.TryParse(txtQuantity.Text, out quantity))
                    {
                        MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (quantity > 0)
                    {
                        string providerDate = txtProviderDate.Text.Trim();
                        if (DateTime.TryParse(providerDate, out providerDates))
                        {
                            if (provider != null)
                            {
                                if (DateTime.TryParse(providerDate, out providerDates))
                                {
                                    if (providerDates <= DateTime.Now)

                                    {
                                        // Update the properties of the product with the values from the input fields
                                        provider.ProviderName = providerName;
                                        provider.Quantity = quantity;
                                        provider.ProvideDate = providerDates;
                                        provider.ProductId = productid;

                                        dbContext.SaveChanges();

                                        MessageBox.Show("Provider updated successfully!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearInputFields();
                                        LoadAllProvider();

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
                    else
                    {
                        MessageBox.Show("Please enter Quantity > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Choose Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please choose a product id.", "Choose Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
