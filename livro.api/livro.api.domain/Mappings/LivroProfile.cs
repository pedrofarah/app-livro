using AutoMapper;
using livro.api.domain.Dto;
using livro.api.persistence.Entities;

namespace livro.api.domain.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<LivroEntity, LivroDto>().ReverseMap();
        }
    }
}
