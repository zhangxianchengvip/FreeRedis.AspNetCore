using Auto.Options;
using FreeRedis.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeRedis.AspNetCore
{
    public static class FreeRedisExtensions
    {
        public static IServiceCollection AddFreeRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoOptions(configuration);

            services.AddSingleton<IRedisClient, RedisClient>(sp =>
            {
                var options = configuration.GetOptions<FreeRedisOptions>();

                return new FreeRedisConnection(options).CreateRedisClient();
            });

            return services;
        }
    }
}
