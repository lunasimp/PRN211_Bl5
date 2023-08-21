namespace Shoe_Store
{
    partial class Category
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
            btnExport = new Button();
            btnUpdate = new Button();
            txtProductName = new TextBox();
            label4 = new Label();
            txtCategoryId = new TextBox();
            label2 = new Label();
            btnLoad = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.Location = new Point(539, 143);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(106, 40);
            btnExport.TabIndex = 36;
            btnExport.Text = "Export data";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(451, 17);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(25, 31);
            btnUpdate.TabIndex = 35;
            btnUpdate.Text = "⇧";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(139, 17);
            txtProductName.Margin = new Padding(3, 4, 3, 4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(225, 27);
            txtProductName.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 17);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 31;
            label4.Text = "Category name";
            // 
            // txtCategoryId
            // 
            txtCategoryId.Location = new Point(139, 50);
            txtCategoryId.Margin = new Padding(3, 4, 3, 4);
            txtCategoryId.Name = "txtCategoryId";
            txtCategoryId.Size = new Size(225, 27);
            txtCategoryId.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 53);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 27;
            label2.Text = "Category ID";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(483, 17);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(25, 31);
            btnLoad.TabIndex = 26;
            btnLoad.Text = "↻";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(52, 96);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(465, 27);
            txtSearch.TabIndex = 25;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(20, 96);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 27);
            btnSearch.TabIndex = 24;
            btnSearch.Text = "🔎";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(419, 17);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 31);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "-";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(387, 17);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(25, 31);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(21, 143);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(496, 380);
            dataGridView.TabIndex = 19;
            // 
            // Category
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExport);
            Controls.Add(btnUpdate);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(txtCategoryId);
            Controls.Add(label2);
            Controls.Add(btnLoad);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Name = "Category";
            Size = new Size(673, 569);
            Load += Category_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExport;
        private Button btnUpdate;
        private TextBox txtProductName;
        private Label label4;
        private TextBox txtCategoryId;
        private Label label2;
        private Button btnLoad;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridView;
    }
}
