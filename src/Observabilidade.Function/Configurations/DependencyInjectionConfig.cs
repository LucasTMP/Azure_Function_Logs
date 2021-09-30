using Microsoft.Extensions.DependencyInjection;
using Observabilidade.Function.Data;
using Observabilidade.Function.Data.Interfaces;
using Observabilidade.Function.Services;
using Observabilidade.Function.Services.Interfaces;
using System;

namespace Observabilidade.Function.Configurations
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(dbContext => new MongoDbContext(
                        Environment.GetEnvironmentVariable("ConnectionStrings:MongoDb"),
                        Environment.GetEnvironmentVariable("ConnectionStrings:DbName")));

            services.AddScoped(elastic => new ElasticSearch(
                        Environment.GetEnvironmentVariable("ConnectionStrings:IndexName"),
                        Environment.GetEnvironmentVariable("ConnectionStrings:ElasticUrl")));

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }

    }
}
