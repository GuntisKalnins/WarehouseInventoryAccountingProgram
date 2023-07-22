namespace WarehouseInventoryAccountingProgram.Helpers.DataAccess
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Class for securely hashing and validating passwords.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes a plain text password using SHA256.
        /// </summary>
        /// <param name="password">The plain text password.</param>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Validates a plain text password against its hashed counterpart.
        /// </summary>
        /// <param name="plainPassword">The plain text password entered by the user.</param>
        /// <param name="hashedPassword">The hashed password stored in the database.</param>
        public static bool ValidatePassword(string plainPassword, string hashedPassword)
        {
            string hashedPlainPassword = HashPassword(plainPassword);
            return string.Equals(hashedPlainPassword, hashedPassword);
        }
    }
}
