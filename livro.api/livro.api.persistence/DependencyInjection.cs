using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using livro.api.persistence.Context;
using livro.api.persistence.DataModule;
using livro.api.persistence.Interfaces;

namespace livro.api.persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseInMemoryDatabase("DBLivroApi"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped
            );

            services.AddScoped<IDefaultDataModule, DefaultDataModule>();

            return services;
        }
    }
}
