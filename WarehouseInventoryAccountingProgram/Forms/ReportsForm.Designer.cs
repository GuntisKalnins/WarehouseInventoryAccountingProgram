namespace WarehouseInventoryAccountingProgram.Forms
{
    partial class ReportsForm
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
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblReportOptions = new System.Windows.Forms.Label();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnCreatePurchaseOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(16, 58);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(855, 493);
            this.dgvReport.TabIndex = 0;
            // 
            // lblReportOptions
            // 
            this.lblReportOptions.AutoSize = true;
            this.lblReportOptions.Location = new System.Drawing.Point(13, 13);
            this.lblReportOptions.Name = "lblReportOptions";
            this.lblReportOptions.Size = new System.Drawing.Size(78, 13);
            this.lblReportOptions.TabIndex = 1;
            this.lblReportOptions.Text = "Report Options";
            // 
            // cmbReports
            // 
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(16, 30);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(185, 21);
            this.cmbReports.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(207, 32);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(413, 32);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(204, 13);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 5;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(410, 13);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date";
            // 
            // btnCreatePurchaseOrder
            // 
            this.btnCreatePurchaseOrder.Location = new System.Drawing.Point(777, 28);
            this.btnCreatePurchaseOrder.Name = "btnCreatePurchaseOrder";
            this.btnCreatePurchaseOrder.Size = new System.Drawing.Size(90, 23);
            this.btnCreatePurchaseOrder.TabIndex = 7;
            this.btnCreatePurchaseOrder.Text = "Create";
            this.btnCreatePurchaseOrder.UseVisualStyleBackColor = true;
            this.btnCreatePurchaseOrder.Click += new System.EventHandler(this.btnCreatePurchaseOrder_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 663);
            this.Controls.Add(this.btnCreatePurchaseOrder);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.lblReportOptions);
            this.Controls.Add(this.dgvReport);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblReportOptions;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnCreatePurchaseOrder;
    }
}