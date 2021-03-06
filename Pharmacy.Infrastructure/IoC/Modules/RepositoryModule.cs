﻿using System.Reflection;
using Autofac;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.Repositories;

namespace Pharmacy.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().InstancePerLifetimeScope();
        }
    }
}