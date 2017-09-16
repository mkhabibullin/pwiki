using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using pwiki.domain;
using System.IO;

namespace pwiki
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PwikiDbContext>
    {
        public PwikiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PwikiDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new PwikiDbContext(builder.Options);
        }
    }
}
