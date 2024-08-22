using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace livro.api.persistence.Repository
{
    public class Repository<T, BaseID, CommomContext> : IRepository<T, BaseID>
        where T : BaseEntity<BaseID>
        where BaseID : struct
        where CommomContext : DbContext
    {
        protected readonly CommomContext _context;
        private readonly DbSet<T> _dataset;

        public Repository(CommomContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public DbSet<T> DataSet { get => _dataset; }

        public async Task<bool> DeleteAsync(BaseID id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
                return false;

            _dataset.Remove(result);

            return true;
        }

        public T Insert(T entity)
        {
            _dataset.Add(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id))
                ?? throw new NullReferenceException();

            _context.Entry(result).CurrentValues.SetValues(entity);

            return entity;
        }

        public virtual IQueryable<T> ListNoTracking(Expression<Func<T, bool>> predicate) =>
            _dataset.Where(predicate).AsNoTracking();

    }
}
