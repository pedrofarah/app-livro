using livro.api.persistence.Entities;

namespace livro.api.persistence.Interfaces
{
    public interface IDefaultDataModule : IBaseDataModule
    {
        IRepository<LivroEntity, Guid> LivroRepository { get; }
    }
}
