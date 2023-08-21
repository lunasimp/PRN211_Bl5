namespace Shoe_Store
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            toolStrip1 = new ToolStrip();
            tsbProduct = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbCategory = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbProvider = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsbCustomer = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbLogout = new ToolStripButton();
            mainPanel = new Panel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbProduct, toolStripSeparator1, tsbCategory, toolStripSeparator2, tsbProvider, toolStripSeparator4, tsbCustomer, toolStripSeparator3, tsbLogout });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(685, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbProduct
            // 
            tsbProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbProduct.Image = (Image)resources.GetObject("tsbProduct.Image");
            tsbProduct.ImageTransparentColor = Color.Magenta;
            tsbProduct.Name = "tsbProduct";
            tsbProduct.Size = new Size(53, 22);
            tsbProduct.Text = "Product";
            tsbProduct.Click += tsbProduct_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsbCategory
            // 
            tsbCategory.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbCategory.Image = (Image)resources.GetObject("tsbCategory.Image");
            tsbCategory.ImageTransparentColor = Color.Magenta;
            tsbCategory.Name = "tsbCategory";
            tsbCategory.Size = new Size(59, 22);
            tsbCategory.Text = "Category";
            tsbCategory.Click += tsbCategory_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbProvider
            // 
            tsbProvider.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbProvider.Image = (Image)resources.GetObject("tsbProvider.Image");
            tsbProvider.ImageTransparentColor = Color.Magenta;
            tsbProvider.Name = "tsbProvider";
            tsbProvider.Size = new Size(55, 22);
            tsbProvider.Text = "Provider";
            tsbProvider.Click += tsbProvider_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // tsbCustomer
            // 
            tsbCustomer.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbCustomer.Image = (Image)resources.GetObject("tsbCustomer.Image");
            tsbCustomer.ImageTransparentColor = Color.Magenta;
            tsbCustomer.Name = "tsbCustomer";
            tsbCustomer.Size = new Size(114, 22);
            tsbCustomer.Text = "Customer Activities";
            tsbCustomer.Click += tsbCustomer_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // tsbLogout
            // 
            tsbLogout.Alignment = ToolStripItemAlignment.Right;
            tsbLogout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLogout.Image = (Image)resources.GetObject("tsbLogout.Image");
            tsbLogout.ImageTransparentColor = Color.Magenta;
            tsbLogout.Name = "tsbLogout";
            tsbLogout.Size = new Size(49, 22);
            tsbLogout.Text = "Logout";
            tsbLogout.Click += tsbLogout_Click;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(10, 22);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(670, 443);
            mainPanel.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 475);
            Controls.Add(mainPanel);
            Controls.Add(toolStrip1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controller";
            Shown += Main_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbProduct;
        private ToolStripButton tsbCategory;
        private ToolStripButton tsbProvider;
        private ToolStripButton tsbCustomer;
        private ToolStripButton tsbLogout;
        private Product product1;
        private Product product2;
        private Panel mainPanel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
    }
}