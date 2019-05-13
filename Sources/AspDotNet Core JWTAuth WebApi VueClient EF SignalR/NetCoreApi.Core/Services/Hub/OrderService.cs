using System;
using $$ext_safeprojectname$.Core.Data.HubModels;

namespace $safeprojectname$.Services.Hub
{
    public class OrderService
    {
        private readonly Random random;
        private int index;

        private readonly string[] Status =
            {"Grinding beans", "Steaming milk", "Taking a sip (quality control)", "On transit to counter", "Picked up"};

        public OrderService(Random random)
        {
            this.random = random;
        }

        public OrderCheckResult GetUpdate(int orderNo)
        {
            if (random.Next(1, 5) == 4)
            {
                if (Status.Length - 1 > index)
                {
                    index++;
                    var result = new OrderCheckResult
                    {
                        New = true,
                        Update = Status[index],
                        Finished = Status.Length - 1 == index
                    };
                    if (result.Finished)
                        index = 0;
                    return result;
                }
            }

            return new OrderCheckResult { New = false };
        }
    }

}