using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "ClientContext",
				url: "{id}",
				defaults: new { controller = "Accounts", action = "Index" },
				constraints: new { id = @"\d+" }
			);

			routes.MapRoute(
				name: "Controller",
				url: "{controller}/{id}",
				defaults: new { controller = "Accounts", action = "Index" },
				constraints: new { id = @"\d+" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Accounts", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
