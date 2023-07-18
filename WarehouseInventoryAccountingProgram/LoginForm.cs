namespace WarehouseInventoryAccountingProgram
{
    using System;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;

    /// <summary>
    /// Login form of the Warehouse Inventory Accounting program.
    /// </summary>
    public partial class LoginForm : Form
    {
        private UserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the LoginForm class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        /// <summary>
        /// Handles the button click event for the login button.
        /// Validates the user's login information against the database.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isValidUser = userRepository.ValidateUser(username, password);

            if (isValidUser)
            {
                MessageBox.Show("Login successful!");
                DashboardForm dashboardForm = new DashboardForm();
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
