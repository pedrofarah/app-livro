using livro.api.persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace livro.api.persistence.Interfaces
{
    public interface IRepository<T, BaseID> where T : BaseEntity<BaseID> where BaseID : struct
    {
        T Insert(T entity);
        Task<T> UpdateAsync(T entity);
        IQueryable<T> ListNoTracking(Expression<Func<T, bool>> predicate);
        DbSet<T> DataSet { get; }
        Task<bool> DeleteAsync(BaseID id);
    }
}
