using Autofac;
using Microsoft.Extensions.Configuration;
using Pharmacy.Infrastructure.Extensions;
using Pharmacy.Infrastructure.Settings;

namespace Pharmacy.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}