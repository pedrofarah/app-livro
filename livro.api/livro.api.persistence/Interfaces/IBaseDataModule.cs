namespace livro.api.persistence.Interfaces
{
    public interface IBaseDataModule
    {
        Task<bool> StartTransactionAsync();
        Task CommitDataAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
