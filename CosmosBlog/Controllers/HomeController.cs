using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CosmosBlog.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CosmosBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly string _token = "token";

		public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			_httpContextAccessor = httpContextAccessor;
		}

		public IActionResult Index()
		{
			var token = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_token);

			if (!token) return RedirectToAction("Login", "Home");


			return View();
		}

		public IActionResult About()
		{
			var token = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_token);

			if (!token) return RedirectToAction("Login", "Home");

			return View();
		}

		public IActionResult Contact()
		{
			var token = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_token);

			if (!token) return RedirectToAction("Login", "Home");

			return View();
		}

		public IActionResult Post()
		{
			var token = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_token);

			if (!token) return RedirectToAction("Login", "Home");

			return View();
		}

		public IActionResult Login()
		{
			if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_token)) return RedirectToAction("Index", "Home");
			return View();
		}

		public IActionResult LoginSubmit()
		{
			HttpContext.Response.Cookies.Append(_token, CheckTheValidityOfCredentialsAndGenerateToken());

			return RedirectToAction("Index", "Home");

		}

		/// <summary>
		/// Check the credentials and gerenates the token
		/// </summary>
		/// <returns>Returns a token string</returns>
		public string CheckTheValidityOfCredentialsAndGenerateToken()
		{

			/* 
			 * The ckecking credentials part is skipped for the sake of simplicity 
			 ...
			 */

			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes("mySecretKeyIsTest123!");

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, "Jon San"),
					new Claim(ClaimTypes.Role, "Admin"),
					new Claim(ClaimTypes.DateOfBirth, "14/06/1990"),
					new Claim(ClaimTypes.Email, "jon.san@gmail.com"),
					new Claim(ClaimTypes.Gender, "Male")
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
