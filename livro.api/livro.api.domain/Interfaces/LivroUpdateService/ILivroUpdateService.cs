using livro.api.domain.Dto;

namespace livro.api.domain.Interfaces.LivroUpdateService
{
    public interface ILivroUpdateService
    {
        Task<object> Handle(LivroUpdateDto request, CancellationToken cancellationToken);
    }
}
