using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.Factories;
using DAL.Abstractions.UnitOfWorks;
using DAL.RepositoryFactories;
using DAL.SalesDbContextFactories;
using DAL.UnitOfWorks;
using DatabaseLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SalesStatisticsDisplaySystem
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = AppConfiguration.GetConnectionString("Default");
            services.AddDbContext<DbContext, SalesDbContext>(options => 
                options.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Singleton);
            services.AddSingleton<IGenericRepositoryFactory, GenericRepositoryFactory>();
            services.AddSingleton<ISalesDbUnitOfWork, SalesDbUnitOfWork>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}