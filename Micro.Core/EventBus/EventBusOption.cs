using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.EventBus
{
   public class EventBusOption
    {
        /// <summary>
        /// EventBus中间件类型
        /// </summary>
        public MQProvider MQProvider { get; set; }
        /// <summary>
        /// 主机ip
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

    }
}
