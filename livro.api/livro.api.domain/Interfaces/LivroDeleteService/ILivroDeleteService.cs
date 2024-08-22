using livro.api.domain.Dto;

namespace livro.api.domain.Interfaces.LivroDeleteService
{
    public interface ILivroDeleteService
    {
        Task<object> Handle(LivroDeleteDto request, CancellationToken cancellationToken);
    }
}
