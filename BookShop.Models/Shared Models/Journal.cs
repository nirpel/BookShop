using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
