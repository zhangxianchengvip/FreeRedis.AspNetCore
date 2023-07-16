using FreeRedis;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace FreeRedis.AspNetCore
{
    public class FreeRedisConnection : IFreeRedisPersistentConnection
    {
        private readonly FreeRedisOptions _options;

        public FreeRedisConnection(FreeRedisOptions options)
        {
            _options = options;
        }

        public RedisClient CreateRedisClient()
        {
            if (_options.ConnectPatterns == "MasterSlave")
            {
                return new RedisClient(_options.MasterSlave.Maste, _options.MasterSlave.Slaves.Select(s => ConnectionStringBuilder.Parse(s)).ToArray());
            }
            else if (_options.ConnectPatterns == "Cluster")
            {
                return new RedisClient(_options.Cluster.Mastes.Select(s => ConnectionStringBuilder.Parse(s)).ToArray());
            }
            else if (_options.ConnectPatterns == "Sentinel")
            {
                return new RedisClient(_options.Sentinel.Maste, _options.Sentinel.Sentinels.ToArray(), _options.Sentinel.RWSplitting);
            }
            else
            {
                throw new ArgumentOutOfRangeException(_options.ConnectPatterns);
            }

        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
