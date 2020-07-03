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
            EventBusOption option = new EventBusOption();
            IConnectionFactory conFactory = new ConnectionFactory
            {
                HostName = option.Host,
                Port = option.Port,
                UserName = option.Username,
                Password = option.Password
            };
            connectionFactory = conFactory;
        }
        public  IConnection CreateConnection()
        {
            return connectionFactory.CreateConnection();
        }
    }
}
