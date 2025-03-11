using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletsController : ControllerBase
{

    private readonly ILogger<WalletsController> _logger;

    public WalletsController(ILogger<WalletsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Retorna todas las Wallets creadas por el usuario 
    /// </summary>
    [HttpGet]
    public IEnumerable<WeatherForecast> GetAll()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),

        })
        .ToArray();
    }

    /// <summary>
    /// Retorna todas las Wallets creadas por el usuario 
    /// </summary>
    [HttpGet("{id}")]
    public IEnumerable<WeatherForecast> GetById(int id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),

        })
        .ToArray();
    }

    /// <summary>
    /// Crea un nuevo Wallet
    /// </summary>
    [HttpPost]
    public IEnumerable<WeatherForecast> Create(int id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),

        })
        .ToArray();
    }

    /// <summary>
    /// Actualiza la informacion de la Wallet
    /// </summary>
    [HttpPut]
    public IEnumerable<WeatherForecast> Update(int id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),

        })
        .ToArray();
    }

    /// <summary>
    /// Elimina la Wallet creadas por el usuario. 
    /// </summary>
    [HttpDelete("{id}")]
    public IEnumerable<WeatherForecast> DeleteById(int id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),

        })
        .ToArray();
    }
}
