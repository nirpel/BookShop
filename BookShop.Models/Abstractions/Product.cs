namespace BookShop.Models
{
    /// <summary>
    /// Represents a general Library readable item
    /// </summary>
    public abstract class Product
    {        
        /// <summary>
        /// Represents Product's unique identifyer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents Product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents Product's starting price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Repesents the amount of available instances in stock 
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// Represents the discount percentage dividev by 100 - between 0 to 1
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Represents Product's genre
        /// </summary>
        public Genre Genre { get; set; }
    }
}
