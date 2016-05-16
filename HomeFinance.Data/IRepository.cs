using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinance.Data
{
    public interface IRepository<T> : IEnumerable<T>
    {
        /// <summary>
        /// Bies the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T ById(int id);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}
