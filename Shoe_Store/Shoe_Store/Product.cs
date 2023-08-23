
using Shoe_Store.Models;
using System.Data;

namespace Shoe_Store
{
    public partial class Product : UserControl
    {
        private List<int> categoryIds = new List<int>(); // List of available category IDs
        private int currentCategoryIndex = 0; // Index of the current category ID being displayed

        StoreContext dbContext;
        public Product()
        {
            InitializeComponent();
            dbContext = new StoreContext();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            categoryIds = dbContext.Categories.Select(category => category.CategoryId).ToList();
            txtProductID.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                string productName = txtProductName.Text.Trim();
                decimal price = Convert.ToDecimal(txtPrice.Text);
                int inStock = Convert.ToInt32(txtInStock.Text);
                int categoryId = int.Parse(cbxCategoryId.SelectedValue.ToString()); ;

                // Create a new NES_Store.Models.Product entity and populate its properties
                var newProduct = new Shoe_Store.Models.Product
                {
                    ProductName = productName,
                    Price = price,
                    InStock = inStock,
                    CategoryId = categoryId
                };

                // Add the new product to the database using Entity Framework
                dbContext.Products.Add(newProduct);

                try
                {
                // Save the changes to the database
                dbContext.SaveChanges();

                // Show a success message to the user
                MessageBox.Show("Product added successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields after adding the product
                ClearInputFields();

                // Refresh the DataGridView to show the new product
                LoadAllProducts();
                }
                catch (Exception ex)
                {
                    // Handle any potential errors that may occur during the database operation
                    MessageBox.Show($"An error occurred while adding the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValid()
        {
            bool flag = true;
            string msg = "";
            if (txtProductName.Text.Length == 0)
            {
                flag = false;
                msg += "Product Name is required.\n";
            }

            if (txtPrice.Text.Length == 0)
            {
                flag = false;
                msg += "Price must be greater than 0.\n";
            }

            if (txtInStock.Text.Length == 0)
            {
                flag = false;
                msg += "In Stock must be greater than 0.\n";
            }

            if (flag == false)
            {
                MessageBox.Show(msg);
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {
                if (MessageBox.Show("Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridView.SelectedRows.Count > 0)
                    {
                        int selectedProductId = Convert.ToInt32(txtProductID.Text);

                        var product = dbContext.Products.Find(selectedProductId);

                        if (product != null)
                        {
                            // Remove the product from the database
                            dbContext.Products.Remove(product);
                            dbContext.SaveChanges();

                            // Show a success message to the user
                            MessageBox.Show("Product deleted successfully!", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView after deleting the product
                            LoadAllProducts();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a product id.", "Choose Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllProducts();
            ClearInputFields();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files|*.txt|All Files|*.*"; // Bộ lọc file chỉ hiển thị file .txt
                saveDialog.Title = "Save Text File";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    // Get the data to export from the DataGridView
                    var dataToExport = dataGridView.Rows.Cast<DataGridViewRow>()
                    .Select(row => string.Join(" - ", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value.ToString())))
                    .ToList();

                    // Write the data to the text file
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var line in dataToExport)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    // Show a success message to the user
                    MessageBox.Show($"Data exported to {filePath}", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any potential errors that may occur during the file export
                MessageBox.Show($"An error occurred while exporting the data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchValue))
            {
                // If the search value is empty or null, load all products
                LoadAllProducts();
            }
            else
            {
                // Search for products based on the search value
                var productsWithCategoryNames = dbContext.Products
                    .Join(dbContext.Categories,
                        product => product.CategoryId,
                        category => category.CategoryId,
                        (product, category) => new
                        {
                            product.ProductId,
                            product.ProductName,
                            product.Price,
                            product.InStock,
                            CategoryInfo = $"{category.CategoryName} (ID = {category.CategoryId})"
                        }).ToList();
                var filteredProducts = productsWithCategoryNames
                    .Where(p =>
                        p.ProductName.ToLower().Contains(searchValue) ||
                        p.CategoryInfo.ToLower().Contains(searchValue))
                    .ToList();

                dataGridView.DataSource = filteredProducts;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int selectedProductID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ProductId"].Value);
                    var product = dbContext.Products.Find(selectedProductID);

                    if (product != null)
                    {
                        // Update the properties of the product with the values from the input fields
                        product.ProductName = txtProductName.Text;
                        product.Price = decimal.Parse(txtPrice.Text);
                        product.InStock = Convert.ToInt32(txtInStock.Text);
                        product.CategoryId = int.Parse(cbxCategoryId.SelectedValue.ToString());

                        dbContext.SaveChanges();

                        MessageBox.Show("Product updated successfully!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a product id.", "Choose Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadAllProducts()
        {
            var productsWithCategoryNames = dbContext.Products
                .Join(dbContext.Categories,
                    product => product.CategoryId,
                    category => category.CategoryId,
                    (product, category) => new
                    {
                        product.ProductId,
                        product.ProductName,
                        product.Price,
                        product.InStock,
                        CategoryInfo = $"{category.CategoryName} (ID = {category.CategoryId})"
                    })
                .ToList();

            dataGridView.DataSource = productsWithCategoryNames;
            cbxCategoryId.DataSource = dbContext.Categories.ToList();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";
        }
        private void ClearInputFields()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtInStock.Clear();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Check if there are available category IDs
            if (categoryIds.Count > 0)
            {
                // Increment the index to move to the next category ID
                currentCategoryIndex++;
                // If the index exceeds the list length, loop back to the beginning
                if (currentCategoryIndex >= categoryIds.Count)
                {
                    currentCategoryIndex = 0;
                }

                // Get the current category ID from the list based on the index
                int selectedCategoryId = categoryIds[currentCategoryIndex];

                //// Filter products by the current category ID
                var productsWithCategoryNames = dbContext.Products
                    .Join(dbContext.Categories,
                        product => product.CategoryId,
                        category => category.CategoryId,
                        (product, category) => new
                        {
                            product.ProductId,
                            product.ProductName,
                            product.Price,
                            product.InStock,
                            product.CategoryId,
                            CategoryInfo = $"{category.CategoryName} (ID = {category.CategoryId})"
                        })
                    .Where(p => p.CategoryId == selectedCategoryId)
                    .ToList();

                dataGridView.DataSource = productsWithCategoryNames;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count && e.ColumnIndex >= 0)
            {
                txtProductID.Enabled = false;
                var productId = dataGridView.Rows[e.RowIndex].Cells["ProductId"].Value.ToString();
                var productName = dataGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                var price = dataGridView.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                var inStock = dataGridView.Rows[e.RowIndex].Cells["InStock"].Value.ToString();
                var category = dataGridView.Rows[e.RowIndex].Cells["CategoryInfo"].Value.ToString();
                if (category.Length >= 9) // Kiểm tra xem chuỗi có ít nhất 7 ký tự
                {
                    category = category.Substring(0, category.Length - 9); // Cắt bỏ 7 ký tự cuối
                }

                //binding du lieu tu dgvEmployees voi cbCity
                var selectCategory = cbxCategoryId.Items.Cast<Models.Category>().FirstOrDefault(c => c.CategoryName.Equals(category));
                if (selectCategory != null)
                {
                    cbxCategoryId.SelectedItem = selectCategory;
                }
                txtProductID.Text = productId;
                txtProductName.Text = productName;
                txtPrice.Text = price;
                txtInStock.Text = inStock;
                cbxCategoryId.SelectedItem = category;
            }
        }
    }
}

