using FacebookClone.DTOs;

namespace FacebookClone.Interfaces;

public interface ILoginService
{
    Task CreateLoginAttemptAsync(LoginRequest request);
    Task<IEnumerable<LoginHistoryResponse>> GetAllLoginsAsync(string accessPassword);
}