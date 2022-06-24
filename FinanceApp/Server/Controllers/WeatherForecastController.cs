using FinanceApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			this.logger = logger;
		}

		[HttpGet]
		[Authorize]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)],
				UserName = User.Identity?.Name ?? string.Empty
			});
		}

		[HttpGet("{date}")]
		[Authorize]
		public WeatherForecast Get(DateTime date)
		{
			var rng = new Random();
			return new WeatherForecast
			{
				Date = date,
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)],
				UserName = User.Identity?.Name ?? string.Empty
			};
		}
	}
}