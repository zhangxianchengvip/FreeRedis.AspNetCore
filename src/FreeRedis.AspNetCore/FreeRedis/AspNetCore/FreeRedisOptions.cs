using Auto.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeRedis.AspNetCore
{
    [AutoOptions]
    public class FreeRedisOptions
    {

        private const string DefaultHost = "localhost";

        private const int DefaultPort = 6379;

        private const int DefaultDatabase = 0;

        public static readonly string DefaultConnection = $"{DefaultHost}:{DefaultPort},defaultDatabase={DefaultDatabase}";

        public string ConnectPatterns { get; set; }
        public MasterSlave MasterSlave { get; set; }
        public Cluster Cluster { get; set; }
        public Sentinel Sentinel { get; set; }


    }

    public class MasterSlave
    {
        public string Maste { get; set; } = FreeRedisOptions.DefaultConnection;
        public List<string> Slaves { get; set; } = new List<string>();
    }

    public class Cluster
    {
        public List<string> Mastes { get; set; } = new List<string>();
    }
    public class Sentinel
    {
        public string Maste { get; set; } = FreeRedisOptions.DefaultConnection;
        public List<string> Sentinels { get; set; } = new List<string>();
        public bool RWSplitting { get; set; }
    }
}
