using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Stellers.Hawkeye.Common.Constants;
using Stellers.Hawkeye.Web.Extensions;
using Stellers.Hawkeye.Web.Filters.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Principal;

namespace Stellers.Hawkeye.Web.Startup
{
	public abstract class MicroServiceStartup
	{
		/// <summary>
		/// 
		/// </summary>
		public static Guid Id;
		
		// This method gets called by the runtime. Use this method to add services to the container.
		public virtual void ConfigureServices(IServiceCollection services)
		{
			Id = Guid.NewGuid();

			//Adds Mapper Configurations
			services.AddMaps(ConfigureMaps);

			//Adds cusom types
			services.AddTypes(RegisterTypes);

			//Adds response compression
			services.AddResponseCompression();
			
			//Adds Services requrired for controllers only
			services.AddControllers(options => options.EnableEndpointRouting = false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual void ConfigureJwtBearerOptions(JwtBearerOptions jwtBearerOptions)
		{
			jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,

				SaveSigninToken = true
			};
		}

		/// <summary>
		/// Registers all the custom types used by API
		/// </summary>
		/// <param name="services">services collection</param>
		protected virtual void RegisterTypes(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
			//services.AddTransient<IIdentityProvider, IdentityProvider>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="corsOptions"></param>
		protected virtual void ConfigureCors(CorsOptions corsOptions)
		{
			var corsPolicyBuilder = new CorsPolicyBuilder(new CorsPolicy())
										.AllowAnyHeader()
										.AllowAnyMethod()
										.AllowAnyOrigin()
										.AllowCredentials()
										.WithExposedHeaders(HttpResponseHeader.Location.ToString(),
															Constants.SharedHttpHeaders.PagingTotal,
															Constants.SharedHttpHeaders.PagingFirst,
															Constants.SharedHttpHeaders.PagingLast);
			corsOptions.AddDefaultPolicy(corsPolicyBuilder.Build());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="swaggerGenOptions"></param>
		protected virtual void ConfigureSwagger(SwaggerGenOptions swaggerGenOptions)
		{
			swaggerGenOptions.SwaggerDoc(Constants.Swagger.Description, new Info
			{
				Version = Constants.Swagger.ApiVersions.V1.Version,
				Title = Constants.Swagger.ApiVersions.V1.Title,
				Description = Constants.Swagger.Description,
				TermsOfService = Constants.Swagger.TermsOfService,
				Contact = new Contact() { Name = Constants.Swagger.Contact.Name, Email = Constants.Swagger.Contact.Email, Url = Constants.Swagger.Contact.Url }
			});
			swaggerGenOptions.CustomSchemaIds(x => x.FullName);
			swaggerGenOptions.IncludeXmlComments(GetXmlCommentsPath());
			swaggerGenOptions.DescribeAllEnumsAsStrings();
			swaggerGenOptions.OperationFilter<MultipleOperationsWithSameVerbFilter>();
		}

		/// <summary>
		/// Gets API version route string.
		/// </summary>
		/// <returns>
		/// The API version string, e.g. 'v1'.
		/// </returns>
		protected virtual string GetApiVersion()
		{
			return Constants.ApiVersions.V1;
		}

		/// <summary>
		/// Gets the Xml Comments Path.
		/// </summary>
		/// <returns>
		/// The XML comments path.
		/// </returns>
		protected virtual string GetXmlCommentsPath()
		{
			var commentsFileName = GetMicroServiceAssembly().GetName().Name + Constants.FileExtensions.Xml;
			return Path.Combine(AppContext.BaseDirectory, commentsFileName);
		}

		/// <summary>
		/// Registers all of the AutoMapper DTO maps.
		/// </summary>
		protected abstract IMapper ConfigureMaps();

		/// <summary>
		/// Returns the microservice specific assembly so that XML documentation paths and
		/// Api names can be derived.
		/// </summary>
		/// <returns></returns>
		protected abstract Assembly GetMicroServiceAssembly();
	}
}