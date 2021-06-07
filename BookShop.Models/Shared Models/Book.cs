namespace BookShop.Models
{
    /// <summary>
    /// Represents an ordinary Book
    /// </summary>
    public class Book : Product
    {
        /// <summary>
        /// Represents Book's author
        /// </summary>
        public string Author { get; set; }
    }
}
