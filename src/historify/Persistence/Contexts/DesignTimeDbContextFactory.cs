using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
    {
        public BaseDbContext CreateDbContext(string[] args)
        {
            // WebAPI klasöründeki appsettings.json dosyasının yolunu belirtiyoruz.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI")) // WebAPI klasörünü işaretliyoruz
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("BaseDataBase"), options => options.CommandTimeout(60));

            return new BaseDbContext(optionsBuilder.Options, configuration);
        }
    }
}