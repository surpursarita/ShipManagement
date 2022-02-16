using Autofac;
using Task.ShipManagement.DAL.Implementation;
using Task.ShipManagement.DAL.Interface;
using Task.ShipManagement.Service.Implementation;
using Task.ShipManagement.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Task.ShipManagement.API.Configuration
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
