namespace Shoe_Store
{
    partial class CustomerActivities
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpdate = new Button();
            txtQuantity = new TextBox();
            Price = new Label();
            txtCustomerName = new TextBox();
            label4 = new Label();
            txtProductId = new TextBox();
            label3 = new Label();
            txtPurchaseDate = new TextBox();
            label2 = new Label();
            btnLoad = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            txtCustomerID = new TextBox();
            label1 = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(693, 56);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(25, 31);
            btnUpdate.TabIndex = 89;
            btnUpdate.Text = "⇧";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(112, 57);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(114, 27);
            txtQuantity.TabIndex = 88;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(15, 61);
            Price.Name = "Price";
            Price.Size = new Size(65, 20);
            Price.TabIndex = 87;
            Price.Text = "Quantity";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(344, 17);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(172, 27);
            txtCustomerName.TabIndex = 86;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 20);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 85;
            label4.Text = "Customer name";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(346, 56);
            txtProductId.Margin = new Padding(3, 4, 3, 4);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(170, 27);
            txtProductId.TabIndex = 84;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 64);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 83;
            label3.Text = "ProductId";
            // 
            // txtPurchaseDate
            // 
            txtPurchaseDate.Location = new Point(636, 17);
            txtPurchaseDate.Margin = new Padding(3, 4, 3, 4);
            txtPurchaseDate.Name = "txtPurchaseDate";
            txtPurchaseDate.Size = new Size(114, 27);
            txtPurchaseDate.TabIndex = 82;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(535, 20);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 81;
            label2.Text = "Purchase Date";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(725, 56);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(25, 31);
            btnLoad.TabIndex = 80;
            btnLoad.Text = "↻";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(103, 99);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(652, 27);
            txtSearch.TabIndex = 79;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(32, 97);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 31);
            btnSearch.TabIndex = 78;
            btnSearch.Text = "🔎";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Location = new Point(112, 17);
            txtCustomerID.Margin = new Padding(3, 4, 3, 4);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(114, 27);
            txtCustomerID.TabIndex = 77;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 24);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 76;
            label1.Text = "Customer ID";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(661, 56);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 31);
            btnDelete.TabIndex = 75;
            btnDelete.Text = "-";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(629, 56);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(25, 31);
            btnAdd.TabIndex = 74;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(15, 137);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(740, 296);
            dataGridView.TabIndex = 73;
            // 
            // CustomerActivities
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUpdate);
            Controls.Add(txtQuantity);
            Controls.Add(Price);
            Controls.Add(txtCustomerName);
            Controls.Add(label4);
            Controls.Add(txtProductId);
            Controls.Add(label3);
            Controls.Add(txtPurchaseDate);
            Controls.Add(label2);
            Controls.Add(btnLoad);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtCustomerID);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Name = "CustomerActivities";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox txtQuantity;
        private Label Price;
        private TextBox txtCustomerName;
        private Label label4;
        private TextBox txtProductId;
        private Label label3;
        private TextBox txtPurchaseDate;
        private Label label2;
        private Button btnLoad;
        private TextBox txtSearch;
        private Button btnSearch;
        private TextBox txtCustomerID;
        private Label label1;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridView;
    }
}