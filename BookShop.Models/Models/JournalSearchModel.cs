namespace BookShop.Models
{
    /// <summary>
    /// Model for searching one or more <see cref="Journal"/>s
    /// </summary>
    public class JournalSearchModel : ProductSearchModel
    {
        /// <summary>
        /// Maximum edition number for required <see cref="Journal"/>
        /// </summary>
        public int? MaxEditionNumber { get; set; }

        /// <summary>
        /// Minimum edition number for required <see cref="Journal"/>
        /// </summary>
        public int? MinEditionNumber { get; set; }
    }
}
