namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Purchase Form for creating purchase orders.
    /// </summary>
    public partial class PurchaseForm : Form
    {
        private ProductRepository productRepository;
        private PurchaseOrderRepository purchaseOrderRepository;
        private SupplierRepository supplierRepository;
        private List<Product> products;
        private List<Supplier> suppliers;

        public PurchaseForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            purchaseOrderRepository = new PurchaseOrderRepository();
            supplierRepository = new SupplierRepository();
        }

        /// <summary>
        /// Loads products and suppliers into corresponding combobox controls on form load.
        /// </summary>
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadSuppliers();
        }

        /// <summary>
        /// Loads all products and sets the data source for product combobox.
        /// </summary>
        private void LoadProducts()
        {
            products = productRepository.GetAllProducts();
            dgvProducts.DataSource = products;
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }

        /// <summary>
        /// Loads all suppliers and sets the data source for supplier combobox.
        /// </summary>
        private void LoadSuppliers()
        {
            suppliers = supplierRepository.GetAllSuppliers();

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
        }


        /// <summary>
        /// Creates a new purchase and adds the purchase order to the repository, updates the product quantity, and displays a success message.
        /// </summary>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Product selectedProduct = cmbProduct.SelectedItem as Product;
            Supplier selectedSupplier = cmbSupplier.SelectedItem as Supplier;

            int quantity = Convert.ToInt32(numQuantity.Value);
            decimal cost = numCost.Value;

            PurchaseOrder purchaseOrder = new PurchaseOrder
            {
                ProductID = selectedProduct.ProductID,
                SupplierID = selectedSupplier.SupplierID,
                Quantity = quantity,
                Cost = cost,
                PurchaseDate = DateTime.Now,
            };

            purchaseOrderRepository.AddPurchaseOrder(purchaseOrder);
            productRepository.UpdateProductQuantity(selectedProduct.ProductID, quantity);
            MessageBox.Show("Purchase order created successfully!");
            ResetFields();
        }

        /// <summary>
        /// Validates whether all required fields are filled.
        /// </summary>
        private bool ValidateFields()
        {
            if (cmbProduct.SelectedIndex == -1 || cmbSupplier.SelectedIndex == -1 || numQuantity.Value == 0 || numCost.Value == 0)
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
            cmbProduct.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            numQuantity.Value = 0;
            numCost.Value = 0;
        }
    }
}
