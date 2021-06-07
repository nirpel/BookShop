using System.Collections.Generic;

namespace BookShop.Models
{
    /// <summary>
    /// Abstract Model for searching a <see cref="Product"/>
    /// </summary>
    public abstract class ProductSearchModel
    {
        /// <summary>
        /// Exact or part of the name of required products
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Maximum price for products
        /// </summary>
        public double? MaxPrice { get; set; }

        /// <summary>
        /// Minimum price for products
        /// </summary>
        public double? MinPrice { get; set; }

        /// <summary>
        /// Maximum units in stock for products
        /// </summary>
        public int? MaxUnitsInStock { get; set; }

        /// <summary>
        /// Minimum units in stock for products
        /// </summary>
        public int? MinUnitsInStock { get; set; }

        /// <summary>
        /// Maximum discount percentage for products
        /// </summary>
        public double? MaxDiscount { get; set; }

        /// <summary>
        /// Minimum discount percentage for products
        /// </summary>
        public double? MinDiscount { get; set; }

        /// <summary>
        /// List of genres of required products
        /// </summary>
        public IEnumerable<Genre> Genres { get; set; }

    }
}
