using FluentValidation;
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
    }
}
