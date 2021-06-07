using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    public class JournalRepository : IProductRepository<Journal>
    {
        public void Add(Journal entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Journal entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Journal entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Journal entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Journal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Journal>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Journal entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Journal entity)
        {
            throw new NotImplementedException();
        }
    }
}
