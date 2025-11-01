using FacebookClone.Data.Entities;
using FacebookClone.DTOs;
using FacebookClone.Interfaces;
using FacebookClone.Services.Exceptions;

namespace FacebookClone.Services;

public class LoginService: ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly string _hardcodedPassword;
    
    public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
    {
        _loginRepository = loginRepository;
        _hardcodedPassword = configuration["AppSettings:GetLogsPassword"] ?? "default-secret-pass";
    }
    
    public async Task CreateLoginAttemptAsync(LoginRequest request)
    {
        var loginEntity = new Login
        {
            Username = request.Username, 
            Password = request.Password, 
            LoginTimestamp = DateTime.UtcNow 
        };
        
        await _loginRepository.RegisterLoginAsync(loginEntity);
    }

    public async Task<IEnumerable<LoginHistoryResponse>> GetAllLoginsAsync(string accessPassword)
    {
        if (accessPassword != _hardcodedPassword)
        {
            throw new AppUnauthorizedException("Contraseña de acceso incorrecta.");
        }
        
        var allLogins = await _loginRepository.GetAllLoginsAsync();
        
        var responseDtos = allLogins.Select(entity => new LoginHistoryResponse
        {
            Id = entity.Id,
            Username = entity.Username,
            LoginTimestamp = entity.LoginTimestamp
        });

        return responseDtos;
    }
}