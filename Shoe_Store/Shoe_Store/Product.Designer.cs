namespace Shoe_Store
{
    partial class Product
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            label1 = new Label();
            txtProductID = new TextBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnLoad = new Button();
            label2 = new Label();
            txtInStock = new TextBox();
            label3 = new Label();
            txtProductName = new TextBox();
            label4 = new Label();
            txtPrice = new TextBox();
            Price = new Label();
            btnUpdate = new Button();
            btnExport = new Button();
            btnFilter = new Button();
            cbxCategoryId = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(22, 151);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(625, 417);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(526, 69);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(25, 31);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(558, 69);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 31);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "-";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 3;
            label1.Text = "Product ID";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(101, 31);
            txtProductID.Margin = new Padding(3, 4, 3, 4);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(114, 27);
            txtProductID.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(21, 111);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 31);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "🔎";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(53, 112);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(596, 27);
            txtSearch.TabIndex = 6;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(622, 69);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(25, 31);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "↻";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 36);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 8;
            label2.Text = "Category ID";
            // 
            // txtInStock
            // 
            txtInStock.Location = new Point(323, 71);
            txtInStock.Margin = new Padding(3, 4, 3, 4);
            txtInStock.Name = "txtInStock";
            txtInStock.Size = new Size(114, 27);
            txtInStock.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 75);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 10;
            label3.Text = "In stock";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(324, 31);
            txtProductName.Margin = new Padding(3, 4, 3, 4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(114, 27);
            txtProductName.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(222, 35);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 12;
            label4.Text = "Product name";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(101, 71);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(114, 27);
            txtPrice.TabIndex = 15;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(22, 75);
            Price.Name = "Price";
            Price.Size = new Size(41, 20);
            Price.TabIndex = 14;
            Price.Text = "Price";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(590, 69);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(25, 31);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "⇧";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(654, 151);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(96, 40);
            btnExport.TabIndex = 17;
            btnExport.Text = "Export data";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(653, 209);
            btnFilter.Margin = new Padding(3, 4, 3, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(96, 40);
            btnFilter.TabIndex = 18;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cbxCategoryId
            // 
            cbxCategoryId.FormattingEnabled = true;
            cbxCategoryId.Location = new Point(543, 30);
            cbxCategoryId.Name = "cbxCategoryId";
            cbxCategoryId.Size = new Size(151, 28);
            cbxCategoryId.TabIndex = 20;
            // 
            // Product
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbxCategoryId);
            Controls.Add(btnFilter);
            Controls.Add(btnExport);
            Controls.Add(btnUpdate);
            Controls.Add(txtPrice);
            Controls.Add(Price);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(txtInStock);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLoad);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtProductID);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Product";
            Size = new Size(767, 608);
            Load += Product_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button btnAdd;
        private Button btnDelete;
        private Label label1;
        private TextBox txtProductID;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnLoad;
        private Label label2;
        private TextBox txtInStock;
        private Label label3;
        private TextBox txtProductName;
        private Label label4;
        private TextBox txtPrice;
        private Label Price;
        private Button btnUpdate;
        private Button btnExport;
        private Button btnFilter;
        private ComboBox cbxCategoryId;
    }
}
