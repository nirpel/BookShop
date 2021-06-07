using BookShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    /// <summary>
    /// Handler of Asynchronous operations with <see cref="Product"/> data
    /// </summary>
    /// <typeparam name="T">Specified <see cref="Product"/> type</typeparam>
    public interface IProductRepository<T>
        where T : Product
    {
        /// <summary>
        /// Add new entity to database async
        /// </summary>
        /// <param name="entity">Entity to add</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Add new entity to database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Delete an entity from database async
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Delete an entity from database
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(T entity);

        /// <summary>
        /// Save & Update an entity from within te database async
        /// </summary>
        /// <param name="entity">The updated entity to save</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Save & Update an entity from within te database
        /// </summary>
        /// <param name="entity">The updated entity to save</param>
        void Update(T entity);

        /// <summary>
        /// Get a list of entire entities from database async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get a list of entire entities from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
    }
}
