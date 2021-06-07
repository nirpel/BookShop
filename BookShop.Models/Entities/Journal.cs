namespace BookShop.Models
{
    /// <summary>
    /// Represents an ordinary Journal
    /// </summary>
    public class Journal : Product
    {
        /// <summary>
        /// Represents Journal's specific Edition number
        /// </summary>
        public int EditionNumber { get; set; }
    }
}
