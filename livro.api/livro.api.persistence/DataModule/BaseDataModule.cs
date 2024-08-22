using livro.api.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace livro.api.persistence.DataModule
{
    public class BaseDataModule<TDbContext>(TDbContext dbContext) : IBaseDataModule, IDisposable where TDbContext : DbContext
    {
        public readonly TDbContext CurrentContext = dbContext;

        private bool ActiveTransaction { get; set; } = false;

        private bool _disposed = false;

        public async Task<bool> StartTransactionAsync()
        {
            await CurrentContext.Database.BeginTransactionAsync();
            ActiveTransaction = true;
            return ActiveTransaction;
        }

        public async Task CommitDataAsync()
        {
            await CurrentContext.SaveChangesAsync();
            if (ActiveTransaction)
            {
                await CommitTransactionAsync();
                ActiveTransaction = false;
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (ActiveTransaction)
            {
                await CurrentContext.Database.CommitTransactionAsync();
                ActiveTransaction = false;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (ActiveTransaction)
            {
                await CurrentContext.Database.RollbackTransactionAsync();
                ActiveTransaction = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                CurrentContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
