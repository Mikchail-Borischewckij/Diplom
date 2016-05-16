using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal abstract class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly IQueryable<T> _query;

        protected RepositoryBase(DbContext context)
        {
            _context = context;
            _query = context.Set<T>();
        }

        protected DbContext Context
        {
            get { return _context; }
        }

        protected IQueryable<T> Query
        {
            get { return _query; }
        }

        public virtual T ById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Create(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public bool Update(T entity)
        {
            T original = ById(entity.Id);
            if (original == null)
            {
                return false;
            }
            _context.Entry(original).CurrentValues.SetValues(entity);
            return true;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return Query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
