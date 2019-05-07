using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StoreLocator.Model.Database;
using StoreLocator.Data;
using StoreLocator.Services;

namespace StoreLocator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<AppSettings>(Configuration.GetSection("AppSettings"))
                .AddTransient<IStoresDeserializer>(s =>
                {
                    var settings = s.GetRequiredService<IOptions<AppSettings>>();
                    return new StoresFromXmlDeserializer(settings.Value.StoresFilePath);
                })
                .AddDbContext<StoreContext>(builder =>
                    builder.UseSqlite(Configuration.GetConnectionString("DefaultDatabase")))
                .AddTransient<IDatabaseSeeder, DatabaseSeeder>()
                .AddTransient<IStoreService, StoreService>();

            services.AddMvc()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting(routes =>
            {
                routes.MapControllers();
            });

            app.UseAuthorization();
        }
    }
}
