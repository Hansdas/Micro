
using log4net;
using Micro.Core.EventBus.RabbitMQ.IImplementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Micro.Core.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus
    {
        /// <summary>
        /// 队列名称
        /// </summary>
        private string queueName = "QUEUE";
        /// <summary>
        /// 交换机名称
        /// </summary>
        private string exchangeName = "directName";
        /// <summary>
        /// 交换类型
        /// </summary>
        private string exchangeType = "direct";
        private IFactoryRabbitMQ _factory;
        private IEventBusManager _eventBusManager;
        private ILogger<EventBusRabbitMQ> _log;
        private readonly IConnection connection;
        private readonly IModel channel;
        public EventBusRabbitMQ(IFactoryRabbitMQ factory, IEventBusManager eventBusManager, ILogger<EventBusRabbitMQ> log)
        {
            _factory = factory;
            _eventBusManager = eventBusManager;
            _eventBusManager.OnRemoveEventHandler += OnRemoveEvent;
            _log = log;
            connection = _factory.CreateConnection();
            channel = connection.CreateModel();
        }
        private void OnRemoveEvent(object sender, ValueTuple<Type, Type> args)
        {
            channel.QueueUnbind(queueName, exchangeName, args.Item1.Name);
        }
        public void Publish(EventData eventData)
        {
            string routeKey = eventData.GetType().Name;
            channel.QueueDeclare(queueName, true, false, false, null);
            string message = JsonConvert.SerializeObject(eventData);
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchangeName, routeKey, null, body);
        }

        public void Subscribe<T, TH>()
            where T : EventData
            where TH : IEventHandler
        {
            _eventBusManager.AddSub<T, TH>();
            channel.QueueBind(queueName, exchangeName, typeof(T).Name);
            channel.QueueDeclare(queueName, true, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received +=async (model, ea) =>
            {
                string eventName = ea.RoutingKey;
                byte[] resp = ea.Body.ToArray();
                string body = Encoding.UTF8.GetString(resp);
                _log.LogInformation(body);
                try
                {
                    Type eventType = _eventBusManager.FindEventType(eventName);
                    T eventData = (T)JsonConvert.DeserializeObject(body, eventType);
                    IEventHandler<T> eventHandler = _eventBusManager.FindHandlerType(eventType) as IEventHandler<T>;
                    await eventHandler.Handler(eventData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            };
            channel.BasicConsume(queueName, true, consumer);
        }

        public void Unsubscribe<T, TH>()
           where T : EventData
           where TH : IEventHandler
        {
            if (_eventBusManager.HaveAddHandler(typeof(T)))
            {
                _eventBusManager.RemoveEventSub<T, TH>();
            }
        }
    }
}
