using Micro.Core.EventBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus
{
    public interface IEventBus
    {
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="eventData"></param>
        void Publish(EventData eventData);
        /// <summary>
        /// 订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Subscribe<T, TH>()
            where T : EventData
            where TH : IEventHandler;
        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Unsubscribe<T, TH>()
             where T : EventData
             where TH : IEventHandler;
    }
}
