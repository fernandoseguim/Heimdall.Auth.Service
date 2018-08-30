using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Heimdall.Auth.Service.Models;
using IdentityServer4.Services;

namespace Heimdall.Auth.Service.Controllers
{
    public class HomeController : Controller
    {
		private readonly IIdentityServerInteractionService interaction;

		public HomeController(IIdentityServerInteractionService interaction)
		{
			this.interaction = interaction;
		}

		public IActionResult Index()
        {
            return View();
        }
		
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
