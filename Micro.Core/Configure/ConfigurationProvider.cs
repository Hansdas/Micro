using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

namespace Micro.Core.Configure
{
    public class ConfigurationProvider
    {
        public static IConfiguration configuration;
        static ConfigurationProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("Configs/appsettings.json", false, true)
                .AddJsonFile("Configs/eventBus.json");
            configuration = builder.Build();
        }
        public static T GetModel<T>(string key) where T : class,new()
        {
           T model= new ServiceCollection().AddOptions().
               Configure<T>(configuration.GetSection(key)).
               BuildServiceProvider().GetService<IOptions<T>>()
               .Value;
            return model;
        }
    }
}
