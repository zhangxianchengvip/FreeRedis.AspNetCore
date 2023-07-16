using FreeRedis;
using FreeRedis.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Sample.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRedisClient client;
    private readonly FreeRedisOptions options;


    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<FreeRedisOptions> options , IRedisClient client)
    {
        _logger = logger;
        this.options = options.Value;
        this.client = client;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var ss = this.client.Get("zxc");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
