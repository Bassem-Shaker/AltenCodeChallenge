using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Simulation.SendingVehiclesStatus.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {

        public ScheduleTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "* * * * *";

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Processing starts here");
            new SendingRandomStatus().VehiclesPing();
            return Task.CompletedTask;
        }
    }

}
