namespace livro.api.domain.Dto
{
    public class BaseCrudDto<T> : BaseDto where T : struct
    {
        public T? Id { get; set; }
    }
}
