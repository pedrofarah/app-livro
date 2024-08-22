namespace livro.api.persistence.Entities
{
    public class LivroEntity : BaseEntity<Guid>
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Genero { get; set; }
        public int Ano { get; set; }
    }
}
