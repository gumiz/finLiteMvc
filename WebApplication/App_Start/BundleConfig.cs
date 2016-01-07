using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/template").Include(
					  "~/Content/template/main.css",
					"~/Content/template/bootswatch.min.css"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/ngDialog/ngDialog.css",
					  "~/Content/ngDialog/ngDialog-theme-default.css",
					  "~/Content/angular-growl-v2/angular-growl.css",
					  "~/Content/site.css"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
					  "~/Scripts/angular/angular.min.js",
					  "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/app.js"
					  ));

			bundles.Add(new ScriptBundle("~/bundles/libs").IncludeDirectory(
					"~/Scripts/libs", "*.js", true)
				.IncludeDirectory(
					"~/Content", "*.js", true
				));

			bundles.Add(new ScriptBundle("~/bundles/finLite").Include(
					  "~/Scripts/services/*.js",
					  "~/Scripts/controllers/*.js"
					  ));
		}
	}
}
