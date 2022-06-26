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

        public TicketerController(ITicketerService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        [Authorize]
        public async Task<IActionResult> getTicketerData(string code)
        {
            var Http = new HttpClient();
            var uri = "https://api.polygon.io/v2/aggs/ticker/" + code + "/range/1/day/" + DateTime.UtcNow.AddDays(-2).AddMonths(-3).ToString("yyyy-MM-dd") + "/" + DateTime.UtcNow.ToString("yyyy-MM-dd");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", "Bearer " + "lR82_LuddiKlh3IA19BcpvRpj8mb4jAD");
            var res = await Http.SendAsync(request);
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadFromJsonAsync<GetFromPolygonIO>();
                Console.WriteLine(result.count);
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
    }
}
