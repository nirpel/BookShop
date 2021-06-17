using BookShop.DAL;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository<Book> _bookRepo;
        private readonly IProductRepository<Journal> _journalRepo;

        public ProductService(IProductRepository<Book> bookRepo, IProductRepository<Journal> journalRepo)
        {
            _bookRepo = bookRepo;
            _journalRepo = journalRepo;
        }

        public async Task AddBookAsync(Book book)
        {
            if (await IsBookExistsAsync(new BookIdentifier(book.Name, book.Author)))
            {
                
            }
        }

        public Task AddJournalAsync(Journal journal)
        {
            throw new NotImplementedException();
        }

        public Task EditBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task EditJournalAsync(Journal journal)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> SearchBooksAsync(BookSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Journal>> SearchJournalsAsync(JournalSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public Task SellBookAsync(int id, int quantitiesToSell)
        {
            throw new NotImplementedException();
        }

        public Task SellJournalAsync(int id, int quantitiesToSell)
        {
            throw new NotImplementedException();
        }

        #region Private Helpers

        private async Task<bool> IsBookExistsAsync(BookIdentifier book)
        {
            var books = await _bookRepo.GetAllAsync();
            return books.FirstOrDefault(b =>
                b.Name == book.name && b.Author == book.author) != null;
        }

        private async Task<bool> IsJournalExistsAsync(JournalIdentifier journal)
        {
            var journals = await _journalRepo.GetAllAsync();
            return journals.FirstOrDefault(j =>
                j.Name == journal.name && j.EditionNumber == journal.editionNumber) != null;
        }

        #endregion

    }
}
