using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Web.AspNetCoreAngular.Attributes;

namespace Solution.Web.AspNetCoreAngular.Controllers
{
	[Route(Constants.Controller)]
	public class AuthenticationServiceController : BaseController
	{
		public AuthenticationServiceController(IUserApplication userApplication)
		{
			UserApplication = userApplication;
		}

		public IUserApplication UserApplication { get; }

		[AllowAnonymous]
		[HttpPost(Constants.Action)]
		public IActionResult Authenticate([FromBody]AuthenticationModel authentication)
		{
			var authenticated = UserApplication.Authenticate(authentication);
			var token = UserApplication.GenerateJwtToken(authenticated);
			return Json(token);
		}

		[AuthorizeEnum(Role.Admin)]
		[HttpGet(Constants.Action)]
		[ResponseCache(Duration = 5)]
		public IActionResult GetAuthenticatedUserId()
		{
			return Json(AuthenticatedUserId);
		}
	}
}
