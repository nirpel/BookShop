using BookShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    public class BookRepository : IProductRepository<Book>
    {
        LibraryContext _context;

        public BookRepository(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(Book entity)
        {
            await Task.Run(() => Add(entity));
        }

        public void Delete(Book entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Book entity)
        {
            await Task.Run(() => Delete(entity));
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public void Update(Book entity)
        {
            _context.Books.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Book entity)
        {
            await Task.Run(() => Update(entity));
        }
    }
}
