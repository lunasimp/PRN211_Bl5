namespace Shoe_Store
{
    partial class Provider
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
            txtProviderName = new TextBox();
            label4 = new Label();
            txtProductId = new TextBox();
            label3 = new Label();
            txtProviderDate = new TextBox();
            label2 = new Label();
            btnLoad = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            txtProviderID = new TextBox();
            label1 = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(690, 56);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(25, 31);
            btnUpdate.TabIndex = 72;
            btnUpdate.Text = "⇧";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(109, 57);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(114, 27);
            txtQuantity.TabIndex = 71;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(30, 61);
            Price.Name = "Price";
            Price.Size = new Size(65, 20);
            Price.TabIndex = 70;
            Price.Text = "Quantity";
            // 
            // txtProviderName
            // 
            txtProviderName.Location = new Point(341, 17);
            txtProviderName.Margin = new Padding(3, 4, 3, 4);
            txtProviderName.Name = "txtProviderName";
            txtProviderName.Size = new Size(172, 27);
            txtProviderName.TabIndex = 69;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(230, 21);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 68;
            label4.Text = "Provider name";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(343, 56);
            txtProductId.Margin = new Padding(3, 4, 3, 4);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(170, 27);
            txtProductId.TabIndex = 67;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(262, 61);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 66;
            label3.Text = "ProductId";
            // 
            // txtProviderDate
            // 
            txtProviderDate.Location = new Point(633, 17);
            txtProviderDate.Margin = new Padding(3, 4, 3, 4);
            txtProviderDate.Name = "txtProviderDate";
            txtProviderDate.Size = new Size(114, 27);
            txtProviderDate.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 20);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 64;
            label2.Text = "Provide Date";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(722, 56);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(25, 31);
            btnLoad.TabIndex = 63;
            btnLoad.Text = "↻";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 99);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(652, 27);
            txtSearch.TabIndex = 62;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(29, 97);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 31);
            btnSearch.TabIndex = 61;
            btnSearch.Text = "🔎";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtProviderID
            // 
            txtProviderID.Location = new Point(109, 17);
            txtProviderID.Margin = new Padding(3, 4, 3, 4);
            txtProviderID.Name = "txtProviderID";
            txtProviderID.Size = new Size(114, 27);
            txtProviderID.TabIndex = 60;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 59;
            label1.Text = "Provider ID";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(658, 56);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 31);
            btnDelete.TabIndex = 58;
            btnDelete.Text = "-";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(626, 56);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(25, 31);
            btnAdd.TabIndex = 57;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(30, 137);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(720, 296);
            dataGridView.TabIndex = 56;
            // 
            // Provider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUpdate);
            Controls.Add(txtQuantity);
            Controls.Add(Price);
            Controls.Add(txtProviderName);
            Controls.Add(label4);
            Controls.Add(txtProductId);
            Controls.Add(label3);
            Controls.Add(txtProviderDate);
            Controls.Add(label2);
            Controls.Add(btnLoad);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtProviderID);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Name = "Provider";
            Size = new Size(800, 450);
            Load += Provider_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox txtQuantity;
        private Label Price;
        private TextBox txtProviderName;
        private Label label4;
        private TextBox txtProductId;
        private Label label3;
        private TextBox txtProviderDate;
        private Label label2;
        private Button btnLoad;
        private TextBox txtSearch;
        private Button btnSearch;
        private TextBox txtProviderID;
        private Label label1;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridView;
    }
}