using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Routing;
using $safeprojectname$.Filters;
using Newtonsoft.Json.Serialization;
using Owin;

namespace $safeprojectname$
{

	/// <summary>
	/// Provides the API's configuration. Returned data will generally be formatted
	/// in JSON format. Fieldnames will be camelcased.
	/// </summary>
	public static class WebApiConfig
	{

		public static void Register(ref IAppBuilder app, ref HttpConfiguration config)
		{

			config.Filters.Add(new NoCacheHeaderFilter());

			config.MapHttpAttributeRoutes();


			config.Formatters.Remove(config.Formatters.XmlFormatter);
			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			app.UseWebApi(config);
		
		}

	}

}