using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseInventoryAccountingProgram.DataAccess;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.Forms
{
    public partial class ReportsForm : Form
    {
        private ProductRepository productRepository; // ProductRepository class to handle product data access
        private SalesRepository salesRepository; // SalesRepository class to handle sales data access
        private PurchaseOrderRepository purchaseOrderRepository; // PurchaseOrderRepository class to handle purchase order data access

        public ReportsForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository(); // Initialize the ProductRepository
            salesRepository = new SalesRepository(); // Initialize the SalesRepository
            purchaseOrderRepository = new PurchaseOrderRepository(); // Initialize the PurchaseOrderRepository
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Load available reports
            LoadReports();
        }

        private void LoadReports()
        {
            // Add reports to the combo box
            cmbReports.Items.Add("Inventory Report");
            cmbReports.Items.Add("Sales Report");
            cmbReports.Items.Add("Purchase Report");
        }

        private void btnCreatePurchaseOrder_Click(object sender, EventArgs e)
        {
            // Validate the selected report
            if (cmbReports.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate the selected report
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

        private void GenerateInventoryReport()
        {
            // Retrieve inventory data from the database
            List<Product> products = productRepository.GetAllProducts();
            dgvReport.DataSource = products;
            // Display the inventory report
            // Your code to display the report goes here
            MessageBox.Show("Inventory report generated.");
        }

        private void GenerateSalesReport()
        {
            // Retrieve sales data from the database
            List<Sale> sales = salesRepository.GetAllSales();
            dgvReport.DataSource = sales;

            // Display the sales report
            // Your code to display the report goes here
            MessageBox.Show("Sales report generated.");
        }

        private void GeneratePurchaseReport()
        {
            // Retrieve purchase order data from the database
            List<PurchaseOrder> purchaseOrders = purchaseOrderRepository.GetAllPurchaseOrders();
            dgvReport.DataSource = purchaseOrders;

            // Display the purchase report
            // Your code to display the report goes here
            MessageBox.Show("Purchase report generated.");
        }


    }
}
