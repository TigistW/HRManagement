using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace HR.LeaveManagement.Persistence;

public class HRLeaveManagementDbContextFaactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
{
    public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "../../../api/HR.LeaveManagement.api")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagement");

            builder.UseNpgsql(connectionString);

            return new LeaveManagementDbContext(builder.Options);
        }

}
