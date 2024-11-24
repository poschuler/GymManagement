using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Admins.Persistence;

public class AdminsRepository : IAdminsRepository
{
    private readonly GymManagementDbContext _dbContext;

    public AdminsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Admin?> GetByIdAsync(Guid id)
    {
        return _dbContext.Admins.FirstOrDefaultAsync(a => a.Id == id);
    }

    public Task UpdateAsync(Admin admin)
    {
        _dbContext.Admins.Update(admin);
        return Task.CompletedTask;
    }
}