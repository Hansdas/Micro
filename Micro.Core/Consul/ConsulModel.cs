using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Core.Consul
{
   public class ConsulModel
    {
        /// <summary>
        /// http或https
        /// </summary>
        public string Schem { get; set; }
        /// <summary>
        /// 主机ip
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 多少秒自动检测一次
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 服务出错后多少秒移除
        /// </summary>
        public int RemoveAfterError { get; set; }
        /// <summary>
        /// 服务名字
        /// </summary>
        public string Name { get; set; }
    }
}
