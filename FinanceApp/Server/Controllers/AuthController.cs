using FinanceApp.Server.Models;
using FinanceApp.Server.Services;
using FinanceApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceApp.Server.Controllers
{
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IAuthService _service;

		public AuthController(IConfiguration configuration, IAuthService service)
        {
            _configuration = configuration;
			_service = service;
		}

        private string CreateJWT(User user)
		{
			var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["KeyBase:ServiceApiKey"])); // NOTE: SAME KEY AS USED IN Program.cs FILE
			var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

			var claims = new[] // NOTE: could also use List<Claim> here
			{
				new Claim(ClaimTypes.Name, user.Email), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, user.Email) // NOTE: this could a unique ID assigned to the user by a database
			};

			var token = new JwtSecurityToken(issuer: "localhost:7104", audience: "localhost:7104", claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		[HttpPost]
		[Route("api/auth/register")]
		public async Task<LoginResult> Post([FromBody] RegModel reg)
		{
			if (reg.password != reg.confirmpwd)
				return new LoginResult { message = "Password and confirm password do not match.", success = false };
			User newuser = await _service.AddUser(reg.email, reg.password);
			if (newuser != null)
			{
				await _service.SaveChangesToCredDb();
				return new LoginResult { message = "Registration successful.", jwtBearer = CreateJWT(newuser), success = true };
			}
			return new LoginResult { message = "User already exists.", success = false };
		}

		[HttpPost]
		[Route("api/auth/login")]
		public async Task<LoginResult> Post([FromBody] LoginModel log)
		{
			User user = await _service.AuthenticateUser(log.email, log.password);
			if (user != null)
				return new LoginResult { message = "Login successful.", jwtBearer = CreateJWT(new User(log.email)), success = true };
			return new LoginResult { message = "User/password not found.", success = false };
		}

		[HttpPost]
		[Route("api/auth/chceck")]
        [Authorize]
		public IActionResult ChceckAuthorized()
        {
			return Ok();
        }
	}
}
