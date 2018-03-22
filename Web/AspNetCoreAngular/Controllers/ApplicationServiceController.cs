using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Model.Models;

namespace Solution.Web.AspNetCoreAngular.Controllers
{
	[Route(Constants.Controller)]
	public class ApplicationServiceController : BaseController
	{
		[AllowAnonymous]
		[HttpGet]
		[ResponseCache(Duration = 1440)]
		public IActionResult Get()
		{
			return Json(new ApplicationModel());
		}
	}
}
