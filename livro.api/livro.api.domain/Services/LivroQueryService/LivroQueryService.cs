using AutoMapper;
using livro.api.domain.Dto;
using livro.api.domain.Interfaces.ILivroQueryService;
using livro.api.domain.Services.QueryBaseService;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Services.LivroGetService
{
    public class LivroQueryService : QueryBaseService<LivroEntity, Guid, LivroQueryDto, LivroDto>, ILivroQueryService
    {
        public LivroQueryService(
            IDefaultDataModule dataModule,
            IMapper mapper) : base(dataModule, mapper) 
        {
            OnRequestData += (LivroQueryDto request) =>
            {
                return dataModule.LivroRepository
                .ListNoTracking(x =>
                        ((!request.Id.HasValue || x.Id.Equals(request.Id))
                    )
                )
                .OrderBy(x => x.Titulo);
            };
        }

    }
}
