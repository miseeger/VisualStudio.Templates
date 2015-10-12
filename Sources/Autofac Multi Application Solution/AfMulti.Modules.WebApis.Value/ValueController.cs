using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Integration.WebApi;
using $ext_safeprojectname$.Common.Data.Model;
using $ext_safeprojectname$.Domain.Value.Interfaces;

namespace $safeprojectname$
{

	[AutofacControllerConfiguration]
	[RoutePrefix("api/values")]
	public class ValuesController : ApiController
	{

		private IValueBusinessService _businessService;

		
		public ValuesController(IValueBusinessService businessService)
		{
			_businessService = businessService;
		}


		[Route("all")]
		[HttpGet]
		public HttpResponseMessage AllValues()
		{
			Console.WriteLine("Querying all values");
			var result = _businessService.GetStringValues();
			return result.Any()
				? Request.CreateResponse(HttpStatusCode.OK, result)
				: Request.CreateErrorResponse(HttpStatusCode.NotFound,
					String.Format("No values found."));
		}


		[Route("{id:int}")]
		[HttpGet]
		public HttpResponseMessage Get(int id)
		{
			Console.WriteLine(String.Format("Querying value for Id {0}", id));
			if (id == 99)
			{
				return Request.CreateResponse(HttpStatusCode.OK, _businessService.SpecialValue);
			}
			else
			{
				var result = _businessService.GetStringValue(id);
				return result == null
						? Request.CreateErrorResponse(HttpStatusCode.NotFound,
							String.Format("Value for Id {0} was not found.", id))
						: Request.CreateResponse(HttpStatusCode.OK, result);
			}
		}


		[Route("add")]
		[HttpPost]
		public HttpResponseMessage AddValue([FromBody]StringValue v)
		{
			var newId = _businessService.CreateStringValue(v);
			Console.WriteLine(String.Format("Creating new value {0}: {1}",
				newId, v.Value));
			v.Id = newId;

			return Request.CreateResponse(HttpStatusCode.Created, v);
		}


		[Route("{id:int}")]
		[HttpPut]
		public HttpResponseMessage UpdateValue(int id, [FromBody]StringValue v)
		{
			HttpResponseMessage msg = null;

			Console.WriteLine(String.Format("Updating value {0}: {1}", v.Id, v.Value));
			msg = _businessService.UpdateStringValue(v)
					? Request.CreateResponse(HttpStatusCode.OK, v)
					: Request.CreateErrorResponse(HttpStatusCode.NoContent,
						String.Format("Value for Id {0} was not found.", id));
			return msg;
		}


		[Route("{id:int}")]
		[HttpDelete]
		public HttpResponseMessage DeleteValue(int Id)
		{
			HttpResponseMessage msg = null;

			Console.WriteLine(String.Format("Deleting value for Id {0}", Id));

			msg = _businessService.DeleteStringValue(Id)
					? msg = Request.CreateResponse(HttpStatusCode.OK)
					: msg = Request.CreateErrorResponse(HttpStatusCode.NoContent,
						String.Format("Value for Id {0} was not found.", Id));
			return msg;
		}

	}

}