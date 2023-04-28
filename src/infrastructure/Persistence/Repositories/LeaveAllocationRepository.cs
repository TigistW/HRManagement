using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;
    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var LeaveAllocations = await _dbContext.LeaveAllocations
        .Include(q => q.LeaveType)
        .ToListAsync();
        return LeaveAllocations;

    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var LeaveAllocation = await _dbContext.LeaveAllocations
       .Include(q => q.LeaveType)
       .FirstOrDefaultAsync(q => q.Id == id);
        return LeaveAllocation;
    }
}
