using AutoMapper;
using livro.api.domain.Dto;
using livro.api.persistence.Entities;

namespace livro.api.domain.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<LivroEntity, LivroCreateDto>().ReverseMap();
            CreateMap<LivroEntity, LivroUpdateDto>().ReverseMap();
            CreateMap<LivroEntity, LivroDeleteDto>().ReverseMap();
            CreateMap<LivroEntity, LivroQueryDto>().ReverseMap();
            CreateMap<LivroEntity, LivroDto>().ReverseMap();
        }
    }
}
