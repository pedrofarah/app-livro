using AutoMapper;
using FluentValidation;
using livro.api.domain.Dto;
using livro.api.domain.Interfaces.LivroDeleteService;
using livro.api.domain.Services.CrudBaseService;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Services.LivroDeleteService
{
    public class LivroDeleteService : CrudBaseService<LivroDeleteDto, LivroEntity, Guid>, ILivroDeleteService
    {
        public LivroDeleteService(
            IDefaultDataModule dataModule,
            IMapper mapper,
            IValidator<LivroDeleteDto> validator)
        : base(dataModule, mapper, validator)
        {
            Repository = dataModule.LivroRepository;
        }

        public override async Task<object> Handle(LivroDeleteDto request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);

            var objEntity = mapper.Map<LivroEntity>(request);

            _ = await Repository.DeleteAsync(objEntity.Id);

            await dataModule.CommitDataAsync();

            return true;

        }
    }
}
