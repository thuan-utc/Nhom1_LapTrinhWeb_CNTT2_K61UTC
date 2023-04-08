using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models.Authentication
{
	public class Authentication : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("UserName") == null)
			{
				context.Result = new RedirectToRouteResult(
					new RouteValueDictionary
					{
						{"Controller", "Access" },
						{"Action", "Login" }
					});
			}
		}
	}
}
