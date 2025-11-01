using FacebookClone.Interfaces;

namespace FacebookClone.Data;

public class UnitOfWork(AppDbContext _dbContext): IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}