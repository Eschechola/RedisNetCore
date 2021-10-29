using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisNetCore.Data.Interfaces;
using RedisNetCore.Data.Services;

namespace RedisNetCore.Data.IoC
{
    public static class DataDependencies
    {
        public static IServiceCollection AddRedisDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Redis:ConnectionString"];
            var instanceName = configuration["Redis:InstanceName"];

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = instanceName;
            });

            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}