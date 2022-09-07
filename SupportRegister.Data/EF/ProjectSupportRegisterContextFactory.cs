using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SupportRegister.Data.EF
{
    public class ProjectSupportRegisterContextFactory : IDesignTimeDbContextFactory<ProjectSupportRegisterContext>
    {
        public ProjectSupportRegisterContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProjectSupportRegisterContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectSupportRegisterContext(optionsBuilder.Options);
        }
    }
}
