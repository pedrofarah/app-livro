using livro.api.persistence.Entities;

namespace livro.api.persistence.Mapping
{
    public class LivroEntityMap : BaseMap<LivroEntity, Guid>
    {
        public LivroEntityMap()
        {
            TableName = GetTableNameForEntity(nameof(LivroEntity));

            OnConfigureMap += (builder) =>
            {
                builder.HasIndex(p => p.Titulo).IsDescending(false);
            };
        }
    }
}
