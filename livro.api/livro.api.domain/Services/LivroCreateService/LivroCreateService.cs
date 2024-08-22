using livro.api.domain.Dto;
using livro.api.persistence.Entities;
using livro.api.domain.Services.CrudBaseService;
using AutoMapper;
using FluentValidation;
using livro.api.persistence.Interfaces;
using livro.api.domain.Interfaces.LivroCreateService;

namespace livro.api.domain.Services.LivroCreateService
{
    public class LivroCreateService : CrudBaseService<LivroCreateDto, LivroEntity, Guid>, ILivroCreateService
    {

        public LivroCreateService(
            IDefaultDataModule dataModule,
            IMapper mapper,
            IValidator<LivroCreateDto> validator)
        : base(dataModule, mapper, validator)
        {
            Repository = dataModule.LivroRepository;
        }

        public override async Task<object> Handle(LivroCreateDto request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);

            var objEntity = mapper.Map<LivroEntity>(request);

            var dbEnitty = Repository.Insert(objEntity);

            await dataModule.CommitDataAsync();

            return dbEnitty.Id;
        }

    }
}
