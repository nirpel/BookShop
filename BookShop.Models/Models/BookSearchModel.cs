namespace BookShop.Models
{
    /// <summary>
    /// Model for searching one or more <see cref="Book"/>s
    /// </summary>
    public class BookSearchModel : ProductSearchModel
    {
        /// <summary>
        /// Exact or part of the author's name of required <see cref="Book"/>s
        /// </summary>
        public string Author { get; set; }
    }
}
