namespace FacebookClone.Data.Entities;

public class Login
{
    public int Id { get; init; }
    
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    
    public DateTime LoginTimestamp { get; init; }
}