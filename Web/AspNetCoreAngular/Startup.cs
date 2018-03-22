using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Web.AspNetCoreAngular.Extensions;

namespace Solution.Web.AspNetCoreAngular
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
		{
			application.UseExceptionCustom(environment);
			application.UseAuthentication();
			application.UseStaticFiles();
			application.UseSpaStaticFiles();
			application.UseResponseCaching();
			application.UseCorsCustom();
			application.UseMvcCustom();
			application.UseSpaCustom(environment);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDependencyInjectionCustom(Configuration);
			services.AddAuthenticationCustom();
			services.AddResponseCaching();
			services.AddMemoryCache();
			services.AddCorsCustom();
			services.AddMvcCustom();
			services.AddSpaStaticFilesCustom();
		}
	}
}
