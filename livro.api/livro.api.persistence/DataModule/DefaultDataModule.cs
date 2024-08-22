using livro.api.persistence.Context;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;
using livro.api.persistence.Repository;

#nullable disable

namespace livro.api.persistence.DataModule
{
    public class DefaultDataModule(ApplicationDBContext dbContext) : BaseDataModule<ApplicationDBContext>(dbContext), IDefaultDataModule
    {
        private IRepository<LivroEntity, Guid> _livroRepository;
        public IRepository<LivroEntity, Guid> LivroRepository
        {
            get => _livroRepository ??= new Repository<LivroEntity, Guid, ApplicationDBContext>(CurrentContext);
        }
    }
}
