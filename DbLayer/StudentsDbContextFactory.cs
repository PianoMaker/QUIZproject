using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DbLayer
{
    public class StudentsDbContextFactory : IDesignTimeDbContextFactory<StudentsDbContext>
    {
        public StudentsDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var options = new DbContextOptionsBuilder<StudentsDbContext>()
                .UseSqlServer(config.GetConnectionString("SqlClient"))
                .Options;
            return new StudentsDbContext(options);
        }
    }
}
