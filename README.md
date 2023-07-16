# FreeRedis.AspNetCore   

#### 介绍
#### FreeRedis Asp.Net Core   服务注册扩展

1. 安装

- [Package Manager](https://www.nuget.org/packages/FreeRedis.AspNetCore)

```
Install-Package FreeRedis.AspNetCore
```

- [.NET CLI](https://www.nuget.org/packages/FreeRedis.AspNetCore)

```
dotnet add package FreeRedis.AspNetCore
```

2. 注册FreeRedis

```c#
builder.Services.AddFreeRedis(builder.Configuration);
```

3. 构造函数调用

```C#
private readonly IRedisClient _client;
public WeatherForecastController(IRedisClient client)
{
  _client = client;
}
```

4.配置文件

```json
{
 "FreeRedisOptions": {
    "ConnectPatterns": "MasterSlave",//连接模式 MasterSlave 、Cluster、Sentinel
    "MasterSlave": {//主从
      "Maste": "137.0.0.1:6379,defaultDatabase=0"
    },
    "Cluster": {//集群
      "Mastes": [ "127.0.0.1:6379,defaultDatabase=0" ]
    },
    "Sentinel": {//哨兵
      "Maste": "127.0.0.1:6379,defaultDatabase=0",
      "Sentinels": [],
      "RWSplitting": true
    }
  }
}
```

