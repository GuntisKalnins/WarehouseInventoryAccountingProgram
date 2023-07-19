namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Form that displays the inventory of products.
    /// Allows users to search, filter, and sort the inventory.
    /// Provides options to add, edit, and delete products.
    /// </summary>
    public partial class InventoryForm : Form
    {
        private ProductRepository productRepository;
        private List<Product> products;

        /// <summary>
        /// Initializes a new instance of the InventoryForm class.
        /// </summary>
        public InventoryForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            products = new List<Product>();
        }

        /// <summary>
        /// Event handler for the InventoryForm load event.
        /// Loads and displays the inventory on the form.
        /// </summary>
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        /// <summary>
        /// Loads the inventory by retrieving the product information from the database and displaying it in the DataGridView control.
        /// </summary>
        private void LoadInventory()
        {
            products = productRepository.GetAllProducts();
            dgvInventory.DataSource = products;
        }

        /// <summary>
        /// Event handler for the add product button click.
        /// Opens the AddProductForm to add a new product to the inventory.
        /// </summary>
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            DialogResult result = addProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadInventory();
            }
        }

        /// <summary>
        /// Event handler for the edit product button click.
        /// Opens the EditProductForm to edit the selected product in the inventory.
        /// </summary>
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedProductID = (int)dgvInventory.SelectedRows[0].Cells["ProductID"].Value;

            Product selectedProduct = products.Find(p => p.ProductID == selectedProductID);

            EditProductForm editProductForm = new EditProductForm(selectedProduct);
            DialogResult result = editProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadInventory();
            }
        }

        /// <summary>
        /// Event handler for the delete product button click.
        /// Deletes the selected product from the inventory.
        /// </summary>
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Product selectedProduct = dgvInventory.SelectedRows[0].DataBoundItem as Product;

                bool deleteSuccess = productRepository.DeleteProduct(selectedProduct.ProductID);

                if (deleteSuccess)
                {
                    MessageBox.Show("Product deleted successfully.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadInventory();
                }
                else
                {
                    MessageBox.Show("Failed to delete the product.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
