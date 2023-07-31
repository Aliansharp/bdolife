using BDOLife.Application.Configurations.IoC;
using BDOLife.Application.Tasks;
using BDOLife.Core.Interfaces;
using BDOLife.Core.Interfaces.Base;
using BDOLife.Infra;
using BDOLife.Infra.Repositories;
using BDOLife.Infra.Repositories.Base;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDOLife
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IocConfiguration.ConfigureServices(services, Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BDOLifeApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IRecurringJobManager recurringJobManager,
            ScraperTask scraperTask)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BDOLifeApi v1"));
            }

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AppPath = null,
                DashboardTitle = "Hangfire Dashboard",
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter
                    {
                        User = Configuration.GetSection("HangfireCredentials:UserName").Value,
                        Pass = Configuration.GetSection("HangfireCredentials:Password").Value
                    }
                }
            });

            //recurringJobManager.AddOrUpdate("ExtractBDOCodex", () => scraperTask.Extract(), Cron.Weekly(DayOfWeek.Thursday));
            //recurringJobManager.AddOrUpdate("ExtractRecipeCooking", () => scraperTask.ExtractRecipeCooking(), Cron.Monthly(1));
            //recurringJobManager.AddOrUpdate("ExtractRecipeAlchemy", () => scraperTask.ExtractRecipeAlchemy(), Cron.Monthly(1));
            //recurringJobManager.AddOrUpdate("ExtractMaterials", () => scraperTask.ExtractMaterials(), Cron.Monthly(1));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
