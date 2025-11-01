using FacebookClone.Data.Entities;
using FacebookClone.DTOs;

namespace FacebookClone.Interfaces;

public interface ILoginRepository
{
    Task RegisterLoginAsync(Login loginEntity);
    Task<IEnumerable<Login>> GetAllLoginsAsync();
}