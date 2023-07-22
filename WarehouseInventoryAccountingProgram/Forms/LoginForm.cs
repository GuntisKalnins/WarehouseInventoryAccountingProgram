namespace WarehouseInventoryAccountingProgram.Forms
{
    using System;
    using System.Windows.Forms;
    using WarehouseInventoryAccountingProgram.DataAccess;
    using WarehouseInventoryAccountingProgram.Helpers.DataAccess;

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
        /// Handles the button click and validates the user's login information against the database.
        /// </summary>
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

        /// <summary>
        /// Handles the button click to open the registration form.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a username and password.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password before storing it in the database
            string hashedPassword = PasswordHelper.HashPassword(password);

            // Store the new user in the database (you need to implement the actual database insertion logic here)
            bool isRegistered = userRepository.RegisterUser(username, hashedPassword);

            if (isRegistered)
            {
                MessageBox.Show("Registration successful! You can now log in with your new account.");
            }
            else
            {
                MessageBox.Show("Failed to register user. Please try again.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
