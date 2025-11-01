namespace FacebookClone.Services.Exceptions;

public class AppUnauthorizedException : Exception
{
    public AppUnauthorizedException(string message) : base(message) {}
}