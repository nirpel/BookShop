using BookShop.DAL;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    /// <summary>
    /// Service for handling <see cref="Product"/> operations
    /// </summary>
    public class ProductService : IProductService
    {
        #region Private Members

        private readonly IProductRepository<Book> _bookRepo;
        private readonly IProductRepository<Journal> _journalRepo;

        #endregion

        #region C'tor

        public ProductService(IProductRepository<Book> bookRepo, IProductRepository<Journal> journalRepo)
        {
            _bookRepo = bookRepo;
            _journalRepo = journalRepo;
        }

        #endregion

        #region Book Handling

        public async Task AddBookAsync(Book book)
        {
            // Check if book already exists (not new to stock)
            if (await IsBookExistsAsync(new BookIdentifier(book.Name, book.Author)))
            {
                // Get the existed book from stock
                var existedBook = await GetBookByIdentifierAsync(new BookIdentifier(book.Name, book.Author));

                // Add the quantites from the given book parameter to existed book in stock & Save
                existedBook.UnitsInStock += book.UnitsInStock;
                await EditBookAsync(book);
            }
            else
            {
                // Add book to stock as new
                await _bookRepo.AddAsync(book);
            }
        }

        public async Task EditBookAsync(Book book)
        {
            await _bookRepo.UpdateAsync(book);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(BookSearchModel searchModel)
        {
            var searchedBooks = await _bookRepo.GetAllAsync();
            SearchByAuthor(searchModel.Author, searchedBooks);
            SearchProduct(searchModel, searchedBooks);
            return searchedBooks;
        }

        public async Task SellBookAsync(int id, int quantitiesToSell)
        {
            // Get instance of required book to sell
            Book bookToSell = await GetBookByIdAsync(id);

            // If book not exists, do not affect
            if (bookToSell == null)
                return;

            // Check if book has more units in stock than required quantites
            if (quantitiesToSell < bookToSell.UnitsInStock)
            {
                // Decrease book's units in stock & Save changes
                bookToSell.UnitsInStock -= quantitiesToSell;
                await _bookRepo.UpdateAsync(bookToSell);
            }
            else
            {
                // If required quantites are equal or bigger than book's units, delete book (0 left in stock) 
                await _bookRepo.DeleteAsync(bookToSell);
            }
        }

        #endregion

        #region Journal Handling

        public async Task AddJournalAsync(Journal journal)
        {
            // Check if journal already exists (not new to stock)
            if (await IsJournalExistsAsync(new JournalIdentifier(journal.Name, journal.EditionNumber)))
            {
                // Get the existed journal from stock
                var existedJournal = await GetJournalByIdentifierAsync(new JournalIdentifier(journal.Name, journal.EditionNumber));

                // Add the quantites from the given journal parameter to existed journal in stock & Save
                existedJournal.UnitsInStock += journal.UnitsInStock;
                await EditJournalAsync(journal);
            }
            else
            {
                // Add journal to stock as new
                await _journalRepo.AddAsync(journal);
            }
        }

        public async Task EditJournalAsync(Journal journal)
        {
            await _journalRepo.UpdateAsync(journal);
        }

        public async Task<IEnumerable<Journal>> SearchJournalsAsync(JournalSearchModel searchModel)
        {
            var searchedJournals = await _journalRepo.GetAllAsync();
            SearchByMaxEditionNumber(searchModel.MaxEditionNumber, searchedJournals);
            SearchByMinEditionNumber(searchModel.MinEditionNumber, searchedJournals);
            SearchProduct(searchModel, searchedJournals);
            return searchedJournals;
        }

        public async Task SellJournalAsync(int id, int quantitiesToSell)
        {
            // Get instance of required journal to sell
            Journal journalToSell = await GetJournalByIdAsync(id);

            // If journal not exists, do not affect
            if (journalToSell == null)
                return;

            // Check if journal has more units in stock than required quantites
            if (quantitiesToSell < journalToSell.UnitsInStock)
            {
                // Decrease journal's units in stock & Save changes
                journalToSell.UnitsInStock -= quantitiesToSell;
                await _journalRepo.UpdateAsync(journalToSell);
            }
            else
            {
                // If required quantites are equal or bigger than journal's units, delete journal (0 left in stock) 
                await _journalRepo.DeleteAsync(journalToSell);
            }
        }

        #endregion

        #region Private Helpers

        private async Task<bool> IsBookExistsAsync(BookIdentifier book)
        {
            var foundBook = await GetBookByIdentifierAsync(book);
            return foundBook != null;
        }

        private async Task<bool> IsJournalExistsAsync(JournalIdentifier journal)
        {
            var foundJournal = await GetJournalByIdentifierAsync(journal);
            return foundJournal != null;
        }

        private async Task<Book> GetBookByIdentifierAsync(BookIdentifier book)
        {
            var books = await _bookRepo.GetAllAsync();
            return books.FirstOrDefault(b => b.Name == book.name && b.Author == book.author);
        }

        private async Task<Journal> GetJournalByIdentifierAsync(JournalIdentifier journal)
        {
            var journals = await _journalRepo.GetAllAsync();
            return journals.FirstOrDefault(j => j.Name == journal.name && j.EditionNumber == journal.editionNumber);
        }

        private async Task<Book> GetBookByIdAsync(int id)
        {
            var books = await _bookRepo.GetAllAsync();
            return books.FirstOrDefault(book => book.Id == id);
        }

        private async Task<Journal> GetJournalByIdAsync(int id)
        {
            var journals = await _journalRepo.GetAllAsync();
            return journals.FirstOrDefault(journal => journal.Id == id);
        }

        #endregion

        #region Private Search Methods

        private void SearchByAuthor(string author, IEnumerable<Book> bookList)
        {
            if (author == null || bookList == null)
                return;

            bookList = bookList.Where(book => book.Author.ToLower().Contains(author.ToLower()));
        }

        private void SearchByMinEditionNumber(int? minEditionNumber, IEnumerable<Journal> journalList)
        {
            if (minEditionNumber == null || journalList == null)
                return;

            journalList = journalList.Where(journal => journal.EditionNumber >= minEditionNumber);
        }

        private void SearchByMaxEditionNumber(int? maxEditionNumber, IEnumerable<Journal> journalList)
        {
            if (maxEditionNumber == null || journalList == null)
                return;

            journalList = journalList.Where(journal => journal.EditionNumber <= maxEditionNumber);
        }

        private void SearchProduct(ProductSearchModel searchModel, IEnumerable<Product> productList)
        {
            SearchByName(searchModel.Name, productList);
            SearchByMaxPrice(searchModel.MaxPrice, productList);
            SearchByMinPrice(searchModel.MinPrice, productList);
            SearchByMaxUnitsInStock(searchModel.MaxUnitsInStock, productList);
            SearchByMinUnitsInStock(searchModel.MinUnitsInStock, productList);
            SearchByMaxDiscount(searchModel.MaxDiscount, productList);
            SearchByMinDiscount(searchModel.MinDiscount, productList);
            SearchByGenres(searchModel.Genres, productList);
        }

        private void SearchByName(string name, IEnumerable<Product> productList)
        {
            if (name == null || productList == null)
                return;

            productList = productList.Where(prod => prod.Name.ToLower().Contains(name.ToLower()));
        }

        private void SearchByMaxPrice(double? maxPrice, IEnumerable<Product> productList)
        {
            if (maxPrice == null || productList == null)
                return;

            productList = productList.Where(prod => prod.Price <= maxPrice);
        }

        private void SearchByMinPrice(double? minPrice, IEnumerable<Product> productList)
        {
            if (minPrice == null || productList == null)
                return;

            productList = productList.Where(prod => prod.Price >= minPrice);
        }

        private void SearchByMaxUnitsInStock(int? maxUnitsInStock, IEnumerable<Product> productList)
        {
            if (maxUnitsInStock == null || productList == null)
                return;

            productList = productList.Where(prod => prod.UnitsInStock <= maxUnitsInStock);
        }

        private void SearchByMinUnitsInStock(int? minUnitsInStock, IEnumerable<Product> productList)
        {
            if (minUnitsInStock == null || productList == null)
                return;

            productList = productList.Where(prod => prod.UnitsInStock >= minUnitsInStock);
        }

        private void SearchByMaxDiscount(double? maxDiscount, IEnumerable<Product> productList)
        {
            if (maxDiscount == null || productList == null)
                return;

            productList = productList.Where(prod => prod.Discount <= maxDiscount);
        }

        private void SearchByMinDiscount(double? minDiscount, IEnumerable<Product> productList)
        {
            if (minDiscount == null || productList == null)
                return;

            productList = productList.Where(prod => prod.Discount >= minDiscount);
        }

        private void SearchByGenres(IEnumerable<Genre> genres, IEnumerable<Product> productList)
        {
            if (genres == null || productList == null)
                return;

            productList = productList.Where(prod => genres.Contains(prod.Genre));
        }

        #endregion

    }
}
