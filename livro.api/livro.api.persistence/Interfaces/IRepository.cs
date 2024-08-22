using livro.api.persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace livro.api.persistence.Interfaces
{
    public interface IRepository<T, BaseID> where T : BaseEntity<BaseID> where BaseID : struct
    {
        T Insert(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T?> SelectSingleAsync(BaseID id);
        Task<IEnumerable<T>> SelectAsync();
        Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate);
        //Task<bool> IsExists(BaseID id);
        IQueryable<T> ListNoTracking(Expression<Func<T, bool>> predicate);
        IQueryable<T> List(Expression<Func<T, bool>> predicate);
        Task<T?> FirstOrDefaultNoTrackingAsync(Expression<Func<T, bool>> predicate);
        DbSet<T> DataSet { get; }
        bool InsertList(List<T> listEntity);
        Task<bool> UpdateListAsync(List<T> listEntity);
        Task<bool> DeleteAsync(BaseID id);
        bool Delete(T entity);
    }
}
