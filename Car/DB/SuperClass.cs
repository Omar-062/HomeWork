using Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DB
{
    public class SuperClass : DbContext
    {
        public DbSet<Cars> Carss { get; set; }
        public DbSet<CarShowroom> CarShowrooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("CarShow");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder); //////////////
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Name).IsRequired().HasMaxLength(20);
                entity.Property(o => o.Model).IsRequired().HasMaxLength(20);
                entity.HasOne(o => o.CarShowroom).WithMany(m=> m.Cars).HasForeignKey(o=> o.CarShowroomId);
            });


            modelBuilder.Entity<CarShowroom>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x=> x.Name).IsRequired().HasMaxLength(20);
                entity.HasMany(x => x.Cars)
                                .WithOne(c => c.CarShowroom)
                                .HasForeignKey(c => c.CarShowroomId)
                                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
