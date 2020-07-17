using Micro.Core.EventBus.RabbitMQ.IImplementation;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus.RabbitMQ
{
   public class FactoryRabbitMQ: IFactoryRabbitMQ
    {
        private readonly IConnectionFactory connectionFactory;
        public FactoryRabbitMQ(EventBusOption eventBusOption)
        {
            IConnectionFactory conFactory = new ConnectionFactory
            {
                HostName = eventBusOption.Host,
                Port = eventBusOption.Port,
                UserName = eventBusOption.Username,
                Password = eventBusOption.Password
            };
            connectionFactory = conFactory;
        }
        public  IConnection CreateConnection()
        {
            return connectionFactory.CreateConnection();
        }
    }
}
