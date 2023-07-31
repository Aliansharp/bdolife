using BDOLife.Application.Tasks;
using BDOLife.Core.Interfaces;
using BDOLife.Core.Interfaces.Base;
using BDOLife.Infra;
using BDOLife.Infra.Repositories;
using BDOLife.Infra.Repositories.Base;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BDOLife.Application.Configurations.IoC
{
    public static class IocConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDatabases(services, configuration);

            // Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Application Layer

            // Repository Layer
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMasteryCookingRepository, MasteryCookingRepository>();
            services.AddScoped<IMasteryAlchemyRepository, MasteryAlchemyRepository>();
            services.AddScoped<IMaterialGroupRepository, MaterialGroupRepository>();

            ConfigureHangfire(services, configuration);
        }

        private static void ConfigureDatabases(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(c =>
              c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("BDOLife.Infra")));
        }

        private static void ConfigureHangfire(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ScraperTask>();

            services.AddHangfire(c => c.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
            GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")).WithJobExpirationTimeout(TimeSpan.FromDays(7));

            services.AddHangfireServer(a => a.WorkerCount = 1);
        }
    }
}
