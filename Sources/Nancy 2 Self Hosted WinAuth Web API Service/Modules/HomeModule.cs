using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Owin;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Models;

namespace $safeprojectname$.Modules
{
    public class HomeModule : NancyModule
    {

        private INPocoDbService _dbService;


        public HomeModule(IConfiguration config, INPocoDbService dbService)
        {
            _dbService = dbService;
            
            Get("/", args => "Hello from Nancy 2 - running on Self Hosted WinAuth API Service");

            Get("/test/{param}", async (args) => {
                var owinContext = Context.GetOwinEnvironment();

                return await Response
                    .AsJson(new {
                        Param = args.param, 
                        Path = (string)owinContext["owin.RequestPath"],
                        User = Context.CurrentUser.Identity.Name,
                        OwinUser = ((WindowsPrincipal)owinContext["server.User"]).Identity.Name})
                    .WithHeader("myHeader","Response Header");
            });

            Get("/config", async (args) => await Response.AsText(config["Greeting"]));

            Get("/costumes", async (args) => await Response.AsJson<List<Costume>>(GetCostumes()));
        }


        private List<Costume> GetCostumes()
        {
            List<Costume> result;

            using (var db = _dbService.CreateDb())
            {
                db.Connection.Open();
                try
                {
                    result = db.Fetch<Costume>("SELECT * FROM dbo.Costume");
                }
                catch
                {
                    result = new List<Costume>();    
                }
                finally
                {
                    db.Connection.Close();
                }
            }

            return result;
        }
    }
}
