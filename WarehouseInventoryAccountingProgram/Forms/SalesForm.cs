namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Sales Form for processing sales transactions.
    /// </summary>
    public partial class SalesForm : Form
    {
        private ProductRepository productRepository;
        private SalesRepository salesRepository; 
        private List<Product> products; 

        public SalesForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository(); 
            salesRepository = new SalesRepository(); 
        }

        /// <summary>
        /// Loads the Sales Form and retrieves the products from the database.
        /// </summary>
        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        /// <summary>
        /// Retrieves the products from the database and displays them in the DataGridView control.
        /// </summary>
        private void LoadProducts()
        {
            products = productRepository.GetAllProducts();
            dgvProducts.DataSource = products;
        }

        /// <summary>
        /// Processes the sale transaction.
        /// </summary>
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Product selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Product;
            string customerName = txtCustomerName.Text;
            int quantitySold = Convert.ToInt32(numQuantity.Value);
            decimal totalAmount = selectedProduct.Price * quantitySold;

            Sale sale = new Sale
            {
                ProductID = selectedProduct.ProductID,
                SaleDate = DateTime.Now,
                CustomerName = customerName,
                Quantity = quantitySold,
                TotalAmount = totalAmount
            };

            salesRepository.AddSale(sale);
            productRepository.UpdateProductQuantity(selectedProduct.ProductID, -quantitySold);
            MessageBox.Show("Sale processed successfully!");
            ResetFields();
        }

        /// <summary>
        /// Validates the required input fields for the sale.
        /// </summary>
        private bool ValidateFields()
        {
            if (dgvProducts.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtCustomerName.Text) || numQuantity.Value == 0)
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Resets the form fields to their initial state.
        /// </summary>
        private void ResetFields()
        {
            dgvProducts.ClearSelection();
            txtCustomerName.Text = string.Empty;
            numQuantity.Value = 0;
            LoadProducts();
        }
    }
}
