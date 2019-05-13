using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NLog.Targets.Wrappers;
using $ext_safeprojectname$.Core.Data.HubModels;
using $ext_safeprojectname$.Web.Hubs;

namespace $safeprojectname$.Controllers
{
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly IHubContext<CoffeeHub> _coffeeHub;

        
        public CoffeeController(IHubContext<CoffeeHub> coffeeHub)
        {
            _coffeeHub = coffeeHub;
        }


        [HttpPost]
        public async Task<IActionResult> OrderCoffee([FromBody] Order order)
        {
            await _coffeeHub.Clients.All.SendAsync("NewOrder", $"{order.Product} ({order.Size})");
            return Accepted(1); // returns the order id 
        }
    }
}