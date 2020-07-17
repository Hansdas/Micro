using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus
{
    public interface IEventBusManager
    {
        /// <summary>
        /// 取消订阅事件
        /// </summary>
        event EventHandler<ValueTuple<Type, Type>> OnRemoveEventHandler;
        /// <summary>
        /// 订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void AddSub<T, TH>()
            where T : EventData
            where TH : IEventHandler;
        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void RemoveEventSub<T, TH>()
            where T : EventData
            where TH : IEventHandler;
        /// <summary>
        /// 是否包含实体类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool HaveAddHandler(Type eventDataType);
        /// <summary>
        /// 根据实体名称寻找类型
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        Type FindEventType(string eventName);
        /// <summary>
        /// 根据实体类型寻找它的领域事件驱动
        /// </summary>
        /// <param name="eventDataType"></param>
        /// <returns></returns>
        object FindHandlerType(Type eventDataType);
    }
}
