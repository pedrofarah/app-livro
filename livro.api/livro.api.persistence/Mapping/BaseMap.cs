using livro.api.persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace livro.api.persistence.Mapping
{
    public delegate void ConfigureMap<T>(EntityTypeBuilder<T> builder) where T : class;

    public class BaseMap<TEntity, BaseID> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<BaseID>
        where BaseID : struct
    {

        public ConfigureMap<TEntity>? OnConfigureMap { get; set; }

        public required string TableName { get; set; }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            switch (Type.GetTypeCode(typeof(BaseID)))
            {
                case TypeCode.Int64:
                    builder
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd()
                        .IsRequired();
                    break;
                default:
                    builder
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd()
                        .HasValueGenerator<GuidValueGenerator>()
                        .IsRequired();
                    break;
            }

            builder.HasKey(p => p.Id);

            OnConfigureMap?.Invoke(builder);
        }

        public string GetTableNameForEntity(string StrEntity)
        {
            return StrEntity.ToLower().Replace("entity", "");
        }

    }
}
