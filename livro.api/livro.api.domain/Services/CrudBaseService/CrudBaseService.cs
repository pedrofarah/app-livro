using AutoMapper;
using FluentValidation;
using livro.api.domain.Dto;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Services.CrudBaseService
{
    public class CrudBaseService<RequestCommand, EntityBase, EntityBaseID>
            where RequestCommand : BaseDto
            where EntityBase : BaseEntity<EntityBaseID>
            where EntityBaseID : struct
    {
        public CrudBaseService(
            IDefaultDataModule dataModule,
            IMapper mapper,
            IValidator<RequestCommand>? validator)
        {
            this.dataModule = dataModule;
            this.mapper = mapper;
            this._validator = validator;
        }

        public readonly IDefaultDataModule dataModule;

        public readonly IMapper mapper;

        public readonly IValidator<RequestCommand>? _validator;

        public IRepository<EntityBase, EntityBaseID> Repository;

        public virtual async Task<object> Handle(RequestCommand request, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                await _validator.ValidateAndThrowAsync(request, cancellationToken);
            }

            return default;
        }

    }
}
