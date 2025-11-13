namespace eCommerce.Application.Dtos;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? UserName,
    string? Gender,
    string? Token,
    bool IsSuccess)
{
    public AuthenticationResponse(): 
        this(Guid.Empty, String.Empty, String.Empty, 
            String.Empty, String.Empty, false)
    {
        
    }
}