using AutoMapper;
using FluentValidation;
using livro.api.domain.Dto;
using livro.api.persistence.Entities;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Services.QueryBaseService
{
    public delegate IQueryable<D> RequestQueryable<D, T, Q>(Q request); // where T : struct where Q : BaseQueryDto<T>;

    public class QueryBaseService<EntityBase, EntityBaseID, QueryBaseDto, ResponseDto>
        where EntityBase : BaseEntity<EntityBaseID>
        where EntityBaseID : struct
        where QueryBaseDto : BaseQueryDto<EntityBaseID>
        where ResponseDto : BaseDto
    {
        public readonly IBaseDataModule dataModule;

        public readonly IMapper mapper;

        public readonly IValidator<QueryBaseDto>? _validator;

        public QueryBaseService(
            IDefaultDataModule dataModule,
            IMapper mapper)
        {
            this.dataModule = dataModule;
            this.mapper = mapper;
        }

        public RequestQueryable<EntityBase, EntityBaseID, QueryBaseDto>? OnRequestData { get; set; }

        public virtual async Task<IEnumerable<ResponseDto>> Handle(QueryBaseDto request, CancellationToken cancellationToken)
        {
            var tempData = OnRequestData(request);

            return mapper.Map<IEnumerable<ResponseDto>>(source: tempData.ToList());
        }
    }
}
