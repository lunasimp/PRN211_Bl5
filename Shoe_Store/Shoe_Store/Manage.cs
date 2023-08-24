using Microsoft.Data.SqlClient;
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
    public partial class Manage : UserControl
    {
        private string connectionString = "server =LAPTOP-KUS4KDEA; database =Store;uid=sa;pwd=123;TrustServerCertificate=true;Integrated Security = true";

        public Manage()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Manage_Load(object sender, EventArgs e)
        {
            LoadManageData();
        }
        private void LoadManageData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            COALESCE(P.ProviderId, 0) AS ProviderId,
                            COALESCE(P.ProviderName, '') AS ProviderName,
                            COALESCE(P.Quantity, 0) AS Quantity_import,
                            COALESCE(P.ProductId, 0) AS ProductId_import,
                            COALESCE(PR.ProductName, '') AS ProductName,
                            COALESCE(PR.InStock, 0) AS InStock,
                            COALESCE(C.Quantity, 0) AS Quantity_sale,
                            COALESCE(C.CustomerName, '') AS CustomerName
                        FROM Provider AS P
                        LEFT JOIN Product AS PR ON P.ProductId = PR.ProductId
                        LEFT JOIN Customer AS C ON PR.ProductId = C.ProductId;
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
                int providertId = Convert.ToInt32(selectedRow.Cells["ProviderId"].Value);
                string providerName = Convert.ToString(selectedRow.Cells["ProviderName"].Value);
                int quantityimport = Convert.ToInt32(selectedRow.Cells["Quantity_import"].Value);
                int productidimport = Convert.ToInt32(selectedRow.Cells["ProductId_import"].Value);
                string productname = Convert.ToString(selectedRow.Cells["ProductName"].Value);
                int instock = Convert.ToInt32(selectedRow.Cells["InStock"].Value);
                int quantitysale = Convert.ToInt32(selectedRow.Cells["Quantity_sale"].Value);
                string customername = Convert.ToString(selectedRow.Cells["CustomerName"].Value);

                textBox1.Text = providertId.ToString();
                textBox2.Text = providerName;
                textBox3.Text = quantityimport.ToString();
                textBox4.Text = productidimport.ToString();
                textBox6.Text = productname;
                textBox5.Text = instock.ToString();
                textBox8.Text = quantitysale.ToString();
                textBox7.Text = customername;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
