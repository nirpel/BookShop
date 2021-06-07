using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    public interface IProductService
    {
        #region Book

        IEnumerable<Book> SearchBooks();

        #endregion

        #region Journal


        #endregion
    }
}
