namespace livro.api.domain.Dto
{
    public class LivroDto : BaseCrudDto<Guid>
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Genero { get; set; }
        public int? Ano { get; set; }
    }
}
