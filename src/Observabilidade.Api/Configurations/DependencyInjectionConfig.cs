using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Observabilidade.Api.Interfaces;
using Observabilidade.Api.Models;
using Observabilidade.Api.Models.Notificador;
using Observabilidade.Api.Services;

namespace Observabilidade.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInjecaoDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ApiCepWebService>();
            services.AddHttpContextAccessor();
            services.AddScoped<LogService>();

            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }
}