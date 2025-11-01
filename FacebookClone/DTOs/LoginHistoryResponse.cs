namespace FacebookClone.DTOs;

public class LoginHistoryResponse
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public DateTime LoginTimestamp { get; set; } 
}