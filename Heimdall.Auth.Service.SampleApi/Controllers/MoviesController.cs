using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Auth.Service.SampleApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    public class MoviesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
			return Ok(new[]
			{
				new { Id = 1, Title = "Black Panther", ReleaseYear = 2018 },
				new { Id = 2, Title = "Galaxy Guardians Vol.2", ReleaseYear = 2017 },
				new { Id = 3, Title = "Logan", ReleaseYear = 2017 }
			});
		}
    }
}
