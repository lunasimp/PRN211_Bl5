
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int inStock = Convert.ToInt32(txtInStock.Text);
            int categoryId = Convert.ToInt32(txtCategoryId.Text);

            //Create a new Shoe_Store.Models.Product entity and populate its properties
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedProductId = Convert.ToInt32(txtCategoryId.Text);

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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllProducts();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine("D:/Demo/NES Store/", "Logs", "ProductData.txt");

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

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
            catch (Exception ex)
            {
                // Handle any potential errors that may occur during the file export
                MessageBox.Show($"An error occurred while exporting the data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

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
                            CategoryInfo = $"{category.CategoryName} ({category.CategoryId})"
                        })
                    .Where(p =>
                        p.ProductName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                        p.CategoryInfo.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                dataGridView.DataSource = productsWithCategoryNames;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedProductID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ProductId"].Value);
                var product = dbContext.Products.Find(selectedProductID);

                if (product != null)
                {
                    // Update the properties of the product with the values from the input fields
                    product.ProductName = txtProductName.Text;
                    product.Price = Convert.ToDecimal(txtPrice.Text);
                    product.InStock = Convert.ToInt32(txtInStock.Text);
                    product.CategoryId = Convert.ToInt32(txtCategoryId.Text);

                    dbContext.SaveChanges();

                    MessageBox.Show("Product updated successfully!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllProducts();
                }
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
        }
        private void ClearInputFields()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtInStock.Clear();
            txtCategoryId.Clear();
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
    }
}
