namespace eCommerce.Application.Dtos;

public record AppUserDto(Guid Id, string? Email, string? FirstName, string? LastName, string? Gender)
{
    public AppUserDto() : this(Guid.Empty, null, null, null, null)
    {
    }
}