
using Micro.Core.EventBus.RabbitMQ.IImplementation;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus
    {
        private IFactoryRabbitMQ _factory;
        public EventBusRabbitMQ(IFactoryRabbitMQ factory)
        {
            _factory = factory;
        }
        public void Publish()
        {
            using (IConnection connection= _factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {

                }
            }
        }
    }
}
