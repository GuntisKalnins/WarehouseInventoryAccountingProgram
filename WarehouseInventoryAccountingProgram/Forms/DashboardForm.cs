namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;

    /// <summary>
    /// The DashboardForm class represents the form that provides an overview of the system and displays important statistics and key performance indicators.
    /// </summary>
    public partial class DashboardForm : Form
    {
        private ProductRepository productRepository;

        public DashboardForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadProductInformation();
        }

        /// <summary>
        /// Loads the product information from the database and displays it on the dashboard.
        /// </summary>
        private void LoadProductInformation()
        {
            var products = productRepository.GetAllProducts();

            int totalProducts = products.Count;
            int totalQuantity = productRepository.GetTotalQuantity();

            lblTotalProducts.Text = totalProducts.ToString();
            lblTotalQuantity.Text = totalQuantity.ToString();
        }

        /// <summary>
        /// Handles the button click event to navigate to the InventoryForm.
        /// </summary>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.ShowDialog();
        }

        /// <summary>
        /// Handles the button click event to navigate to the StockEntryForm.
        /// </summary>
        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            StockEntryForm stockEntryForm = new StockEntryForm();
            stockEntryForm.ShowDialog();
        }

        /// <summary>
        /// Handles the button click event to navigate to the SalesForm.
        /// </summary>
        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }

        /// <summary>
        /// Handles the button click event to navigate to the PurchaseForm.
        /// </summary>
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        /// <summary>
        /// Handles the button click event to navigate to the ReportsForm.
        /// </summary>
        private void btnReports_Click(object sender, EventArgs e)
        {
            // Navigate to the ReportsForm
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        /// <summary>
        /// Handles the button click event to navigate to the HelpForm.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}
