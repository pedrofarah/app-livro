namespace livro.api.persistence.Entities
{
    public class BaseEntity<T> where T : struct
    {
        public required T Id { get; set; }
    }
}
