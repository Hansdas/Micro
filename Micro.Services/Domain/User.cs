using Micro.Core.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Micro.Services.Domain
{
    public class CreateUserEvent : EventData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }

    }
    public class UpdateUserEvent : EventData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
