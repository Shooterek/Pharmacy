using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pharmacy.Framework;
using Pharmacy.Infrastructure.EF;
using Pharmacy.Infrastructure.Extensions;
using Pharmacy.Infrastructure.IoC;
using Pharmacy.Infrastructure.Settings;
using Swashbuckle.AspNetCore.Swagger;

namespace Pharmacy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            services.AddDbContext<PharmacyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom authorization handlers
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser()
                        .RequireAssertion(context =>
                            context.User.HasClaim(ClaimTypes.Role, "Client"))
                        .Build();
                });
                options.AddPolicy("Admin", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser()
                        .RequireAssertion(context =>
                            context.User.HasClaim(ClaimTypes.Role, "Admin"))
                        .Build();
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });

            services.AddSingleton<IAuthorizationHandler, ClaimBasedAuthorizationHandler>();

            var jwtSettings = Configuration.GetSettings<JwtSettings>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                })
                .AddCustomAuth(op => { });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Pharmacy", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(module: new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            app.UseCustomExceptionHandler();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App V1");
            });

        }
    }
}
