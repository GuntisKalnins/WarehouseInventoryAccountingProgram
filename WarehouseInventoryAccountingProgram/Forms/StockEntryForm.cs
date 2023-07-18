using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseInventoryAccountingProgram.DataAccess;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.Forms
{
    /// <summary>
    /// Class for handling stock entry data access.
    /// </summary>
    public partial class StockEntryForm : Form
    {
        private ProductRepository productRepository;
        private StockEntryRepository stockEntryRepository; 
        private List<Product> products;

        public StockEntryForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            stockEntryRepository = new StockEntryRepository();
        }

        private void StockEntryForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadSuppliers();
        }

        private void LoadProducts()
        {
            products = productRepository.GetAllProducts();

            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }

        private void LoadSuppliers()
        {
            List<Supplier> suppliers = stockEntryRepository.GetAllSuppliers();

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
        }

        /// <summary>
        /// Event handler for the "Submit" button click.
        /// Adds the entered product information to the database.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Product selectedProduct = cmbProduct.SelectedItem as Product;
            Supplier selectedSupplier = cmbSupplier.SelectedItem as Supplier;

            StockEntry stockEntry = new StockEntry
            {
                ProductID = selectedProduct.ProductID,
                SupplierID = selectedSupplier.SupplierID,
                EntryDate = dtpEntryDate.Value,
                Quantity = Convert.ToInt32(txtQuantity.Text.Trim())
            };

            stockEntryRepository.AddStockEntry(stockEntry);
            productRepository.UpdateProductQuantity(selectedProduct.ProductID, stockEntry.Quantity);
            MessageBox.Show("Stock entry recorded successfully!");

            ResetFields();
        }

        private bool ValidateFields()
        {
            if (cmbProduct.SelectedIndex == -1 || cmbSupplier.SelectedIndex == -1 || Convert.ToInt32(txtQuantity.Text.Trim()) == 0)
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ResetFields()
        {
            cmbProduct.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            txtQuantity.Text = "0";
            dtpEntryDate.Value = DateTime.Today;
        }
    }
}
