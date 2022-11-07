using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaEShop.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Data
{
    public class SqlEFDataContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Join(folder, "database.db");

            SqliteConnectionStringBuilder builder = new()
            {
                DataSource = path
            };

            optionsBuilder.UseSqlite(builder.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PizzaEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PizzaEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<PizzaEntity>().HasOne(o => o.Order)
                                              .WithMany(p => p.Pizzas);
        }
    }
}