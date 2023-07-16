using FreeRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeRedis.AspNetCore
{
    public interface IFreeRedisPersistentConnection : IDisposable
    {
        public RedisClient CreateRedisClient();
    }
}
