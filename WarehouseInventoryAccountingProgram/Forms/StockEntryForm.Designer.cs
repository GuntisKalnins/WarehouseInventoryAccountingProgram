namespace WarehouseInventoryAccountingProgram.Forms
{
    partial class StockEntryForm
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
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblEntryDate = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(12, 25);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(200, 21);
            this.cmbProduct.TabIndex = 0;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(12, 65);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(200, 21);
            this.cmbSupplier.TabIndex = 1;
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Location = new System.Drawing.Point(12, 105);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEntryDate.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(12, 144);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(137, 181);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(13, 9);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "Product";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(12, 49);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 6;
            this.lblSupplier.Text = "Supplier";
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.AutoSize = true;
            this.lblEntryDate.Location = new System.Drawing.Point(13, 89);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(54, 13);
            this.lblEntryDate.TabIndex = 7;
            this.lblEntryDate.Text = "EntryDate";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(13, 128);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity";
            // 
            // StockEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 217);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblEntryDate);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.dtpEntryDate);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.cmbProduct);
            this.Name = "StockEntryForm";
            this.Text = "StockEntryForm";
            this.Load += new System.EventHandler(this.StockEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblEntryDate;
        private System.Windows.Forms.Label lblQuantity;
    }
}