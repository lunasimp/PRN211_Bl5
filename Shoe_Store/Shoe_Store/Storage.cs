using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Storage : UserControl
    {
        private string connectionString = "server =LAPTOP-KUS4KDEA; database =Store;uid=sa;pwd=123;TrustServerCertificate=true;Integrated Security = true";

        public Storage()
        {
            InitializeComponent();

        }

        private void Storage_Load(object sender, EventArgs e)
        {
            LoadStorageData();
        }
        private void LoadStorageData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            P.ProductName,
                            P.InStock,
                            COALESCE(SUM(C.Quantity), 0) AS Quantity_Sale,
                            P.InStock - COALESCE(SUM(C.Quantity), 0) AS RemainingStock
                        FROM Product AS P
                        LEFT JOIN Customer AS C ON P.ProductId = C.ProductId
                        GROUP BY P.ProductId, P.ProductName, P.InStock
                        ORDER BY P.ProductId;
                        ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = dataTable;

                        // Gán BindingSource vào DataGridView
                        dataGridView1.DataSource = bindingSource;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                // lay gia tri tu dataGirdView
                int instock = Convert.ToInt32(selectedRow.Cells["InStock"].Value);
                string productName = Convert.ToString(selectedRow.Cells["ProductName"].Value);
                int quantitysale = Convert.ToInt32(selectedRow.Cells["Quantity_Sale"].Value);
                int tonkho = Convert.ToInt32(selectedRow.Cells["RemainingStock"].Value);
                

                textBox1.Text = productName;
                textBox2.Text = instock.ToString();
                textBox3.Text = quantitysale.ToString();
                textBox4.Text = tonkho.ToString();
                
            }
        }
    }
}
