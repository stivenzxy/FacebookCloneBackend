using FacebookClone.Data.Entities;
using FacebookClone.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.Data.Repositories;

public class LoginRepository(AppDbContext _dbContext, IUnitOfWork _unitOfWork) : ILoginRepository
{
    public async Task RegisterLoginAsync(Login loginEntity)
    {
        await _dbContext.LoginHistory.AddAsync(loginEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Login>> GetAllLoginsAsync()
    {
        return await _dbContext.LoginHistory.ToListAsync();
    }
}