using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Common.Constants
{
	/// <summary>
	/// 
	/// </summary>
	public partial struct Constants
	{
		/// <summary>
		/// 
		/// </summary>
		public struct ErrorCodes
		{
			/// <summary>
			/// 
			/// </summary>
			public const string InValidModel = "HEC400";

			/// <summary>
			/// 
			/// </summary>
			public const string UnAuthorized = "HEC401";

			/// <summary>
			/// 
			/// </summary>
			public const string Forbidden = "HEC403";

			/// <summary>
			/// 
			/// </summary>
			public const string NotFound = "HEC404";

			/// <summary>
			/// 
			/// </summary>
			public const string DuplicateResource = "HEC409";

			/// <summary>
			/// 
			/// </summary>
			public const string ExpectedResourceGone = "HEC410";

			/// <summary>
			/// 
			/// </summary>
			public const string PreconditionFailed = "HEC412";

			/// <summary>
			/// 
			/// </summary>
			public const string OperationNotSupported = "HEC420";

			/// <summary>
			/// 
			/// </summary>
			public const string DuplicateName = "HEC428";

			/// <summary>
			/// 
			/// </summary>
			public const string General = "HEC500";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct ErrorCodesDescriptions
		{
			/// <summary>
			/// 
			/// </summary>
			public const string InvalidModel = "The resource provided is invalid, please verify the specified Data Element";

			/// <summary>
			/// 
			/// </summary>
			public const string UnAuthorized = "You are unauthorized to access this resource";

			/// <summary>
			/// 
			/// </summary>
			public const string DuplicateResource = "The resource or value specified already exists, please verify the specified Data Element for uniqueness";

			/// <summary>
			/// 
			/// </summary>
			public const string ExpectedResourceGone = "Expected data is missing or corrupt";

			/// <summary>
			/// 
			/// </summary>
			public const string PreconditionFailed = "Expected a Precondition that was not met";

			/// <summary>
			/// 
			/// </summary>
			public const string OperationNotSupported = "The operation trying to perform is not supported on the entity.";

			/// <summary>
			/// 
			/// </summary>
			public const string DuplicateName = "Element already exists.";

			/// <summary>
			/// 
			/// </summary>
			public const string General = "An unknown error has occurred";

			/// <summary>
			/// 
			/// </summary>
			public const string NotFound = "Cannot Find the requested resource";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct ExceptionMessages
		{
			/// <summary>
			/// 
			/// </summary>
			public const string NullContextWhileResolving = "An active HttpContext does not exist - this Dependency Resolver cannot continue without one.  Please ensure that the current thread was created with the original context.";

			/// <summary>
			/// 
			/// </summary>
			public const string UnableToResolveConfigurationManager = "IConfigurationManager must be registered with our DI provider before configuring the pipeline.";

			/// <summary>
			/// 
			/// </summary>
			public const string UnableToResolveAuthorizationManager = "IAuthorizationManager must be registered with our DI provider before AuthorizationMiddleware can be used.";

			/// <summary>
			/// 
			/// </summary>
			public const string UnableToResolve = "{0} must be registered with our DI provider.";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct SharedHttpHeaders
		{
			/// <summary>
			/// The Parent identifier HTTP header used to pass correlation id of the parent request between services
			/// </summary>
			public const string ParentId = "X-ParentId";

			/// <summary>
			/// The request identifier HTTP header used to pass unique request id of the request
			/// </summary>
			public const string RootRequestId = "X-RootRequestId";

			/// <summary>
			/// The total record count
			/// </summary>
			public const string PagingTotal = "X-Paging-Total";

			/// <summary>
			/// The first record
			/// </summary>
			public const string PagingFirst = "X-Paging-First";

			/// <summary>
			/// The last record
			/// </summary>
			public const string PagingLast = "X-Paging-Last";

			/// <summary>
			/// The header used to pass the user ID on from microservice to microservice.
			/// </summary>
			public const string OnBehalfOfUserId = "X-OBO-UserId";

			/// <summary>
			/// The header used to pass the Authorization token.
			/// </summary>
			public const string Authorization = "Authorization";

			/// <summary>
			/// The header used by Load balancer to populate Client Ip
			/// </summary>
			public const string LoadBalancerForwardedFor = "HTTP_X_FORWARDED_FOR";

			/// <summary>
			/// The header used by Load balancer to populate Client Ip
			/// </summary>
			public const string GatewayForwardedFor = "HTTP_GATEWAY_X_FORWARDED_FOR";

			/// <summary>
			/// The header which contains Client IP
			/// </summary>
			public const string RemoteAddress = "REMOTE_ADDR";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct Protocols
		{
			/// <summary>
			/// 
			/// </summary>
			public const string Https = "https";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct HttpVerbs
		{
			/// <summary>
			/// 
			/// </summary>
			public const string Connect = "connect";

			/// <summary>
			/// 
			/// </summary>
			public const string Delete = "delete";

			/// <summary>
			/// 
			/// </summary>
			public const string Head = "head";

			/// <summary>
			/// 
			/// </summary>
			public const string Get = "get";

			/// <summary>
			/// 
			/// </summary>
			public const string Merge = "merge";

			/// <summary>
			/// 
			/// </summary>
			public const string Options = "options";

			/// <summary>
			/// 
			/// </summary>
			public const string Patch = "patch";

			/// <summary>
			/// 
			/// </summary>
			public const string Post = "post";

			/// <summary>
			/// 
			/// </summary>
			public const string Put = "put";

			/// <summary>
			/// 
			/// </summary>
			public const string Trace = "trace";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct ApiVersions
		{
			/// <summary>
			/// 
			/// </summary>
			public const string V1 = "v1";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct Swagger
		{
			public const string Description = "Hawkeye Backbone APIs";

			public const string TermsOfService = "None";

			public const string Endpoint = "/swagger/v1/swagger.json";

			public struct ApiVersions
			{
				public struct V1
				{
					public const string Version = "V1";

					public const string Title = "Hawkeye Version 1 APIs";
				}
			}

			public struct Contact
			{
				public const string Name = "Hawkeye";

				public const string Email = "contact@hawkeye.com";

				public const string Url = "www.Hawkeye.com";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public struct Route
		{
			public struct Crud
			{
				private const string BasePath = "{id}";

				public const string Get = BasePath;

				public const string GetAll = "GetAll";

				public const string Create = "";

				public const string Update = BasePath;

				public const string Patch = BasePath;

				public const string Delete = BasePath;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public struct Microservices
		{
			/// <summary>
			/// 
			/// </summary>
			public const string User = "USER";

			/// <summary>
			/// 
			/// </summary>
			public const string Management = "MANAGEMENT";

			/// <summary>
			/// 
			/// </summary>
			public const string Authorization = "AUTHORIZATION";

			/// <summary>
			/// 
			/// </summary>
			public const string Gateway = "GATEWAY";

			/// <summary>
			/// 
			/// </summary>
			public const string GroupProfile = "LGPROFILE";
		}

		public struct Patterns
		{
			/// <summary>
			/// 
			/// </summary>
			public const string RetreiveAlphabets = @"\W";

			/// <summary>
			/// 
			/// </summary>
			public const string RetreiveRouteConstraints = @":[guid|long|int]*";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct CommonLinkRelValues
		{
			/// <summary>
			/// The self.
			/// </summary>
			public const string Self = "self";
		}
	}
}