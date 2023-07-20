namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// HelpForm which allows users to view different help topics.
    /// </summary>
    public partial class HelpForm : Form
    {
        private const string DocumentationFilePath = "./Text/documentation.txt";
        private const string FAQsFilePath = "./Text/faqs.txt";
        private const string TroubleshootingFilePath = "./Text/troubleshooting.txt";

        public HelpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event handler for the Help/Documentation Form.
        /// </summary>
        private void HelpForm_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        /// <summary>
        /// Loads the available options into the ComboBox control.
        /// </summary>
        private void LoadOptions()
        {
            cmbOptions.Items.Add("Documentation");
            cmbOptions.Items.Add("FAQs");
            cmbOptions.Items.Add("Troubleshooting");
        }

        /// <summary>
        /// Event handler for the selected index changed event of the ComboBox control.
        /// </summary>
        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedContent();
        }

        /// <summary>
        /// Shows the selected content in the textbox based on the selected option in the ComboBox.
        /// </summary>
        private void ShowSelectedContent()
        {
            try
            {
                string selectedOption = cmbOptions.SelectedItem.ToString();
                string content = "";

                switch (selectedOption)
                {
                    case "Documentation":
                        content = File.ReadAllText(DocumentationFilePath);
                        break;
                    case "FAQs":
                        content = File.ReadAllText(FAQsFilePath);
                        break;
                    case "Troubleshooting":
                        content = File.ReadAllText(TroubleshootingFilePath);
                        break;
                    default:
                        break;
                }

                txtContent.Text = content;
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error loading content: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
