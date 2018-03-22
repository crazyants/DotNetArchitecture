using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.Context;

namespace Solution.Web.AspNetCoreAngular.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddAuthenticationCustom(this IServiceCollection services)
		{
			void JwtBearerOptions(JwtBearerOptions options)
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new JsonWebToken().GetTokenValidationParameters();
			}

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerOptions);
		}

		public static void AddCorsCustom(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(Constants.Cors,
					builder =>
					{
						builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials();
					});
			});
		}

		public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
		{
			Container.RegisterServices(services);
			Container.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
		}

		public static void AddMvcCustom(this IServiceCollection services)
		{
			void MvcOptions(MvcOptions options)
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				options.Filters.Add(new AuthorizeFilter(policy));
			}

			void MvcJsonOptions(MvcJsonOptions options)
			{
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			}

			services.AddMvc(MvcOptions).AddJsonOptions(MvcJsonOptions);
		}

		public static void AddSpaStaticFilesCustom(this IServiceCollection services)
		{
			services.AddSpaStaticFiles(cfg => { cfg.RootPath = "ClientApp/dist"; });
		}
	}
}
