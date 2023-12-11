using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Library.Persistance;

public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
{
    
    public LibraryDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Library.API");
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
    
        var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("LibraryConnectionString"));
    
        return new LibraryDbContext(optionsBuilder.Options);
    }
}