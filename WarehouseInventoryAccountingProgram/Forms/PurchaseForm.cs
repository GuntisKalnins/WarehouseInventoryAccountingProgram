using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseInventoryAccountingProgram.DataAccess;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.Forms
{
    /// <summary>
    /// Represents the Purchase Form for creating purchase orders.
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
        /// Handles the loading of the Purchase Form.
        /// </summary>
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadSuppliers();
        }

        private void LoadProducts()
        {
            products = productRepository.GetAllProducts();
            dgvProducts.DataSource = products;
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }

        private void LoadSuppliers()
        {
            suppliers = supplierRepository.GetAllSuppliers();

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
        }

        /// <summary>
        /// Handles the click event for the Create Order button.
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

        private bool ValidateFields()
        {
            if (cmbProduct.SelectedIndex == -1 || cmbSupplier.SelectedIndex == -1 || numQuantity.Value == 0 || numCost.Value == 0)
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
            numQuantity.Value = 0;
            numCost.Value = 0;
        }
    }
}
