using Micro.Core.Configure;                               
using Micro.Core.EventBus.RabbitMQ;
using Micro.Core.EventBus.RabbitMQ.IImplementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Micro.Core.EventBus
{
   public static class EventBusBuilder
    {
        public static EventBusOption eventBusOption;
        public static IServiceCollection AddEventBus(this IServiceCollection serviceDescriptors)
        {
            eventBusOption= ConfigurationProvider.GetModel<EventBusOption>("EventBusOption");
            switch (eventBusOption.MQProvider)
            {
                case MQProvider.RabbitMQ:
                    serviceDescriptors.AddTransient<IEventBus, EventBusRabbitMQ>();
                    serviceDescriptors.AddTransient(typeof(IFactoryRabbitMQ), factiory => {
                        return new FactoryRabbitMQ(eventBusOption);
                    });
                    break;
            }
            EventBusManager eventBusManager = new EventBusManager(serviceDescriptors,s=>s.BuildServiceProvider());
            serviceDescriptors.AddSingleton<IEventBusManager>(eventBusManager);
            return serviceDescriptors;
        }
        public static IServiceCollection AddEventBusSub<TEventData, TEventHandler>(this IServiceCollection serviceDescriptors)
        {
            string assembly= ConfigurationProvider.configuration.GetSection("EventHandler").Value;
            Type[] types = Assembly.Load(assembly).GetTypes();
            Type handler = typeof(TEventHandler);
            Type Implementation=types.FirstOrDefault(s => handler.IsAssignableFrom(s));
            if (Implementation == null)
                throw new ArgumentException(string.Format("未找到“{0}”的实现类",handler.FullName));
            serviceDescriptors.AddTransient(handler,Implementation);
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
