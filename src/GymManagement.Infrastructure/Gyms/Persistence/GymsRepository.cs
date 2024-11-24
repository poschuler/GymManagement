using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

public class GymsRepository : IGymsRepository
{
    private readonly GymManagementDbContext _dbContext;

    public GymsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddGymAsync(Gym gym)
    {
        await _dbContext.Gyms.AddAsync(gym);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Gyms.AsNoTracking()
                                   .AnyAsync(g => g.Id == id);
    }

    public async Task<Gym?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Gyms.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId)
    {
        return await _dbContext.Gyms.AsNoTracking()
                                   .Where(g => g.SubscriptionId == subscriptionId)
                                   .ToListAsync();
    }

    public Task RemoveGymAsync(Gym gym)
    {
        _dbContext.Gyms.Remove(gym);

        return Task.CompletedTask;
    }

    public Task RemoveRangeAsync(List<Gym> gyms)
    {
        _dbContext.Gyms.RemoveRange(gyms);

        return Task.CompletedTask;
    }

    public Task UpdateGymAsync(Gym gym)
    {
        _dbContext.Gyms.Update(gym);

        return Task.CompletedTask;
    }
}