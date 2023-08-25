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
    public partial class Provider : UserControl
    {
        StoreContext dbContext;
        public Provider()
        {
            InitializeComponent();
            dbContext = new StoreContext();
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
                        ProductId = $"{product.ProductName} (ID = {product.ProductId})"
                    })
                .ToList();

            dataGridView.DataSource = lprovider;
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
                string providerInfo = Convert.ToString(selectedRow.Cells["ProductId"].Value);

                txtProviderID.Text = providerid.ToString();
                txtProviderName.Text = providerName.ToString();
                txtQuantity.Text = quantity.ToString();
                txtProductId.Text = providerInfo.ToString();
                txtProviderDate.Text = providerDate.ToString("dd-MM-yyyy");
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
                int productid;
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
                if (!int.TryParse(txtProductId.Text, out productid))
                {
                    MessageBox.Show("Please enter a valid ProductId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string providerDate = txtProviderDate.Text.Trim();

                if (DateTime.TryParse(providerDate, out providerDates))
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
                    MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            return (int)totalQuantity;
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
            txtProductId.Clear();
        }

        private void Provider_Load_1(object sender, EventArgs e)
        {

        }
    }
}
