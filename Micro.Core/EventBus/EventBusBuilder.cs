using Micro.Core.Configure;
using Micro.Core.EventBus.RabbitMQ;
using Micro.Core.EventBus.RabbitMQ.IImplementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus
{
   public static class EventBusBuilder
    {
        public static EventBusOption eventBusOption;
        public static IServiceCollection AddEventBus(this ServiceCollection serviceDescriptors)
        {
            eventBusOption= ConfigurationProvider.GetModel<EventBusOption>("EventBusOption");
            switch (eventBusOption.MQProvider)
            {
                case MQProvider.RabbitMQ:
                    serviceDescriptors.AddTransient<IEventBus, EventBusRabbitMQ>();
                    serviceDescriptors.AddTransient(typeof(IFactoryRabbitMQ),factiory=> {
                        return new FactoryRabbitMQ(eventBusOption);
                    });
                    break;
            }
            return serviceDescriptors;
        }
        public static IApplicationBuilder UseEventBus(this IApplicationBuilder builder)
        {
            switch (eventBusOption.MQProvider)
            {
                case MQProvider.RabbitMQ:
                    break;
            }
            return builder;
        }
    }
}
