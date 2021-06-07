using BookShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    public class JournalRepository : IProductRepository<Journal>
    {
        LibraryContext _context;

        public JournalRepository(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public void Add(Journal entity)
        {
            _context.Journals.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(Journal entity)
        {
            await Task.Run(() => Add(entity));
        }

        public void Delete(Journal entity)
        {
            _context.Journals.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Journal entity)
        {
            await Task.Run(() => Delete(entity));
        }

        public IEnumerable<Journal> GetAll()
        {
            return _context.Journals;
        }

        public async Task<IEnumerable<Journal>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public void Update(Journal entity)
        {
            _context.Journals.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Journal entity)
        {
            await Task.Run(() => Update(entity));
        }
    }
}
