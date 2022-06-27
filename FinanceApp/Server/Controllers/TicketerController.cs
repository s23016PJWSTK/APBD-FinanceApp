using FinanceApp.Client.Models;
using FinanceApp.Server.Services;
using FinanceApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Controllers
{
    [Route("api/ticketer")]
    [ApiController]
    public class TicketerController : ControllerBase
    {
        private readonly ITicketerService _service;
        private readonly IConfiguration _configuration;

		public TicketerController(ITicketerService service, IConfiguration configuration)
		{
			_service = service;
			_configuration = configuration;
		}

        [HttpGet("news/{code}")]
        [Authorize]
        public async Task<IActionResult> getTicketerNews(string code)
        {
            var Http = new HttpClient();
            var uri = "https://api.polygon.io/v2/reference/news?ticker=" + code + "&order=desc&limit=5&sort=published_utc";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", "Bearer " + _configuration["KeyBase:PolygonIoApiKey"]);
            var res = await Http.SendAsync(request);
            if (res.IsSuccessStatusCode)
            {
                return Ok(await res.Content.ReadFromJsonAsync<GetFromPolygonIONews>());
            }
            return NoContent();
        }

		[HttpGet("{code}")]
        [Authorize]
        public async Task<IActionResult> getTicketerData(string code)
        {
            var Http = new HttpClient();
            var uri = "https://api.polygon.io/v2/aggs/ticker/" + code + "/range/1/day/" + DateTime.UtcNow.AddDays(-2).AddMonths(-3).ToString("yyyy-MM-dd") + "/" + DateTime.UtcNow.ToString("yyyy-MM-dd");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", "Bearer " + _configuration["KeyBase:PolygonIoApiKey"]);
            var res = await Http.SendAsync(request);
            if (res.IsSuccessStatusCode)
            {
                return Ok(await res.Content.ReadFromJsonAsync<GetFromPolygonIO>());
            }
            return NoContent();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getTicketers()
        {
            return Ok(
                await _service.GetTicketers().Select(e => new Shared.Ticketer
                {
                    Symbol = e.Symbol,
                    Name = e.Name,
                    Sector = e.Sector,
                    CEO = e.CEO,
                    Country = e.Country,
                    Logo = e.Logo,
                }).ToListAsync()
            );
        }
        [HttpGet("watchlist/{user}")]
        [Authorize]
        public async Task<IActionResult> getWatchlistForUser(string user)
        {
            return Ok(
                await _service.GetWatchList_Ticketers(user).Select(e => e.Ticketer)
                .Select(e => new Ticketer
                {
                    Symbol = e.Symbol,
                    Name = e.Name,
                    Logo = e.Logo,
                    Sector = e.Sector,
                    CEO = e.CEO,
                    Country = e.Country,
                }).ToListAsync()
            );
        }

        [HttpPost("watchlist/{user}/{TicketerId}")]
        [Authorize]
        public async Task<IActionResult> AddToWatchList(string user, int TicketerId)
        {
            if ((await _service.GetWatchList_Ticketers(user).FirstOrDefaultAsync()) == null) {
                await _service.CreateWatchList(user);
                await _service.SavaChangesToDb();
            }
            if((await _service.GetTicketer(TicketerId)) == null)
                return BadRequest();
            await _service.AddToWatchlist(user, TicketerId);
            await _service.SavaChangesToDb();
            return Ok();
        }
        [HttpDelete("watchlist/{user}/{TicketerId}")]
        [Authorize]
        public async Task<IActionResult> RemoveFromWatchList(string user, int TicketerId)
        {
            if ((await _service.GetWatchList_Ticketers(user).FirstOrDefaultAsync()) == null) 
                BadRequest();
            if ((await _service.GetTicketer(TicketerId)) == null)
                return BadRequest();
            if (_service.GetWatchList_Ticketers(user).Where(e => e.TicketerId == TicketerId) == null)
                BadRequest();
            await _service.RemoveFromWatchList(user, TicketerId);
            await _service.SavaChangesToDb();
            return Ok();
        }
    }
}
