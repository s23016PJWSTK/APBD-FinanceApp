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
            //var stringCode = GoAroundSendingStringCode.List.Where(e => e.Key == code).FirstOrDefault().Value;
            using (var res = await Http.GetAsync("https://api.polygon.io/v2/aggs/ticker/" + code + "/range/1/day/" + DateTime.UtcNow.AddMonths(-3).AddDays(-2).ToString("yyyy-MM-dd") + "/" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "?apiKey=lR82_LuddiKlh3IA19BcpvRpj8mb4jAD"))
            {
                if (res.IsSuccessStatusCode)
                {
                    return Ok(await res.Content.ReadFromJsonAsync<GetFromPolygonIO>());
                }
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
