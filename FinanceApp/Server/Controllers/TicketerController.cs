using FinanceApp.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketerController : ControllerBase
    {
        [HttpGet("{symbol}")]
        [Authorize]
        public async Task<IActionResult> getTicketersDataAsync(String symbol)
        {
            //using (var res = await Http.GetAsync("https://api.polygon.io/v2/aggs/ticker/" + stringCode + "/range/1/day/2020-06-01/2020-06-17?apiKey=lR82_LuddiKlh3IA19BcpvRpj8mb4jAD"))
            //{
                //if (res.IsSuccessStatusCode)
                //{
                    //var json = await res.Content.ReadFromJsonAsync<GetFromPolygonIO>();
                    //nav.NavigateTo("/" + json.Code);
                    //LoginResult result = await msg.Content.ReadFromJsonAsync<LoginResult>();

                    //if (result.success) {
                    //await jsr.InvokeVoidAsync("localStorage.setItem", "user", $"{result.email};{result.jwtBearer}").ConfigureAwait(false);

                    //}
                //}
            //}
            return Ok();
        }
    }
}
