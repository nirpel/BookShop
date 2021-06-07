namespace BookShop.Models
{
    /// <summary>
    /// Software's user model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents account's user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Represents account's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Represents account's title & permissions
        /// </summary>
        public Authorization Title { get; set; }
    }
}
