namespace WarehouseInventoryAccountingProgram.Forms
{
    partial class DashboardForm
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
            this.lblForTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalQuantity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnStockEntry = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblForTotalProducts
            // 
            this.lblForTotalProducts.AutoSize = true;
            this.lblForTotalProducts.Location = new System.Drawing.Point(12, 9);
            this.lblForTotalProducts.Name = "lblForTotalProducts";
            this.lblForTotalProducts.Size = new System.Drawing.Size(79, 13);
            this.lblForTotalProducts.TabIndex = 1;
            this.lblForTotalProducts.Text = "Total Products:";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Location = new System.Drawing.Point(91, 9);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(0, 13);
            this.lblTotalProducts.TabIndex = 2;
            // 
            // lblTotalQuantity
            // 
            this.lblTotalQuantity.AutoSize = true;
            this.lblTotalQuantity.Location = new System.Drawing.Point(219, 9);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(0, 13);
            this.lblTotalQuantity.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Quantity:";
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(12, 34);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(88, 49);
            this.btnInventory.TabIndex = 6;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnStockEntry
            // 
            this.btnStockEntry.Location = new System.Drawing.Point(106, 34);
            this.btnStockEntry.Name = "btnStockEntry";
            this.btnStockEntry.Size = new System.Drawing.Size(88, 49);
            this.btnStockEntry.TabIndex = 7;
            this.btnStockEntry.Text = "Stock Entry";
            this.btnStockEntry.UseVisualStyleBackColor = true;
            this.btnStockEntry.Click += new System.EventHandler(this.btnStockEntry_Click);
            // 
            // btnSales
            // 
            this.btnSales.Location = new System.Drawing.Point(200, 34);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(88, 49);
            this.btnSales.TabIndex = 8;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(12, 89);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(88, 49);
            this.btnPurchase.TabIndex = 9;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(106, 89);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(88, 49);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(201, 89);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(88, 49);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 151);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnStockEntry);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.lblTotalQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.lblForTotalProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblForTotalProducts;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnStockEntry;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnHelp;
    }
}