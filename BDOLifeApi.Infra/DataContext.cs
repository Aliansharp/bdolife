using BDOLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Infra
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ItemBase> Itens { get; set; }
        public DbSet<ItemTranslate> ItensTranslates { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<SellNPC> SellNPCs { get; set; }
        public DbSet<SellNPCItem> SellNPCsItens { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<MaterialGroup> MaterialGroups { get; set; }
        public DbSet<MasteryCooking> MasteryCooking { get; set; }
        public DbSet<MasteryAlchemy> MasteryAlchemy { get; set; }
        public DbSet<MasteryProcess> MasteryProcess { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>();
            modelBuilder.Entity<Item>();
        }
    }
}
