namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Represents the form for editing a product in the inventory.
    /// </summary>
    public partial class EditProductForm : Form
    {
        private ProductRepository productRepository;
        private Product productToUpdate;

        /// <summary>
        /// Initializes a new instance of the EditProductForm class.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        public EditProductForm(Product product)
        {
            InitializeComponent();
            productRepository = new ProductRepository(); 
            productToUpdate = product;

            txtProductName.Text = productToUpdate.ProductName;
            txtQuantity.Text = productToUpdate.Quantity.ToString();
            txtPrice.Text = productToUpdate.Price.ToString();
            dtpExpirationDate.Value = productToUpdate.ExpirationDate;
        }

        /// <summary>
        /// Handles the button click event for updating the product.
        /// </summary>
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                productToUpdate.ProductName = txtProductName.Text;
                productToUpdate.Quantity = Convert.ToInt32(txtQuantity.Text);
                productToUpdate.Price = Convert.ToDecimal(txtPrice.Text);
                productToUpdate.ExpirationDate = dtpExpirationDate.Value;

                bool isUpdated = productRepository.UpdateProduct(productToUpdate);

                if (isUpdated)
                {
                    MessageBox.Show("Product updated successfully.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Failed to update the product.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Validates the form fields.
        /// </summary>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

