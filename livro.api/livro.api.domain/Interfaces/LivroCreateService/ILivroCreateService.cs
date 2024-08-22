using livro.api.domain.Dto;

namespace livro.api.domain.Interfaces.LivroCreateService
{
    public interface ILivroCreateService
    {
        Task<object> Handle(LivroCreateDto request, CancellationToken cancellationToken);
    }
}
