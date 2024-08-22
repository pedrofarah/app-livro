using FluentValidation;
using livro.api.domain.Interfaces.ILivroQueryService;
using livro.api.domain.Interfaces.LivroCreateService;
using livro.api.domain.Interfaces.LivroDeleteService;
using livro.api.domain.Interfaces.LivroUpdateService;
using livro.api.domain.Services.LivroCreateService;
using livro.api.domain.Services.LivroDeleteService;
using livro.api.domain.Services.LivroGetService;
using livro.api.domain.Services.LivroUpdateService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace livro.api.domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic));

            return services;
        }

        public static IServiceCollection AddDomainConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperConfiguration();

            services.AddFluentValidationConfiguration();

            services.AddScoped<ILivroCreateService, LivroCreateService>();

            services.AddScoped<ILivroUpdateService, LivroUpdateService>();

            services.AddScoped<ILivroDeleteService, LivroDeleteService>();

            services.AddScoped<ILivroQueryService, LivroQueryService>();

            return services;
        }
    }
}
