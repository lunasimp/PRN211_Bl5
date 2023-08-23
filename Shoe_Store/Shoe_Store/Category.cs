using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shoe_Store;
namespace Shoe_Store
{
    public partial class Category : UserControl
    {
        private string connectionString = "server =IAMSU; database =Store;uid=sa;pwd=sa@123456;TrustServerCertificate=true;Integrated Security = true"; 

        public Category()
        {
            InitializeComponent();

        }

       private void Category_Load(object sender, EventArgs e)
        {
            LoadCategoryData();
          BindDataToControls();
        }
       
        private BindingSource categoryBindingSource = new BindingSource();



        private void LoadCategoryData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [CategoryId], [CategoryName] FROM [dbo].[Category]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        categoryBindingSource.DataSource = dataTable;

                        dataGridView.DataSource = categoryBindingSource;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void BindDataToControls()
        {
            txtProductName.DataBindings.Add("Text", categoryBindingSource, "CategoryName");
            txtCategoryId.DataBindings.Add("Text", categoryBindingSource, "CategoryId");
        }

      /*  private void UnbindDataFromControls()
        {
            txtProductName.DataBindings.Clear();
            txtCategoryId.DataBindings.Clear();
        }*/

        private void btnAdd_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string categoryName = txtProductName.Text;
                    string query = "INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (@CategoryId, @CategoryName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryId", GetNextCategoryId(connection)); 
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm dữ liệu thành công!");
                            btnLoad_Click(sender, e); 
                        }
                        else
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private int GetNextCategoryId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(CategoryId), 0) + 1 FROM [dbo].[Category]";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int nextCategoryId))
                {
                    return nextCategoryId;
                }
                return 1; 
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count > 0)
            {
                int categoryId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["CategoryId"].Value);
                string query = "DELETE FROM [dbo].[Category] WHERE [CategoryId] = @CategoryId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryId", categoryId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa dữ liệu thành công!");
                                btnLoad_Click(sender, e); 
                            }
                            else
                            {
                                MessageBox.Show("Xóa dữ liệu thất bại!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }




        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int categoryId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["CategoryId"].Value);
                string newCategoryName = txtProductName.Text;
                string query = "UPDATE [dbo].[Category] SET [CategoryName] = @CategoryName WHERE [CategoryId] = @CategoryId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@CategoryId", categoryId);
                        command.Parameters.AddWithValue("@CategoryName", newCategoryName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công!");
                            LoadCategoryData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.");
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleError("Lỗi khi cập nhật dữ liệu:", ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
            }
        }
        

        private void HandleError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [CategoryId], [CategoryName] FROM [dbo].[Category]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                       
                        dataGridView.DataSource = dataTable; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName))
                        {
                            
                            string header = string.Join(",", dataGridView.Columns.Cast<DataGridViewColumn>().Select(column => column.HeaderText));
                            streamWriter.WriteLine(header);

                            
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                string rowData = string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value));
                                streamWriter.WriteLine(rowData);
                            }

                            MessageBox.Show("Xuất dữ liệu thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [CategoryId], [CategoryName] FROM [dbo].[Category] WHERE [CategoryName] LIKE @Keyword";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }











        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
