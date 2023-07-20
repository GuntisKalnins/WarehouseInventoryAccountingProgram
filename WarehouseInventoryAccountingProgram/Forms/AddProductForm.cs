namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Form for adding a new product to the inventory.
    /// </summary>
    public partial class AddProductForm : Form
    {
        private ProductRepository productRepository;
        public AddProductForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
        }

        /// <summary>
        /// Adds the entered product information to the database.
        /// </summary>
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
            DateTime expirationDate = dtpExpirationDate.Value;

            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Please enter a product name.", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product newProduct = new Product
            {
                ProductName = productName,
                Quantity = quantity,
                Price = price,
                ExpirationDate = expirationDate
            };

            bool success = productRepository.AddProduct(newProduct);

            if (success)
            {
                MessageBox.Show("Product added successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Failed to add the product.", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Closes the form without adding the product.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
