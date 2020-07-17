using log4net;
using Micro.Core.EventBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Services.Domain
{
    public class UserEventHandler : IEventHandler<CreateUserEvent>, IEventHandler<UpdateUserEvent>
    {
        private readonly ILogger<UserEventHandler> _logger;
        public UserEventHandler(ILogger<UserEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handler(CreateUserEvent eventData)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(eventData));
             await Task.FromResult(0);
        }

        public async Task Handler(UpdateUserEvent eventData)
        {
            await Task.FromResult(0);
        }

    }
}
