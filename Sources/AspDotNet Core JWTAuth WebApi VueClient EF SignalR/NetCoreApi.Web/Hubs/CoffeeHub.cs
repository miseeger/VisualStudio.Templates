using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using $ext_safeprojectname$.Core.Data.HubModels;
using $ext_safeprojectname$.Core.Services.Hub;

namespace $safeprojectname$.Hubs
{
    //[Authorize]
    public class CoffeeHub: Hub
    {
        private OrderService _orderService;

        public CoffeeHub(OrderService orderService)
        {
            _orderService = orderService;
        }


        public async Task GetUpdateForOrder(int orderId)
        {
            //In an authorize-scenario:
            //var currentUser = Context.User.Identity;

            OrderCheckResult result;

            do
            {
                result = _orderService.GetUpdate(orderId);
                Thread.Sleep(1000);

                if (result.New)
                {
                    await Clients.Caller.SendAsync("ReceiveOrderUpdate", result.Update);
                }

            } while (!result.Finished);

            await Clients.Caller.SendAsync("Finished");
        }

        
        // Event OnConnectedAsync: Whenever a Client connects to the Hub
        // -------------------------------------------------------------
        
        //public override async Task OnConnectedAsync()
        //{
        //    var connectionId = Context.ConnectionId;
        //    // sends to the connecting client
        //    await Clients.Client(connectionId).SendAsync("NewOrder", "New Order was submitted.");
        //    // sends to all clients but the connecting client
        //    await Clients.AllExcept(connectionId).SendAsync("NewOrder", "New Order was submitted.");
        //    // adds to a group
        //    await Groups.AddToGroupAsync(connectionId, "GroupToInform");
        //    // removes from a group
        //    await Groups.RemoveFromGroupAsync(connectionId, "GroupToInform");
        //}

    }

}