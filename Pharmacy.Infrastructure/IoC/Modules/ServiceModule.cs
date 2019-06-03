using System.Reflection;
using Autofac;
using Pharmacy.Infrastructure.Services;
using Pharmacy.Infrastructure.Services.Implementations;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();

            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .SingleInstance();


            builder.RegisterType<Numerator>()
                .As<INumerator>()
                .SingleInstance();
        }
    }
}