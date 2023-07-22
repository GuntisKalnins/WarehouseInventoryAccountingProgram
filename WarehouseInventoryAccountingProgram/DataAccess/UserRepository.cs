namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System.Configuration;
    using System.Data.SqlClient;
    using WarehouseInventoryAccountingProgram.Helpers.DataAccess;
    using WarehouseInventoryAccountingProgram.Interfaces;

    /// <summary>
    /// Class for accessing user data in the database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the UserRepository class.
        /// </summary>
        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Validates the user login information against the database.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        public bool ValidateUser(string username, string password)
        {
            bool isValidUser = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Password FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                string storedPassword = command.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(storedPassword))
                {
                    isValidUser = PasswordHelper.ValidatePassword(password, storedPassword);
                }

                connection.Close();
            }

            return isValidUser;
        }

        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The hashed password of the new user.</param>
        public bool RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
