using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Academy.DB
{
    public class SuperClass : DbContext
    {
        public DbSet<Academy> Students{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("CRUDacademy");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder); //////////////
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academy>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(20);
                entity.Property(x => x.Surname).IsRequired().HasMaxLength(20);

            });
        }
    }
}
