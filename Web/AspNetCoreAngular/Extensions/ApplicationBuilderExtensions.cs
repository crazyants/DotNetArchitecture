using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Solution.Web.AspNetCoreAngular.Middlewares;

namespace Solution.Web.AspNetCoreAngular.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseCorsCustom(this IApplicationBuilder application)
		{
			application.UseCors(Constants.Cors);
		}

		public static void UseExceptionCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				application.UseDeveloperExceptionPage();
				application.UseDatabaseErrorPage();
			}

			application.UseExceptionMiddleware();
		}

		public static void UseExceptionMiddleware(this IApplicationBuilder application)
		{
			application.UseMiddleware<ExceptionMiddleware>();
		}

		public static void UseMvcCustom(this IApplicationBuilder application)
		{
			application.UseMvc(routes =>
			{
				routes.MapRoute("default", "{controller}/{action}/{id?}");
			});
		}

		public static void UseSpaCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			application.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (environment.IsDevelopment())
				{
					spa.UseAngularCliServer("development");
					//spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
				}
			});
		}
	}
}
