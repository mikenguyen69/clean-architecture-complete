using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureV3.Api.Mappers;
using CleanArchitectureV3.Api.Models;
using CleanArchitectureV3.Core.Interfaces;
using CleanArchitectureV3.Core.SharedEntity;
using CleanArchitectureV3.Infrastructure.Data;
using CleanArchitectureV3.Infrastructure.DomainEvents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace CleanArchitectureV3.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string dbName = Guid.NewGuid().ToString();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(dbName)
            );

            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSingleton<IMapper>(_ => AutoMapperConfig.GetMapper());
            //services.AddScoped<IDomainEventDispatcher, IDomainEventDispatcher>();

            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.AssemblyContainingType(typeof(BaseEntity));
                    _.Assembly("CleanArchitectureV3.Infrastructure");
                    _.WithDefaultConventions();
                    _.ConnectImplementationsToTypesClosing(typeof(IHandler<>));
                });

                config.For(typeof(IRepository<>)).Add(typeof(EfRepository<>));
                config.For(typeof(IDomainEventDispatcher)).Add(typeof(DomainEventDispatcher));

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void ConfigureTesting(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory logger)
        {
            this.Configure(app, env, logger);
            SeedData.EnsurePopulated(app.ApplicationServices.GetService<AppDbContext>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            logger.AddConsole(Configuration.GetSection("Logging"));
            logger.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseStaticFiles();

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
