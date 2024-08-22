namespace livro.api.domain.Dto
{
    public class BaseDto<T> where T : struct
    {
        public T? Id { get; set; }
    }
}
