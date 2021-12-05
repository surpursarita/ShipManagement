using Autofac;
using HPC.Task.ShipManagement.DAL.Implementation;
using HPC.Task.ShipManagement.DAL.Interface;
using HPC.Task.ShipManagement.Service.Implementation;
using HPC.Task.ShipManagement.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HPC.Task.ShipManagement.API.Configuration
{
    public class ServiceRegistrationModule : Module
    {
        private readonly IConfiguration config;

        public ServiceRegistrationModule(IConfiguration config)
        {
            this.config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterLogger(builder);
            builder.RegisterType<ShipValidateService>().As<IShipValidateService>().InstancePerLifetimeScope();
            builder.RegisterType<ShipService>().As<IShipService>().InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>().As<IShipRepository>().InstancePerLifetimeScope();
        }

        private void RegisterLogger(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var logger = c.Resolve<ILogger>();
                return logger;
            }).As<ILogger>().InstancePerLifetimeScope();
        }
    }
}
