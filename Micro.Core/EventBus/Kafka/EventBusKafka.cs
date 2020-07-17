
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus.Kafka
{
    public class EventBusKafka : IEventBus
    {
        public void Publish()
        {
            throw new NotImplementedException();
        }

        public void Publish(EventData eventData)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(Func<T, T> action) where T : EventData
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : EventData
            where TH : IEventHandler
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : EventData
            where TH : IEventHandler
        {
            throw new NotImplementedException();
        }
    }
}
