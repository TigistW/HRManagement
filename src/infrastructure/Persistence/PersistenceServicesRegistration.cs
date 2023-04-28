using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices( this IServiceCollection services, IConfiguration configuration){
        // services.AddDbContext<LeaveManagementDbContext> (options => 
        // options.UseSqlServer(
        //     configuration.GetConnectionString("LeaveManagement")

        // ));

        services.AddEntityFrameworkNpgsql()
               .AddDbContext<LeaveManagementDbContext>(options =>
                   options.UseNpgsql(
                       configuration.GetConnectionString("LeaveManagement"
                       )));

        services.AddScoped (typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped <ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}