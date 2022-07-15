using FinanceApp.Client.Models;
using FinanceApp.Server.Services;
using FinanceApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            if (res.StatusCode == System.Net.HttpStatusCode.GatewayTimeout || res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return StatusCode(203, _service.LoadTicketerNewsFromDb(code));
            }
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadFromJsonAsync<GetFromPolygonIONews>();
                SaveTicketerNewsToDbIfNeeded(result, code);
                return Ok(result);
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
            if(res.StatusCode == System.Net.HttpStatusCode.GatewayTimeout || res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return StatusCode(203, _service.LoadTicketerDataFromDb(code));
            }
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadFromJsonAsync<GetFromPolygonIO>();
                SaveTicketerDataToDbIfNeeded(result);
                return Ok(result);
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
        [HttpGet("watchlist")]
        [Authorize]
        public async Task<IActionResult> getWatchlistForUser()
        {
            string user = GetEmailFromToken(HttpContext.User.Identity as ClaimsIdentity);
            if (string.IsNullOrEmpty(user))
                return BadRequest("No such user");
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

        [HttpPost("watchlist/{TicketerId}")]
        [Authorize]
        public async Task<IActionResult> AddToWatchList(int TicketerId)
        {
            string user = GetEmailFromToken(HttpContext.User.Identity as ClaimsIdentity);
            if (string.IsNullOrEmpty(user))
                return BadRequest("No such user");

            if ((await _service.GetWatchList_Ticketers(user).FirstOrDefaultAsync()) == null) {
                await _service.CreateWatchList(user);
                await _service.SavaChangesToDb();
            }
            if((await _service.GetTicketer(TicketerId)) == null)
                return BadRequest("There is no such Company in database");
            if((await _service.GetWatchList_Ticketers(user).ToListAsync()).FirstOrDefault(e => e.TicketerId == TicketerId) != null)
                return BadRequest("Already on watchlist");
            await _service.AddToWatchlist(user, TicketerId);
            await _service.SavaChangesToDb();
            return Ok();
        }
        [HttpDelete("watchlist/{TicketerId}")]
        [Authorize]
        public async Task<IActionResult> RemoveFromWatchList(int TicketerId)
        {
            string user = GetEmailFromToken(HttpContext.User.Identity as ClaimsIdentity);
            if (string.IsNullOrEmpty(user))
                return BadRequest("No such user");

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

        private async void SaveTicketerNewsToDbIfNeeded(GetFromPolygonIONews result, string code)
        {
            var inDb = _service.LoadTicketerNewsFromDb(code);
            if (inDb == null || inDb.Count == 0|| inDb.Max(e => e.published_utc) < result.results.Max(e => e.published_utc))
            {
                var toAdd = result
                    .results.Select(e => new Models.ArticleToDb
                    {
                        TicketerId = GoAroundSendingStringCode.List.FirstOrDefault(e => e.Value == code).Key,
                        name = e.publisher.name,
                        title = e.title,
                        article_url = e.article_url,
                        published_utc = e.published_utc,
                    }).ToList();
                if (inDb == null || inDb.Count == 0)
                    await _service.SaveTicketerNewsToDb(code, toAdd);
                else
                    await _service.SaveTicketerNewsToDb(code, toAdd.Where(e => e.published_utc > inDb.Max(e => e.published_utc)).ToList());
            }
        }

        private async void SaveTicketerDataToDbIfNeeded(GetFromPolygonIO result)
        {
            var inDb = _service.LoadTicketerDataFromDb(result.ticker);
            if (inDb == null || inDb.Count == 0 || inDb.Max(e => e.Date) < result.results.Max(e => DateTimeOffset.FromUnixTimeMilliseconds(e.t).DateTime)) {
                var toAdd = result
                    .results.Select(e => new Models.TicketerDataToDb
                    {
                        TicketerId = GoAroundSendingStringCode.List.FirstOrDefault(e => e.Value == result.ticker).Key,
                        Close = e.c,
                        Highest = e.h,
                        Lowest = e.l,
                        Open = e.o,
                        Date = DateTimeOffset.FromUnixTimeMilliseconds(e.t).DateTime,
                        Volume = e.v,
                    }).ToList();
                if (inDb == null || inDb.Count == 0)
                    await _service.SaveTicketerDataToDb(result.ticker, toAdd);
                else
                    await _service.SaveTicketerDataToDb(result.ticker, toAdd.Where(e => e.Date > inDb.Max(e => e.Date)).ToList());
            }
        }

        private string GetEmailFromToken(ClaimsIdentity identity)
        {
            if (!string.IsNullOrEmpty(identity.Name))
                return identity.Name;
            return string.Empty;
        }
    }
}
