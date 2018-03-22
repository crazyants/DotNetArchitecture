using Microsoft.AspNetCore.Mvc;

namespace Solution.Web.AspNetCoreAngular.Controllers
{
	public abstract class BaseController : Controller
	{
		protected long AuthenticatedUserId
		{
			get { long.TryParse(User.GetClaimValueOfNameIdentifier(), out var userId); return userId; }
		}
	}
}