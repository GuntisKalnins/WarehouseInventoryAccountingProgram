namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Class for accessing user data in the database.
    /// </summary>
    public class UserRepository
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
        /// Validates the user's login information against the database.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>True if the user is valid, false otherwise.</returns>
        public bool ValidateUser(string username, string password)
        {
            bool isValidUser = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    isValidUser = true;
                }

                connection.Close();
            }

            return isValidUser;
        }
    }
}
