using livro.api.domain.Dto;

namespace livro.api.domain.Interfaces.ILivroQueryService
{
    public interface ILivroQueryService
    {
        Task<IEnumerable<LivroDto>> Handle(LivroQueryDto request, CancellationToken cancellationToken);
    }
}
