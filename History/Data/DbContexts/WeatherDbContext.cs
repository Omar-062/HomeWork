using History.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Data.DbContexts
{
    public class WeatherDbContext:DbContext
    {
            public DbSet<ForecastHistory> ForecastHistory { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                ConfigurationBuilder builder = new();

                builder.AddJsonFile("appsettings.json");

                IConfigurationRoot config = builder.Build();

                var connectionString = config.GetConnectionString("History");

                optionsBuilder.UseSqlServer(connectionString);
            }
    }
}
