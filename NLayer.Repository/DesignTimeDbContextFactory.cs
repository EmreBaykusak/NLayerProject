using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NLayer.Repository;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath("C:\\Users\\yazilimadmin\\Source\\Repos\\NLayerProject\\NLayer.API")
            .AddJsonFile("appsettings.json")
            .Build();

    var builder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionString = configuration.GetConnectionString("SqlConnection");

        builder.UseSqlServer(connectionString);

        return new AppDbContext(builder.Options);
    }
}