using AutoMapper;
using FluentValidation;
using livro.api.domain.Dto;
using livro.api.domain.Interfaces.LivroUpdateService;
using livro.api.domain.Services.CrudBaseService;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Services.LivroUpdateService
{
    public class LivroUpdateService : CrudBaseService<LivroUpdateDto, LivroEntity, Guid>, ILivroUpdateService
    {
        public LivroUpdateService(
            IDefaultDataModule dataModule,
            IMapper mapper,
            IValidator<LivroUpdateDto> validator)
        : base(dataModule, mapper, validator)
        {
            Repository = dataModule.LivroRepository;
        }

        public override async Task<object> Handle(LivroUpdateDto request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);

            var dbEntity = mapper.Map<LivroEntity>(request);

            await Repository.UpdateAsync(dbEntity);

            await dataModule.CommitDataAsync();

            return true;
        }
    }
}
