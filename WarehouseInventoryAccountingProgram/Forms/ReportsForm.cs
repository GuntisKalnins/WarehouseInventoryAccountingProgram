namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// ReportsForm form for generating different reports.
    /// </summary>
    public partial class ReportsForm : Form
    {
        private ProductRepository productRepository;
        private SalesRepository salesRepository;
        private PurchaseOrderRepository purchaseOrderRepository;

        /// <summary>
        /// Initializes a new instance of the ReportsForm class.
        /// </summary>
        public ReportsForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository(); 
            salesRepository = new SalesRepository(); 
            purchaseOrderRepository = new PurchaseOrderRepository();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadReports();
        }

        /// <summary>
        /// Loads the available reports into the combo box.
        /// </summary>
        private void LoadReports()
        {
            cmbReports.Items.Add("Inventory Report");
            cmbReports.Items.Add("Sales Report");
            cmbReports.Items.Add("Purchase Report");
        }

        /// <summary>
        /// Generates the selected report.
        /// </summary>
        private void btnCreatePurchaseOrder_Click(object sender, EventArgs e)
        {
            if (cmbReports.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedReport = cmbReports.SelectedItem.ToString();

            switch (selectedReport)
            {
                case "Inventory Report":
                    GenerateInventoryReport();
                    break;
                case "Sales Report":
                    GenerateSalesReport();
                    break;
                case "Purchase Report":
                    GeneratePurchaseReport();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Generates the inventory report and displays it in the DataGridView.
        /// </summary>
        private void GenerateInventoryReport()
        {
            List<Product> products = productRepository.GetAllProducts();
            dgvReport.DataSource = products;
            MessageBox.Show("Inventory report generated.");
        }

        /// <summary>
        /// Generates the sales report and displays it in the DataGridView.
        /// </summary>
        private void GenerateSalesReport()
        {
            List<Sale> sales = salesRepository.GetAllSales();
            dgvReport.DataSource = sales;
            MessageBox.Show("Sales report generated.");
        }

        /// <summary>
        /// Generates the purchase report and displays it in the DataGridView.
        /// </summary>
        private void GeneratePurchaseReport()
        {
            List<PurchaseOrder> purchaseOrders = purchaseOrderRepository.GetAllPurchaseOrders();
            dgvReport.DataSource = purchaseOrders;
            MessageBox.Show("Purchase report generated.");
        }
    }
}
