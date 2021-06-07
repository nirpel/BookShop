using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    /// <summary>
    /// Handler for bookshop's products operations
    /// </summary>
    public interface IProductService
    {
        #region Book

        /// <summary>
        /// Search for one or more <see cref="Book"/>s by required conditions
        /// </summary>
        /// <param name="searchModel">Model of required conditions for specific <see cref="Book"/>s</param>
        /// <returns>List of existing <see cref="Book"/>s who matched the searching requirements</returns>
        IEnumerable<Book> SearchBooks(BookSearchModel searchModel);

        /// <summary>
        /// Add a new <see cref="Book"/> to the shop. 
        /// If a <see cref="Book"/> with the same name & author already exists, the units will be added to the existed <see cref="Book"/> in stock.
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Book book);

        /// <summary>
        /// Sell a <see cref="Book"/> from shop's stock.
        /// </summary>
        /// <param name="id">Id of the required <see cref="Book"/> to sell</param>
        /// <param name="quantitiesToSell">Amount of quantites to sell from stock</param>
        void SellBook(int id, int quantitiesToSell);

        /// <summary>
        /// Edit <see cref="Book"/> details from shop's stock
        /// </summary>
        /// <param name="book">The updated <see cref="Book"/>, ready to be saved in system's stock</param>
        void EditBook(Book book);

        #endregion

        #region Journal

        /// <summary>
        /// Search for one or more <see cref="Journal"/>s by required conditions
        /// </summary>
        /// <param name="searchModel">Model of required conditions for specific <see cref="Journal"/>s</param>
        /// <returns>List of existing <see cref="Journal"/>s who matched the searching requirements</returns>
        IEnumerable<Journal> SearchJournals(JournalSearchModel searchModel);

        /// <summary>
        /// Add a new <see cref="Journal"/> to the shop. 
        /// If a <see cref="Journal"/> with the same name & edition number already exists, the units will be added to the existed <see cref="Journal"/> in stock.
        /// </summary>
        /// <param name="journal"></param>
        void AddJournal(Journal journal);

        /// <summary>
        /// Sell a <see cref="Journal"/> from shop's stock.
        /// </summary>
        /// <param name="id">Id of the required <see cref="Journal"/> to sell</param>
        /// <param name="quantitiesToSell">Amount of quantites to sell from stock</param>
        void SellJournal(Journal journal);

        /// <summary>
        /// Edit <see cref="Journal"/> details from shop's stock
        /// </summary>
        /// <param name="journal">The updated <see cref="Journal"/>, ready to be saved in system's stock</param>
        void EditJournal(Journal journal);

        #endregion
    }
}
