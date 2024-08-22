namespace livro.api.domain.Dto
{
    public class BaseQueryDto<T> : BaseDto where T : struct
    {
        public T? Id { get; set; }
    }
}
