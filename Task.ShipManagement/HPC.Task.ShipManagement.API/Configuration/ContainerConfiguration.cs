using Autofac;
using Microsoft.Extensions.Configuration;

namespace HPC.Task.ShipManagement.API.Configuration
{    internal class ContainerConfiguration
    {
        public static void Register(IConfiguration config, ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceRegistrationModule(config));
        }
    }
}
